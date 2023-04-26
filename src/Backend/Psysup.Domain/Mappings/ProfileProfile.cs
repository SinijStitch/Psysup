using AutoMapper;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Profile.GetProfile;

namespace Psysup.Domain.Mappings;

public class ProfileProfile : Profile
{
    public ProfileProfile()
    {
        CreateMap<User, GetProfileResponse>();
    }
}