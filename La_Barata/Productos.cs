using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Barata
{
    class Productos
    {
        //public String idProductoInventario { get; set; }
        public String nombre { get; set; }
        public String cantidad { get; set; }
        public String precio { get; set; }
        public String oferta { get; set; }
        //public String activo { get; set; }

        public Productos() { }

        public Productos( String nombre, String cantidad, String precio, String oferta)
        {
           // this.idProductoInventario = idProductoInventario;
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precio = precio;
            this.oferta = oferta;
           // this.activo = activo;
        }
    }
}
