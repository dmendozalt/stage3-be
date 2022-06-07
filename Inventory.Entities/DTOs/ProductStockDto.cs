using Inventory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.DTOs
{
    public class ProductStockDto
    {
        public int IdProduct { get; set; }
        public string Unit { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }
    }
}
