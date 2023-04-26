﻿using AutoMapper;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Application.CreateApplication;
using Psysup.DataContracts.Application.GetApplicationById;
using Psysup.DataContracts.Application.GetApplications;
using Psysup.DataContracts.Application.GetAppliedDoctors;
using Psysup.Domain.Features.Application.Commands.ApplyDoctor;
using Psysup.Domain.Features.Application.Commands.CreateApplication;
using Psysup.Domain.Features.Application.Queries.GetApplications;

namespace Psysup.Domain.Mappings;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<CreateApplicationRequest, CreateApplicationCommand>();

        CreateMap<CreateApplicationCommand, Application>()
            .ForMember(x => x.Categories, x => x.Ignore())
            .AfterMap((_, dest) =>
            {
                dest.Id = Guid.NewGuid();
                dest.CreationDateTime = DateTimeOffset.UtcNow;
            });

        CreateMap<GetApplicationsRequest, GetApplicationsQuery>();
        CreateMap<Application, GetApplicationsResponseItem>();
        CreateMap<Application, GetApplicationByIdResponse>();
        CreateMap<ApplyDoctorCommand, AppliedDoctorApplication>();
        CreateMap<User, GetAppliedDoctorsResponseItem>();
        CreateMap<Category, GetApplicationByIdCategory>();
    }
}