using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinCol.Models
{
    public class FacturaInsumos
    {
        public int FacturaInsumosID { get; set; }
        public int ProveedorID { get; set; }
        public int MaterialID { get; set; }
        public int Cantidad { get; set; }
        public Decimal Costo { get; set; }
        public Proveedor Proveedor { get; set; }
        public Material Material { get; set; }

    }
}
