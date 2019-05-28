using System.ComponentModel;

namespace MedicalExaminationWeb
{
    public enum ProcedurePeriodicity
    {
        [DisplayName("Все")]
        EachYear = 0,
        [DisplayName("Нечетные года")]
        OddAges = 1,
        [DisplayName("Четные года")]
        EventAges = 2,
        [DisplayName("Раз в три года")]
        OnceAtThreeYears = 3,
        [DisplayName("Два раза в год")]
        TwoTimesInThreeYears = 4
    }
}
