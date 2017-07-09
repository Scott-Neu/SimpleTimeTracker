using SimpleTimeTracker.Core.DbContexts;
using SimpleTimeTracker.Core.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTimeTracker.Core.Interfaces;
using SimpleTimeTracker.Core.Helpers;

namespace SimpleTimeTracker.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private UserContext _userContext;
        public AuthenticationService(UserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        public async Task<ApplicationUser> GetAuthenticatedUser(string emailAddress, string password)
        {
            if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentNullException(nameof(emailAddress));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(emailAddress));

            var user = await _userContext.ApplicationUsers
                .Include(s => s.Claims)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Email.Equals(emailAddress, StringComparison.CurrentCultureIgnoreCase));

            if (user == null) return null;
            if (!user.IsActive) return null;

            // validate password
            var isValidPassword = PasswordHasher.IsMatch(password, user.Password);
            if (isValidPassword) return user;

            return null;
        }
    }
}
