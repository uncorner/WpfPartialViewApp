using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfPartialViewApp
{
    public static class EnumHelper
    {
        public static string GetDescriptionValue(Enum value)
        {
            string result = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            DescriptionAttribute[] attrs = fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attrs.Length > 0)
            {
                result = attrs[0].Description;
            }

            return result;
        }

        public static IDictionary<Genre, string> GetGenreDescriptionValues()
        {
            return Enum.GetValues(typeof(Genre))
                .Cast<Genre>()
                .ToDictionary(e => e, e => GetDescriptionValue(e));
        }

    }
}
