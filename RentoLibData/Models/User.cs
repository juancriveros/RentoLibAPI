using System;
using System.Collections.Generic;

#nullable disable

namespace RentoLibData.Models
{
    public partial class User
    {
        public User()
        {
            ProductRequests = new HashSet<ProductRequest>();
            Products = new HashSet<Product>();
            UserLocations = new HashSet<UserLocation>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<ProductRequest> ProductRequests { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<UserLocation> UserLocations { get; set; }
    }
}
