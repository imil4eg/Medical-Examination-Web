using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace MedicalExaminationWeb
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First()
                .GetCustomAttribute<DisplayNameAttribute>()
                .DisplayName;
        }
    }
}
