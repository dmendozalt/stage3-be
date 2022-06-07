using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class Movement
    {
        public int IdMovement { get; set; }
        public int IdProduct { get; set; }
        public int Qty { get; set; }
        public DateTime Date { get; set; }
        public string Concept { get; set; }
        public string Status { get; set; }
        public int Type { get; set; }
    }
}
