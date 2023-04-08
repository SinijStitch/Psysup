using AutoMapper;
using MediatR;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Application.CreateApplication;

namespace Psysup.Domain.Features.Application.Commands.CreateApplication;

public class CreateApplicationHandler : IRequestHandler<CreateApplicationCommand, CreateApplicationResponse>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateApplicationHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CreateApplicationResponse> Handle(
        CreateApplicationCommand request,
        CancellationToken cancellationToken)
    {
        var application = _mapper.Map<DataAccess.Models.Application>(request);

        await _dbContext.Applications.AddAsync(application, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CreateApplicationResponse
        {
            Id = application.Id
        };
    }
}