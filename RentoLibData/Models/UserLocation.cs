using System;
using System.Collections.Generic;

#nullable disable

namespace RentoLibData.Models
{
    public partial class UserLocation
    {
        public int UserLocationId { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }
        public string ComplemetAddress { get; set; }
        public string AddressTwo { get; set; }
        public string ComplementAddressTwo { get; set; }

        public virtual City City { get; set; }
        public virtual User User { get; set; }
    }
}
