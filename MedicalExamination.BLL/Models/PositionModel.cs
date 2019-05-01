using System;

namespace MedicalExamination.BLL
{
    public sealed class PositionModel
    {
        public Guid Id { get; set; }

        public int WorkerId { get; set; }

        public Guid PositionId { get; set; }
    }
}
