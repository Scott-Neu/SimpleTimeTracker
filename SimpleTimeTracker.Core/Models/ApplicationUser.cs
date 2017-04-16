using SimpleTimeTracker.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleTimeTracker.Core.Models
{
    public class ApplicationUser : ModelBase
    {
        [Required]
        [EmailAddress]
        [StringLength(254)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string Suffix { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

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
            Claims = new List<Claim>();
        }

        public void SetPassword(string clearTextPassword)
        {
            Password = PasswordHasher.HashPassword(clearTextPassword);
        }
    }
}
