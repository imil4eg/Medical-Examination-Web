using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="Worker"/>
    /// </summary>
    public sealed class WorkerRepository : GenericRepository<Worker>
    {
        public WorkerRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
