using AutoMapper;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Application.CreateApplication;
using Psysup.Domain.Features.Application.Commands.CreateApplication;

namespace Psysup.Domain.Mappings;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<CreateApplicationRequest, CreateApplicationCommand>();

        CreateMap<CreateApplicationCommand, Application>()
            .AfterMap((_, dest) =>
            {
                dest.Id = Guid.NewGuid();
                dest.CreationDateTime = DateTimeOffset.UtcNow;
            });
    }
}