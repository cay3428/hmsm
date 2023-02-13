using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Sales : IEntity
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContatcTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public  int Phone { get; set; }
        public int Fax { get; set; }
        public string Email { get; set; }

    }
}
