using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    public sealed class QuestionnaireTill75Repository : GenericRepository<QuestionnaireTill75>
    {
        public QuestionnaireTill75Repository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
