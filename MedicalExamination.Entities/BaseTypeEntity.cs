using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalExamination.Entities
{
    /// <summary>
    /// Base class for all dictionaries
    /// </summary>
    public class BaseTypeEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
