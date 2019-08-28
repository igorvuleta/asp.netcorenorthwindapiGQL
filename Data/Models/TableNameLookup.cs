using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Models
{
    public interface ITableNameLookup
    {
        bool InsertKeyName(string correctName);
        string GetFriendlyName(string friendlyName);
    }

    public class TableNameLookup : ITableNameLookup
    {
        private IDictionary<string, string> _lookupTable = new Dictionary<string, string>();


        public string GetFriendlyName(string friendlyName)
        {
            if (!_lookupTable.TryGetValue(friendlyName, out string value))
                throw new Exception($"Could not get {friendlyName} out of the list");
            return value;
        }

        public bool InsertKeyName(string correctName)
        {
            if(!_lookupTable.ContainsKey(correctName))
            {
                var friendlyName = CanonicalName(correctName);
                _lookupTable.Add(correctName, friendlyName);
                return true;
            }
            return false;
        }

        private string CanonicalName(string correctName)
        {
            var index = correctName.LastIndexOf("_");
            var result = correctName.Substring(
                index + 1,
                correctName.Length - index - 1

                );

            return Char.ToLowerInvariant(result[0]) + result.Substring(1);
        }
    }
}
