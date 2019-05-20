using System;
using System.Collections.Generic;

namespace MedicalExamination.BLL.Extensions
{
    public static class ListExtension
    {
        public static bool AgeBetweenGivenNumbers(this IList<string> ages, DateTime compareAge)
        {
            int after = int.Parse(ages[0]);
            int till = int.Parse(ages[1]);

            int age = DateTime.Now.Year - compareAge.Year;

            return after >= age && till < age;
        }
    }
}
