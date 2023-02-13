using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class CustomerOperationClaim :IEntity
    {
        public int Id { get; set; }
        public int customerId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
