using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.ProductCategories.Contracts
{
    public class GetProductCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
