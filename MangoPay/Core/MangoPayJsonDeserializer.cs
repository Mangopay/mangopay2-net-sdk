using MangoPay.Entities;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    public sealed class MangoPayJsonDeserializer : IDeserializer
    {
        private bool _debugMode = false;

        public MangoPayJsonDeserializer(bool debugMode)
        {
            _debugMode = debugMode;
        }

        public MangoPayJsonDeserializer() : this(false) { }

        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            bool isList = typeof(T).FullName.StartsWith("System.Collections.");

            Type genericType = typeof(T);

            if (isList)
            {
                if (!genericType.IsGenericType || !typeof(T).FullName.StartsWith("System.Collections.Generic.List"))
                    throw new ArgumentException("In case of collections, only generic lists are allowed (i.e. List<T>), where T is MangoPay.Core.Dto type or descendent.");

                genericType = typeof(T).GetGenericArguments()[0];
            }

            if (IsDescendantToDto(genericType))
            {
                if (isList)
                {
                    object result = null;

                    MethodInfo addMethod = null;

                    foreach (JToken jToken in JArray.Parse(response.Content))
                    {
                        Type targetType = typeof(T);

                        if (targetType.GetGenericArguments()[0] == typeof(User))
                        {
                            if (jToken["PersonType"].Value<string>() == User.Types.Legal)
                                genericType = typeof(UserLegal);
                            else
                                genericType = typeof(UserNatural);
                        }

                        if (result == null)
                        {
                            addMethod = targetType.GetMethod("Add", new Type[] { genericType });
                            result = Activator.CreateInstance(targetType);
                        }

                        MethodInfo mi = this.GetType().GetMethod("CastResponseToEntity", BindingFlags.NonPublic | BindingFlags.Instance)
                                            .MakeGenericMethod(new Type[] { genericType });

                        object val = mi.Invoke(this, new object[] { jToken, false });

                        addMethod.Invoke(result, new object[] { val });
                    }

                    return (T)result;
                }
                else
                {
                    JToken jToken = JToken.Parse(response.Content);

                    Type targetType = typeof(T);

                    if (genericType == typeof(User))
                    {
                        if (jToken["PersonType"].Value<string>() == User.Types.Legal)
                            genericType = typeof(UserLegal);
                        else
                            genericType = typeof(UserNatural);

                        if (isList)
                            targetType = typeof(T).MakeGenericType(new Type[] { genericType });
                    }

                    MethodInfo mi = this.GetType().GetMethod("CastResponseToEntity", BindingFlags.NonPublic | BindingFlags.Instance)
                                            .MakeGenericMethod(new Type[] { genericType });
                    return (T)mi.Invoke(this, new object[] { JToken.Parse(response.Content), false });
                }
            }

            throw new ArgumentException("T must be a type of MangoPay.Core.Dto or descendent.");
        }

        private bool IsDescendantToDto(Type type)
        {
            Type cur = type.BaseType;

            while (cur != null)
            {
                if (cur == typeof(Dto))
                {
                    return true;
                }

                cur = cur.BaseType;
            }

            return false;
        }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        private T CastResponseToEntity<T>(JToken jToken, bool asDependentObject)
            where T : Dto, new()
        {
            if (_debugMode)
            {
                Logs.Debug("Entity type", typeof(T).Name);
            }

            T result = new T();

            Dictionary<String, Type> subObjects = result.GetSubObjects();
            Dictionary<String, Dictionary<String, Dictionary<String, Type>>> dependentObjects = result.GetDependentObjects();

            foreach (FieldInfo f in result.GetType().GetFields())
            {
                String name = f.Name;

                // does this field have dependent objects?
                if (!asDependentObject && dependentObjects.ContainsKey(name))
                {
                    Dictionary<String, Dictionary<String, Type>> allowedTypes = dependentObjects[name];

                    foreach (KeyValuePair<String, JToken> entry in (JObject)jToken)
                    {
                        if (entry.Key == name)
                        {
                            String paymentTypeDef = (string)entry.Value;

                            if (allowedTypes.ContainsKey(paymentTypeDef))
                            {
                                Dictionary<String, Type> targetObjectsDef = allowedTypes[paymentTypeDef];

                                foreach (var e in targetObjectsDef)
                                {
                                    FieldInfo targetField = typeof(T).GetField(e.Key);

                                    MethodInfo mi = this.GetType().GetMethod("CastResponseToEntity", BindingFlags.NonPublic | BindingFlags.Instance)
                                        .MakeGenericMethod(new Type[] { e.Value });
                                    targetField.SetValue(result, mi.Invoke(this, new object[] { jToken, true }));
                                }
                            }

                            break;
                        }
                    }
                }

                foreach (KeyValuePair<String, JToken> entry in (JObject)jToken)
                {
                    if (entry.Key == name)
                    {
                        // is sub object?
                        if (subObjects.ContainsKey(name))
                        {
                            if (entry.Value.Type != JTokenType.Null)
                            {
                                MethodInfo mi = this.GetType().GetMethod("CastResponseToEntity", BindingFlags.NonPublic | BindingFlags.Instance)
                                    .MakeGenericMethod(new Type[] { f.FieldType });
                                f.SetValue(result, mi.Invoke(this, new object[] { entry.Value, false }));
                            }
                            break;
                        }

                        String fieldTypeName = f.FieldType.Name;
                        bool fieldIsArray = f.FieldType.FullName.StartsWith("System.Collections.");

                        if (_debugMode)
                        {
                            Logs.Debug("Recognized field", String.Format("[{0}] {1}{2}", name, fieldTypeName, fieldIsArray ? "[]" : ""));
                        }

                        if (fieldIsArray)
                        {
                            Type genericType = f.FieldType.GetGenericArguments()[0];

                            if (entry.Value.Type == JTokenType.Array)
                            {
                                MethodInfo addMethod = f.FieldType.GetMethod("Add", new Type[] { genericType });
                                object o = Activator.CreateInstance(f.FieldType);

                                foreach (var item in entry.Value)
                                {
                                    if (genericType == typeof(String))
                                    {
                                        addMethod.Invoke(o, new object[] { item.Value<String>() });
                                    }
                                    else if (genericType == typeof(Int32))
                                    {
                                        addMethod.Invoke(o, new object[] { item.Value<Int32>() });
                                    }
                                    else if (genericType == typeof(Int64))
                                    {
                                        addMethod.Invoke(o, new object[] { item.Value<Int64>() });
                                    }
                                    else if (genericType == typeof(Double))
                                    {
                                        addMethod.Invoke(o, new object[] { item.Value<Double>() });
                                    }
                                    else if (genericType == typeof(Single))
                                    {
                                        addMethod.Invoke(o, new object[] { item.Value<Single>() });
                                    }
                                    else if (genericType == typeof(Nullable<Int32>))
                                    {
                                        addMethod.Invoke(o, new object[] { item.Value<Nullable<Int32>>() });
                                    }
                                    else if (genericType == typeof(Nullable<Int64>))
                                    {
                                        addMethod.Invoke(o, new object[] { item.Value<Nullable<Int64>>() });
                                    }
                                    else if (genericType == typeof(Nullable<Double>))
                                    {
                                        addMethod.Invoke(o, new object[] { item.Value<Nullable<Double>>() });
                                    }
                                    else if (genericType == typeof(Nullable<Single>))
                                    {
                                        addMethod.Invoke(o, new object[] { item.Value<Nullable<Single>>() });
                                    }
                                    else if (genericType == typeof(Boolean))
                                    {
                                        addMethod.Invoke(o, new object[] { item.Value<Boolean>() });
                                    }
                                }

                                f.SetValue(result, o);
                            }
                        }
                        else
                        {
                            switch (entry.Value.Type)
                            {
                                case JTokenType.String:
                                    if (f.FieldType == typeof(String))
                                        f.SetValue(result, entry.Value.Value<String>());
                                    else if (f.FieldType.IsEnum)
                                        f.SetValue(result, Enum.Parse(f.FieldType, entry.Value.Value<String>()));
                                    break;

                                case JTokenType.Integer:
                                case JTokenType.Float:
                                    if (f.FieldType == typeof(Int64))
                                        f.SetValue(result, entry.Value.Value<Int64>());
                                    else if (f.FieldType == typeof(Int32))
                                        f.SetValue(result, entry.Value.Value<Int32>());
                                    else if (f.FieldType == typeof(Nullable<Int64>))
                                        f.SetValue(result, entry.Value.Value<Nullable<Int64>>());
                                    else if (f.FieldType == typeof(Nullable<Int32>))
                                        f.SetValue(result, entry.Value.Value<Nullable<Int32>>());
                                    else if (f.FieldType == typeof(Double))
                                        f.SetValue(result, entry.Value.Value<Double>());
                                    else if (f.FieldType == typeof(Single))
                                        f.SetValue(result, entry.Value.Value<Single>());
                                    else if (f.FieldType == typeof(Nullable<Double>))
                                        f.SetValue(result, entry.Value.Value<Nullable<Double>>());
                                    else if (f.FieldType == typeof(Nullable<Single>))
                                        f.SetValue(result, entry.Value.Value<Nullable<Single>>());
                                    break;

                                case JTokenType.Boolean:
                                    f.SetValue(result, entry.Value.Value<Boolean>());
                                    break;

                                case JTokenType.Null:
                                    // do nothing //
                                    break;

                                default:
                                    throw new ArgumentException("Unhandled field type: " + entry.Value.Type.ToString());
                            }

                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
