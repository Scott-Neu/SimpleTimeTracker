using AutoMapper;
using SimpleTimeTracker.Api.ViewModels;
using SimpleTimeTracker.Core.Models;

namespace SimpleTimeTracker.Api
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<ApplicationUser, UsersViewModel>();
        }
    }
}
