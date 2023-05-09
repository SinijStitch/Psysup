using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psysup.DataContracts.Categories.GetCategories
{
    public class GetCategoriesResponseItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
