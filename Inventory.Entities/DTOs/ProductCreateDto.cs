using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.DTOs
{
    public class ProductCreateDto
    {
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Barcode { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }
    }
}
