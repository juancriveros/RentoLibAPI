using System;
using System.Collections.Generic;

#nullable disable

namespace RentoLibData.Models
{
    public partial class ProductRequest
    {
        public int ProductRequestId { get; set; }
        public int ProductId { get; set; }
        public int RequestUserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Message { get; set; }
        public string MeetingPoint { get; set; }
        public int Status { get; set; }
        public decimal UnitPrice { get; set; }
        public int Duration { get; set; }

        public virtual Product ProductRequestNavigation { get; set; }
        public virtual User RequestUser { get; set; }
        public virtual RequestStatus StatusNavigation { get; set; }
    }
}
