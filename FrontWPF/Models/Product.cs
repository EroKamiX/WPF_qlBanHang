using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataGrid.Models
{
    public class Product
    {
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Detail { get; set; }
        public string Metakey { get; set; }
        public string Metadesc { get; set; }
        public string Img { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
        public double Pricesale { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_At { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public int Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}