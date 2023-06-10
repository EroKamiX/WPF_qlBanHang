using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace DataGrid.Models
{
    public class User
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string rePassword { get; set; }
        public string oldPassword { get; set; }
        public string Img { get; set; }
        public string Roles { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_At { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}