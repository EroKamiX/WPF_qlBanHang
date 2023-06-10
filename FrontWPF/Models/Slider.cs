using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataGrid.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link{ get; set; }
        public string Img { get; set; }
        public int Orders { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_At { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public int Status { get; set; }
    }
}