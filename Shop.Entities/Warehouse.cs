using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
