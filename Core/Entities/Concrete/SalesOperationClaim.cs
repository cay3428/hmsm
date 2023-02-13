using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
   public class SalesOperationClaim :IEntity
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
