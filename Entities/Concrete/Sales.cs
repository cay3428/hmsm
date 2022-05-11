using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Sales : IEntity
    {
        public int SalesId { get; set; }

        public string CustomerId { get; set; }

        public DateTime SalesDate { get; set; }

        public DateTime LicenceBeginningDate { get; set; }

        public DateTime LicenceEndingDate { get; set; }

        public string ProductName { get; set; }

        public int UnitPrice { get; set; }

        public string LicenceCode { get; set; }


    }
}
