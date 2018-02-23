using System;
using System.ComponentModel;
using System.Reflection;
using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Extensions
{
    public class EnumExtenions
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string GetIniParserAttribute(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            IniParserAttribute[] attributes = (IniParserAttribute[])fi.GetCustomAttributes(typeof(IniParserAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].PropertyName;
            else
                return value.ToString();
        }
    }
}
