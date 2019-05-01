using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalExamination.Entities
{
    public sealed class ProvideService
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }
        [ForeignKey("PositionId")]
        public PositionType Position { get; set; }

        public Guid ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public ServiceType Service { get; set; }
    }
}
