using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnraidApi.Utilities
{
    public class ConfigFileUtility
    {
        private List<string> _fileContents;

        public ConfigFileUtility(string fileContents)
        {
            _fileContents = new List<string>();

            var lines = Regex.Split(fileContents, "\r\n|\r|\n").Where(s => s != String.Empty).ToArray();
            if (lines != null)
                _fileContents.AddRange(lines);
        }

        public string GetValue(string property)
        {
            foreach (var fileContent in _fileContents)
            {
                var match = Regex.Match(fileContent, property + "=\"(.*)\"");
                if (match.Success) return match.Groups[1].Value;
            }

            return null;
        }
    }
}
