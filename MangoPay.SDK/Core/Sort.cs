using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    /// <summary>Base sorting class.</summary>
    public class Sort
    {
        private readonly Dictionary<string, SortDirection> sortFields = new Dictionary<string,SortDirection>();

        public string GetFields()
        {
            var sortValues = string.Empty;

            foreach (var item in sortFields)
            {
                if (sortValues != string.Empty)
                {
                    sortValues += Constants.SORT_FIELD_SEPARATOR;
                }

                sortValues += $"{item.Key}:{item.Value}";
            }

            return sortValues;
        }

        public bool IsSet => GetFields() != string.Empty;

        public void AddField(string fieldName, SortDirection sortDirection)
        {
            if (sortDirection != SortDirection.NotSpecified)
                sortFields.Add(fieldName, sortDirection);
        }
    }
}
