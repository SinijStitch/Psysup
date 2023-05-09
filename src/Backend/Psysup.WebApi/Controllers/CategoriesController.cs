using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Psysup.DataContracts.Categories.CreateCategory;
using Psysup.Domain.Enums;
using Psysup.Domain.Features.Category.Commands.CreateCategory;
using Psysup.Domain.Features.Category.Commands.DeleteCategory;
using Psysup.Domain.Features.Category.Queries.GetCategories;
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

    [PlatformAuthorize(Roles.Admin | Roles.Doctor | Roles.User)]
    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var query = new GetCategoriesQuery();
        var response = await _sender.Send(query);
        return Ok(response);
    }

    [PlatformAuthorize(Roles.Admin)]
    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
    {
        var command = _mapper.Map<CreateCategoryCommand>(request);
        var response = await _sender.Send(command);
        return Created($"/categories/{response.Id}", response);
    }

    [PlatformAuthorize(Roles.Admin)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(Guid id)
    {
        var command = new DeleteCategoryCommand { Id = id };
        await _sender.Send(command);
        return NoContent();
    }
}