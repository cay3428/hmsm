using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserOperationClaims : IEntity

    { public int Id { get; set; }
 
        public int OperationClaimId { get; set; }

        
    }
}
