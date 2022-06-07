using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Barcode { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }

    }
}
