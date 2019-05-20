using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    public class QuestionnaireAfter75Repository : GenericRepository<QuestionnaireAfter75>
    {
        public QuestionnaireAfter75Repository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
