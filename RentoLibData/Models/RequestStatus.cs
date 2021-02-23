using System;
using System.Collections.Generic;

#nullable disable

namespace RentoLibData.Models
{
    public partial class RequestStatus
    {
        public RequestStatus()
        {
            ProductRequests = new HashSet<ProductRequest>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductRequest> ProductRequests { get; set; }
    }
}
