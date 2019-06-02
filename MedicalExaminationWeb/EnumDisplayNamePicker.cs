using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalExaminationWeb
{
    public sealed class EnumDisplayNamePicker
    {
        public static SelectList GetDisplayNames(Type enumType)
        {
            var periodicityValues = enumType.GetEnumValues();

            var displayAttributes = new List<SelectListItem>();
            foreach (var periodicityValue in periodicityValues)
            {
                displayAttributes.Add(new SelectListItem
                {
                    Value = ((int)periodicityValue).ToString(),
                    Text = (Convert.ChangeType(periodicityValue, enumType) as Enum).GetDisplayName()
                });
            }
            return new SelectList(displayAttributes, "Value", "Text", displayAttributes.First().Value);
        }
    }
}
