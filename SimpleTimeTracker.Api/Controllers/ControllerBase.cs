using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleTimeTracker.Core.DbContexts;
using SimpleTimeTracker.Core.Extensions;
using SimpleTimeTracker.Core.Models;
using System;
using System.Linq;

namespace SimpleTimeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public abstract class ControllerBase : Controller
    {
        private UserContext _userContext;

        protected Guid UserId { get { return User.Claims.FirstOrDefault(i => i.Type == "Id").Value.ToGuid(); } }
        private ApplicationUser _applicationUser;
        protected ApplicationUser ApplicationUser {
            get
            {
                if (_applicationUser == null)
                {
                    _applicationUser = _userContext.ApplicationUsers
                                                   .Include(s => s.Claims)
                                                   .AsNoTracking()
                                                   .SingleOrDefaultAsync(m => m.Id == UserId).Result;
                }

                return _applicationUser;
            }
        }

        public ControllerBase(UserContext userContext)
        {
            _userContext = userContext;
        }

    }
}
