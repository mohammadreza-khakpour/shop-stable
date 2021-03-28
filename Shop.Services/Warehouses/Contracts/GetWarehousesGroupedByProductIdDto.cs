using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Warehouses.Contracts
{
    public class GetWarehousesGroupedByProductIdDto
    {
        public int product_category_Id { get; set; }
        public int product_id { get; set; }
        public string product_code { get; set; }
        public string product_title { get; set; }
        public int productCount_Overall { get; set; }
        public int product_minimumAmount { get; set; }
        public bool product_isEnough { get; set; }
    }
}
