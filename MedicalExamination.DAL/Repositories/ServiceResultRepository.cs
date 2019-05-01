using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    public sealed class ServiceResultRepository : GenericRepository<ServiceResult>
    {
        public ServiceResultRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
