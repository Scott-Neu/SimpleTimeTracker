using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleTimeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class TempController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;

            return new string[] { "value1", "value2" };
        }
    }
}
