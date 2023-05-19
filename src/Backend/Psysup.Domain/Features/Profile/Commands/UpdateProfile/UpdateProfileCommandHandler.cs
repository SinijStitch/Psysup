using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataAccess.Models;
using Psysup.Domain.Exceptions.Profile;
using Psysup.Domain.Services.Hash;

namespace Psysup.Domain.Features.Profile.Commands.UpdateProfile;

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IWebHostEnvironment _environment;
    private readonly IPasswordHasher _passwordHasher;

    public UpdateProfileCommandHandler(IPsysupDbContext dbContext, IPasswordHasher passwordHasher,
        IWebHostEnvironment environment)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _environment = environment;
    }

    public async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await FindUserOrThrowExceptionAsync(request, cancellationToken);

        SetUserName(request, user);
        SetEmailIfExists(request, user);
        SetNewPasswordIfExists(request, user);
        await SetImageIfExistsAsync(request, user, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private static void SetUserName(UpdateProfileCommand request, User user)
    {
        if (request.FirstName != null)
        {
            user.FirstName = request.FirstName;
        }

        if (request.LastName != null)
        {
            user.LastName = request.LastName;
        }
    }

    private async Task SetImageIfExistsAsync(
        UpdateProfileCommand request,
        User user,
        CancellationToken cancellationToken)
    {
        if (request.Image == null)
        {
            return;
        }

        try
        {
            const string folderName = "Images";
            var image = request.Image;
            var fileName = $"{user.Id}.jpeg";
            var filePath = Path.Combine(_environment.WebRootPath, folderName, fileName);

            var img = await Image.LoadAsync(image.OpenReadStream(), cancellationToken);
            img.Mutate(x => x.Resize(184, 184));
            await img.SaveAsync(filePath, cancellationToken);

            user.ImagePath = $"{folderName}/{fileName}";
        }
        catch (Exception exception)
        {
            throw new InvalidImageException(exception.Message);
        }
    }

    private void SetNewPasswordIfExists(UpdateProfileCommand request, User user)
    {
        if (request.NewPassword != null && !_passwordHasher.Verify(request.NewPassword, user.PasswordHash))
        {
            user.PasswordHash = _passwordHasher.HasPassword(request.NewPassword);
        }
    }

    private static void SetEmailIfExists(UpdateProfileCommand request, User user)
    {
        if (request.Email != null && request.Email != user.Email)
        {
            user.Email = request.Email;
        }
    }

    private async Task<User> FindUserOrThrowExceptionAsync(
        UpdateProfileCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
        return user ?? throw new ProfileWasNotFoundException();
    }
}