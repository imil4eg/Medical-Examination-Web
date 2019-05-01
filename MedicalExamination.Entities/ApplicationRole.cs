using System;
using Microsoft.AspNetCore.Identity;

namespace MedicalExamination.Entities
{
    public sealed class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
            Id = Guid.NewGuid();
        }

        public ApplicationRole(string roleName) : this()
        {
            Name = roleName;
        }

        public ApplicationRole(string id, string roleName)
        {
            Id = new Guid(id);
            Name = roleName;
        }
    }
}
