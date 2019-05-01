using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="Person"/>
    /// </summary>
    public sealed class PersonRepository : GenericRepository<Person>
    {
        public PersonRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
