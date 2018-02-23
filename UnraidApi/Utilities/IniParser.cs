using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnraidApi.Utilities
{
    public class IniParser
    {
        private string _contents;
        private IniFormatStyle _iniFormatStyle;
        private IniFile _iniFile;

        public IniParser(string contents, IniFormatStyle iniFormatStyle = IniFormatStyle.Default)
        {
            _contents = contents;
            _iniFormatStyle = iniFormatStyle;

            // Trim
            _contents = _contents.Trim();

            _iniFile = new IniFile();
        }

        public IniFile ParseIniFile()
        {
            // If the ini file does not have any blocks, create default block
            if (!HasBlocks(_contents))
                _contents = _contents.Insert(0, "[\"Default\"]" + Environment.NewLine);

            // Split into blocks
            var blockMatches = Regex.Matches(_contents, "\\[\"([^\\]\r\n]+)\"\\](?:\r?\n(?:[^\\[\r\n].*)?)*"); // old regex (\\[\"(.+)\"\\])([\\S\\s]*?)(?=\\[\".+\"\\])
            foreach (Match blockMatch in blockMatches)
            {
                // Create block and set name
                var block = new Block
                {
                    Name = blockMatch.Groups[1].Value.Trim()
                };

                // Split block into lines
                var blockLines = Regex.Split(blockMatch.Value, "\r\n|\r|\n").Where(s => s != String.Empty).ToArray();
                foreach (var blockLine in blockLines)
                {
                    if (blockLine == null) continue; // drop possible empty lines

                    // Split line into property name and value
                    if (_iniFormatStyle == IniFormatStyle.Default)
                    {
                        var propertyMatch = Regex.Match(blockLine, "^(.+)=\"(.*)\"$", RegexOptions.Multiline);
                        if (propertyMatch.Success)
                        {
                            block.Properties.Add(new Property
                            {
                                Name = propertyMatch.Groups[1].Value.Trim(),
                                Value = propertyMatch.Groups[2].Value.Trim()
                            });
                        }
                    }
                    else if (_iniFormatStyle == IniFormatStyle.Special1)
                    {
                        var propertyMatch = Regex.Match(blockLine, "^(.+)\\s*:\\s(.+)$", RegexOptions.Multiline);
                        if (propertyMatch.Success)
                        {
                            block.Properties.Add(new Property
                            {
                                Name = propertyMatch.Groups[1].Value.Trim(),
                                Value = propertyMatch.Groups[2].Value.Trim()
                            });
                        }
                    }
                }

                _iniFile.Blocks.Add(block);
            }

            return _iniFile;
        }

        private bool HasBlocks(string content)
        {
            return Regex.Matches(content, "\\[\"([^\\]\r\n]+)\"\\](?:\r?\n(?:[^\\[\r\n].*)?)*").Count > 0;
        }

        public string GetValue(string blockName, string property)
        {
            string output = null;

            foreach (var block in _iniFile.Blocks)
            {
                if (block.Name == blockName)
                {
                    foreach (var blockProperty in block.Properties)
                    {
                        if (blockProperty.Name == property)
                        {
                            output = blockProperty.Value;
                        }
                    }
                }
            }

            return output;
        }

        public class IniFile
        {
            public IniFile()
            {
                Blocks = new List<Block>();
            }

            public List<Block> Blocks { get; set; }
        }

        public class Block
        {
            public Block()
            {
                Properties = new List<Property>();
            }

            public string Name { get; set; }
            public List<Property> Properties { get; set; }
        }

        public class Property
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public class IniParserAttribute : Attribute
        {
            private string _propertyName;

            public IniParserAttribute(string propertyName)
            {
                _propertyName = propertyName;
            }

            public virtual string PropertyName
            {
                get
                {
                    return _propertyName;
                }
            }
        }

        public enum IniFormatStyle
        {
            /// <summary>
            /// property="value"
            /// </summary>
            Default,

            /// <summary>
            /// PROPERTY    : Value
            /// </summary>
            Special1
        }
    }
}
