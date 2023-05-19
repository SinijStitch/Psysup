using AutoMapper;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Users.GetUsers;
using Psysup.Domain.Features.Users.Queries.GetUsers;

namespace Psysup.Domain.Mappings;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<GetUsersRequest, GetUsersQuery>();
        CreateMap<User, GetUsersResponseItem>();
    }
}