using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleTimeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("api/[controller]/extend")]
        public void Post([FromBody]string value)
        {

        }
    }
}
