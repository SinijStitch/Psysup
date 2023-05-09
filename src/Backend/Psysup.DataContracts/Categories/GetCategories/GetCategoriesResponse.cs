using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psysup.DataContracts.Categories.GetCategories
{
    public class GetCategoriesResponse
    {
        public IEnumerable<GetCategoriesResponseItem> Categories { get; set; } = new List<GetCategoriesResponseItem>();
    }
}
