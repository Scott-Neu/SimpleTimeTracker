using System;

namespace SimpleTimeTracker.Api.ViewModels
{
    public class UsersViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public bool IsActive { get; set; }
    }
}
