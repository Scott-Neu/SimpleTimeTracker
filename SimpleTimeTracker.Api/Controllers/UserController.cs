using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SimpleTimeTracker.Core.DbContexts;
using SimpleTimeTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using SimpleTimeTracker.Api.ViewModels;
using System.Linq;

namespace SimpleTimeTracker.Api.Controllers
{
    public class UserController : ControllerBase
    {
        private UserContext _userContext;
        private IMapper _mapper;
        public UserController(UserContext userContext, IMapper mapper)
            : base (userContext)
        {
            _userContext = userContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UsersViewModel>> Get()
        {
            var users = await _userContext.ApplicationUsers
                .OrderByDescending(o => o.IsActive)
                .ThenBy(o => o.LastName)
                .ThenBy(o => o.FirstName)
                .AsNoTracking()
                .ToListAsync();

            var mapped = Mapper.Map<List<ApplicationUser>, List<UsersViewModel>>(users);

            return mapped;
        }

        //[HttpGet("{id}", Name = "GetUser")]
        //public async Task<ApplicationUser> Get(Guid id)
        //{
        //    var user = await _userContext.ApplicationUsers
        //        .Include(s => s.Claims)
        //        .AsNoTracking()
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    return user;
        //}
    }
}
