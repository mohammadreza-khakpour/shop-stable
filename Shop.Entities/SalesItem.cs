using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public class SalesItem
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public string ProductCode { get; set; }
        public double ProductPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SalesChecklistId { get; set; }
        public SalesCheckList SalesChecklist { get; set; }
    }
}
