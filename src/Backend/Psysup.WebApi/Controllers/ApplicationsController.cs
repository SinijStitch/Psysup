using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Psysup.DataContracts.Application.CreateApplication;
using Psysup.DataContracts.Application.GetApplications;
using Psysup.Domain.Enums;
using Psysup.Domain.Features.Application.Commands.ApplyDoctor;
using Psysup.Domain.Features.Application.Commands.CreateApplication;
using Psysup.Domain.Features.Application.Commands.DeleteApplication;
using Psysup.Domain.Features.Application.Queries.GetApplicationById;
using Psysup.Domain.Features.Application.Queries.GetApplications;
using Psysup.Domain.Features.Application.Queries.GetAppliedDoctors;
using Psysup.WebApi.Filters;

namespace Psysup.WebApi.Controllers;

[Route("[controller]")]
[PlatformAuthorize]
public class ApplicationsController : ApiControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public ApplicationsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplicationAsync(CreateApplicationRequest request)
    {
        var command = _mapper.Map<CreateApplicationCommand>(request);
        command.UserId = UserId;
        var response = await _sender.Send(command);
        return Created($"/applications/{response.Id}", response);
    }

    [HttpGet]
    public async Task<IActionResult> GetApplicationsAsync([FromQuery] GetApplicationsRequest request)
    {
        var query = _mapper.Map<GetApplicationsQuery>(request);
        query.UserId = UserId;
        query.Roles = UserRoles;
        var response = await _sender.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApplicationByIdAsync([FromRoute] Guid id)
    {
        var query = new GetApplicationByIdQuery { UserId = UserId, ApplicationId = id };
        var response = await _sender.Send(query);
        return Ok(response);
    }

    [PlatformAuthorize(Roles.Doctor)]
    [HttpPost("apply/{applicationId}")]
    public async Task<IActionResult> ApplyDoctorAsync([FromRoute] Guid applicationId)
    {
        var command = new ApplyDoctorCommand { DoctorId = UserId, ApplicationId = applicationId };
        await _sender.Send(command);
        return Ok();
    }

    [PlatformAuthorize(Roles.User)]
    [HttpGet("apply/{applicationId}")]
    public async Task<IActionResult> GetAppliedDoctorsAsync([FromRoute] Guid applicationId)
    {
        var query = new GetAppliedDoctorsQuery { UserId = UserId, ApplicationId = applicationId };
        var response = await _sender.Send(query);
        return Ok(response);
    }

    [PlatformAuthorize(Roles.Admin | Roles.User)]
    [HttpDelete("{applicationId}")]
    public async Task<IActionResult> DeleteApplicationAsync([FromRoute] Guid applicationId)
    {
        var command = new DeleteApplicationCommand
        {
            UserId = UserId,
            Roles = UserRoles,
            ApplicationId = applicationId
        };

        await _sender.Send(command);
        return NoContent();
    }
}