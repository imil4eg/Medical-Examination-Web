using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalExamination.Entities
{
    public class ProvideService
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual PositionType Position { get; set; }

        public Guid ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public virtual ServiceType Service { get; set; }
    }
}
