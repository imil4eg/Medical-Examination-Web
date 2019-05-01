using System;

namespace MedicalExamination.BLL
{
    public sealed class ProvideServiceModel
    {
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }

        public Guid ServiceId { get; set; }
    }
}
