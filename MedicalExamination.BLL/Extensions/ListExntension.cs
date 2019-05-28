using System.Collections.Generic;

namespace MedicalExamination.BLL.Extensions
{
    public static class ListExtension
    {
        public static bool AgeBetweenGivenNumbers(this IList<string> ages, int age)
        {
            int after = int.Parse(ages[0]);
            int till = int.Parse(ages[1]);

            return after <= age && till > age;
        }
    }
}
