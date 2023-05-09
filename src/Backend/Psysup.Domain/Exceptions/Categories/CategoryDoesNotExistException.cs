using Psysup.Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psysup.Domain.Exceptions.Categories
{
    public class CategoryDoesNotExistException : NotFoundException
    {
        private const string ErrorMessage = "Category does not exist.";

        public CategoryDoesNotExistException() : base(ErrorMessage)
        {
            
        }

        public override int Code => (int)CategoriesCodes.CategoryDoesNotExist;
    }
}
