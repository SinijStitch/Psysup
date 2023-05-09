using Psysup.Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psysup.Domain.Exceptions.Profile
{
    public class InvalidImageException : ValidationException
    {
        public InvalidImageException(string message) : base(message)
        {
            
        }

        public override int Code => (int)ProfileCodes.InvalidImage;
    }
}
