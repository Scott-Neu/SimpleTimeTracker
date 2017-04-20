using SimpleTimeTracker.Core.Helpers;
using System;
using System.Collections.Generic;

namespace SimpleTimeTracker.Core.Models
{
    public class ApplicationUser : ModelBase
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public DateTimeOffset HireDate { get; set; }
        public DateTimeOffset? TermDate { get; set; }
        public string Password { get; set; }
        public bool IsDefaultUser { get; set; }
        public virtual List<Claim> Claims { get; set; }

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
            Claims = new List<Claim>();
        }

        public void SetPassword(string clearTextPassword)
        {
            Password = PasswordHasher.HashPassword(clearTextPassword);
        }
    }
}
