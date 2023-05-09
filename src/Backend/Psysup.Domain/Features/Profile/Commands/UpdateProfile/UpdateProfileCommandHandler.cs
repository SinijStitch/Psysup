using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.Domain.Exceptions.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psysup.Domain.Features.Profile.Commands.UpdateProfile
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
    {
        private readonly IPsysupDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public UpdateProfileCommandHandler(IPsysupDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

            if(user == null)
            {
                throw new ProfileWasNotFoundException();
            }

            try
            {
                const string folderName = "Images";
                var image = request.Image;
                var extension = Path.GetExtension(image.FileName);
                var fileName = $"{user.Id}{extension}";
                var filePath = Path.Combine(_environment.WebRootPath, folderName, fileName);

                var img = await Image.LoadAsync(image.OpenReadStream(), cancellationToken);
                img.Mutate(x => x.Resize(184, 184));
                await img.SaveAsync(filePath, cancellationToken);

                user.ImagePath = $"{folderName}/{fileName}";
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new InvalidImageException(ex.Message);
            }
        }
    }
}
