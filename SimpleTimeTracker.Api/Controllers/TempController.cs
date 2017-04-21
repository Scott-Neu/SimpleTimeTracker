using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SimpleTimeTracker.Core.DbContexts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleTimeTracker.Api.Controllers
{
    public class TempController : ControllerBase
    {
        public TempController(UserContext userContext)
            : base (userContext)
        { }

        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { ApplicationUser.FirstName, this.UserId.ToString(), "value2" };
        }
    }
}
