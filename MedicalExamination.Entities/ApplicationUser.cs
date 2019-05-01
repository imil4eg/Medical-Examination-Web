using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MedicalExamination.Entities
{
    public sealed class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        public override string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

        public int WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        public Worker Worker { get; set; }
    }
}
