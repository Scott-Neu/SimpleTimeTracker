using System.Threading.Tasks;
using SimpleTimeTracker.Core.Models;

namespace SimpleTimeTracker.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ApplicationUser> GetAuthenticatedUser(string emailAddress, string password);
    }
}