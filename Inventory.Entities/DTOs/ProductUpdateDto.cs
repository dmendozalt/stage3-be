using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.DTOs
{
    public class ProductUpdateDto
    {
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Barcode { get; set; }
        public string Status { get; set; }
    }
}
