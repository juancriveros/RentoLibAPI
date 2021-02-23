using System;
using System.Collections.Generic;

#nullable disable

namespace RentoLibData.Models
{
    public partial class City
    {
        public City()
        {
            UserLocations = new HashSet<UserLocation>();
        }

        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<UserLocation> UserLocations { get; set; }
    }
}
