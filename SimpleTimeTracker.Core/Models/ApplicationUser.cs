using SimpleTimeTracker.Core.Helpers;
using System;

namespace SimpleTimeTracker.Core.Models
{
    public class ApplicationUser : ModelBase
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TermDate { get; set; }
        public string Password { get; set; }
        public bool IsDefaultUser { get; set; }

        public ApplicationUser()
            : base()
        {
            Initialize();
        }

        public ApplicationUser(Guid byUserId)
            : base(byUserId)
        {
            Initialize();
        }

        private void Initialize()
        {
            IsDefaultUser = false;
        }

        public void SetPassword(string clearTextPassword)
        {
            Password = PasswordHasher.HashPassword(clearTextPassword);
        }
    }
}
