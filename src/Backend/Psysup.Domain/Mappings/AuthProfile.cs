using AutoMapper;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Auth;
using Psysup.DataContracts.Auth.Login;
using Psysup.DataContracts.Auth.Register;
using Psysup.Domain.Features.Auth.Commands.Login;
using Psysup.Domain.Features.Auth.Commands.Register;

namespace Psysup.Domain.Mappings;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<RegisterRequest, RegisterCommand>();
        CreateMap<LoginRequest, LoginCommand>();

        CreateMap<RegisterCommand, User>().AfterMap((_, dest) => { dest.Id = Guid.NewGuid(); });

        CreateMap<User, AuthResponse>().AfterMap((src, dest) =>
        {
            dest.Roles = src.Roles?.Select(x => x.Name) ?? new List<string>();
        });
    }
}