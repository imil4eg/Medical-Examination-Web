using System;
using Microsoft.AspNetCore.Identity;

namespace MedicalExamination.Entities
{
    public sealed class UserClaim : IdentityUserClaim<Guid>
    {
    }
}
