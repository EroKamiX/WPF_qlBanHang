using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataGrid.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public int Table { get; set; }
        public int ParentId { get; set; }
        public int Orders { get; set; }
        public int Status { get; set; }
    }
}