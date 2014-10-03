using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    /// <summary>Base sorting class.</summary>
    public class Sort
    {
        private Dictionary<String, SortDirection> sortFields = new Dictionary<string,SortDirection>();

        public String GetFields()
        {
            string sortValues = String.Empty;

            foreach (KeyValuePair<String, SortDirection> item in sortFields)
            {
                if (sortValues != String.Empty)
                {
                    sortValues += Constants.SORT_FIELD_SEPARATOR;
                }

                sortValues += String.Format("{0}:{1}", item.Key, item.Value);
            }

            return sortValues;
        }

        public bool IsSet
        {
            get
            {
                return GetFields() != String.Empty;
            }
        }

        public void AddField(string fieldName, SortDirection sortDirection)
        {
            if (sortDirection != SortDirection.NotSpecified)
                sortFields.Add(fieldName, sortDirection);
        }
    }
}
