﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Products.Contracts
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimumAmount { get; set; }
        public int ProductCategoryId { get; set; }
        public bool IsSufficientInStore { get; set; }
    }
}
