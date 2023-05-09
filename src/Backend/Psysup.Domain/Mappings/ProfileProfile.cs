using AutoMapper;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Profile.GetProfile;
using Psysup.DataContracts.Profile.UpdateProfile;
using Psysup.Domain.Features.Profile.Commands.UpdateProfile;

namespace Psysup.Domain.Mappings;

public class ProfileProfile : Profile
{
    public ProfileProfile()
    {
        CreateMap<User, GetProfileResponse>();
        CreateMap<UpdateProfileRequest, UpdateProfileCommand>();
    }
}