using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Psysup.DataContracts.Categories.CreateCategory;
using Psysup.Domain.Enums;
using Psysup.Domain.Features.Category.Commands.CreateCategory;
using Psysup.WebApi.Filters;

namespace Psysup.WebApi.Controllers;

[PlatformAuthorize]
[Route("[controller]")]
public class CategoriesController : ApiControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public CategoriesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [PlatformAuthorize(Roles.Admin)]
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
    {
        var command = _mapper.Map<CreateCategoryCommand>(request);
        var response = await _sender.Send(command);
        return Created($"/categories/{response.Id}", response);
    }
}