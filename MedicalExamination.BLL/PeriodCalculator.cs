using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class PeriodCalculator
    {
        public static bool IsAgeInPeriod(int age, ProcedurePeriodicity periodicity, string ageRange)
        {
            int from = int.Parse(ageRange.Split('-')[0]);
            int to = int.Parse(ageRange.Split('-')[1]);

            switch (periodicity)
            {
                case ProcedurePeriodicity.EachYear:
                    return true;
                case ProcedurePeriodicity.OddAges:
                    return age % 3 == 0;
                case ProcedurePeriodicity.EventAges:
                    return age % 2 == 0;
                case ProcedurePeriodicity.OnceAtThreeYears:
                {
                    for (int i = @from + 3; i < to; i+=3)
                    {
                        if (i == age)
                            return true;

                        if (i < age)
                            return false;
                    }

                    break;
                }
                case ProcedurePeriodicity.TwoTimesInThreeYears:
                {
                    for (int i = @from; i < to; i += 3)
                    {
                        if (i == age)
                            return false;

                        if (i < age)
                            continue;

                        if (i > age)
                            return true;
                    }

                    break;
                }
            }

            return false;
        }
    }
}
