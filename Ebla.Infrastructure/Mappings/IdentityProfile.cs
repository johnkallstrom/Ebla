namespace Ebla.Infrastructure.Mappings
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
        }
    }
}
