using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int SalesOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public int Discontinued { get; set; }

        public int CategoryId { get; set; }
      
 
      

    }
}
