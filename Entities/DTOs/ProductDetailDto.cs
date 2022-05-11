
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int UnitPrice { get; set; }

        public int SalesOnOrder { get; set; }

        public int Discontinued { get; set; }
    }
}
