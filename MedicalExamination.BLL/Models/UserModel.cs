using System;

namespace MedicalExamination.BLL
{
    public sealed class UserModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public WorkerModel Worker { get; set; }
    }
}
