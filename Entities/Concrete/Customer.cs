using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string ContatcTitle { get; set; }
        public string Address { get; set; }

        public string Country { get; set; }
        public int Phone { get; set; }
        public int Fax { get; set; }

    }
}
