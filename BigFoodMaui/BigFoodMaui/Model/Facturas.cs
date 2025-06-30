using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFoodMaui.Model
{
    //Clase Factura con sus atributos
    public class Facturas
    {
        public int numero { get; set; }
        public DateTime Fecha { get; set; }
        public string codCliente { get; set; }
        public decimal subtotal { get; set; }
        public decimal montoDescuento { get; set; }
        public decimal montoImpuesto { get; set; }
        public decimal total { get; set; }
        public string estado { get; set; }
        public string usuario { get; set; }
        public string tipoPago { get; set; }
        public string condicion { get; set; }
    }
}
