using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Barata
{
    class funciones
    {
        public static int AddProduct(string nombreP, string cantidadP, string precioPk)
        {
            int retorno = 0;
            string nombre = nombreP;
            string cantidad = cantidadP;
            string precio = precioPk;
            using (MySqlConnection Conn = conection.Conexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format(
                   "Insert Into producto_inventario (nombre, cantidad, precio) values ('{0}', '{1}','{2}')",
                    nombre, cantidad, precio), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;

        }

        public static List<Productos> SearchProducts()
        {

            List<Productos> Lista = new List<Productos>();
            using (MySqlConnection Conx = conection.Conexion())
            {
                MySqlCommand cm = new MySqlCommand("select nombre, cantidad, precio from producto_inventario", Conx);
                MySqlDataReader readr = cm.ExecuteReader();

                while (readr.Read())
                {
                   // string idProductoInventario = readr.GetString(0);
                    string nombre = readr.GetString(0);
                    string cantidad = readr.GetString(1);
                    string precio = readr.GetString(2);
  
                    Productos pProducto = new Productos();
                    //pProducto.idProductoInventario = idProductoInventario;
                    pProducto.nombre = nombre;
                    pProducto.cantidad = cantidad;
                    pProducto.precio = precio;

                    Lista.Add(pProducto);
                }
                Conx.Close();
                return Lista;
            }

        }


        public static List<Productos> OfertProducts()
        {

            List<Productos> Lista = new List<Productos>();
            using (MySqlConnection Conx = conection.Conexion())
            {
                MySqlCommand cm = new MySqlCommand("select nombre, cantidad, oferta precio from producto_inventario where activo = 0", Conx);
                MySqlDataReader readr = cm.ExecuteReader();

                while (readr.Read())
                {
                    string nombre = readr.GetString(0);
                    string cantidad = readr.GetString(1);
                    string precio = readr.GetString(2);
                    string oferta = readr.GetString(3);

                    Productos pProducto = new Productos();
                    pProducto.nombre = nombre;
                    pProducto.cantidad = cantidad;
                    pProducto.precio = precio;
                    pProducto.oferta = oferta;

                    Lista.Add(pProducto);
                }
                Conx.Close();
                return Lista;
            }

        }



        public static int AddUser(string usuarioR, string nombresR, string apellidosR, string telefonoR, string activoR, string passwordR)
        {
            int retorno = 0;
            string usuario = usuarioR;
            string nombres = nombresR;
            string apellidos = apellidosR;
            string telefono = telefonoR;
            string activo = activoR;
            string password = passwordR;

            using (MySqlConnection Conn = conection.Conexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format(
                   "Insert Into usuarios (usuario, password, apellidos, nombres, telefono, activo) values ('{0}', '{1}','{2}','{3}','{4}','{5}')",
                    usuario, password, apellidos, nombres, telefono, activo), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;

        }

        public static int UpdateProduct(String Producto, String Cantidad, String Precio)
        {
            
            int retorno = 0;
            //String Proc = Producto;
            Int64 Cant = Int64.Parse(Cantidad);
            Int64 Prec = Int64.Parse(Precio);
            using (MySqlConnection Conn = conection.Conexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("Update producto_inventario set nombre='{0}',cantidad='{1}',precio='{2}' where nombre = '{0}'", Producto, Cant, Prec), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();

            }
            return retorno;

        }

        public static int DeleteProduct(String Producto)
        {
            int retorno = 0;
            String producto =Producto;
            using (MySqlConnection Conn = conection.Conexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("delete from producto_inventario where nombre = '{0}'", producto), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();

            }
            return retorno;


        }

        public static List<Recortes> SearchRecorte(){

            List<Recortes> Lista = new List<Recortes>();
            using (MySqlConnection Conx = conection.Conexion())
            {
                MySqlCommand cm = new MySqlCommand("select v.total, u.nombres, u.apellidos from ventas v, usuarios u where v.activo = 1 and v.idUsuario = u.idUsuario ", Conx);
                MySqlDataReader readr = cm.ExecuteReader();

                while (readr.Read())
                {
                    // string idProductoInventario = readr.GetString(0);
                    string total = readr.GetString(0);
                    string nombres = readr.GetString(1);
                    string apellidos = readr.GetString(2);

                    Recortes pRecortes = new Recortes();
                    pRecortes.total = total;
                    pRecortes.nombres = nombres;
                    pRecortes.apellidos = apellidos;   

                    Lista.Add(pRecortes);
                }
                Conx.Close();
                return Lista;
            }
        }

        public static string SumVentas()
        {
            
            string retorno;
            string total;
           // int activo = 1;
            using (MySqlConnection Conn = conection.Conexion())
            {
            
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("select SUM(total) from ventas where activo = 1"), Conn);
                MySqlDataReader readr = Comando.ExecuteReader();
                readr.Read();
                
                total = readr.GetString(0);
                retorno = total + " " ;
                readr.Close();
                Conn.Close();

            }
            return retorno;


        }


        public static int DeleteRec()
        {
            int retorno = 0;
            using (MySqlConnection Conn = conection.Conexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("Update ventas set activo = 0 where activo = 1"), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;

        }

        public static int SearchRec()
        {
            int retorno;
            using (MySqlConnection Conn = conection.Conexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("select * from ventas where activo = 1"), Conn);
                retorno = Comando.ExecuteNonQuery();
                Console.WriteLine("-----------aqiooo-------------");
                Console.WriteLine(retorno);
                Console.WriteLine("-----------aqiooo-------------");

                Conn.Close();

            }
            return retorno;

        }

        public static int addRecorte(string nombreP, string cantidadP, string precioPk)
        { 
            int retorno = 0;
            string nombre = nombreP;
            string cantidad = cantidadP;
            string precio = precioPk;
            using (MySqlConnection Conn = conection.Conexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format(
                   "Insert Into producto_inventario (nombre, cantidad, precio) values ('{0}', '{1}','{2}')",
                    nombre, cantidad, precio), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;

        }



        public static List<Productos> OFProducts()
        {

            List<Productos> Lista = new List<Productos>();
            using (MySqlConnection Conx = conection.Conexion())
            {
                MySqlCommand cm = new MySqlCommand("select nombre, cantidad, precio, oferta from producto_inventario where activo = 0 ", Conx);
                MySqlDataReader readr = cm.ExecuteReader();

                while (readr.Read())
                {
                    // string idProductoInventario = readr.GetString(0);
                    string nombre = readr.GetString(0);
                    string cantidad = readr.GetString(1);
                    string precio = readr.GetString(2);
                    string oferta = readr.GetString(3);

                    Productos pProducto = new Productos();
                    //pProducto.idProductoInventario = idProductoInventario;
                    pProducto.nombre = nombre;
                    pProducto.cantidad = cantidad;
                    pProducto.precio = precio;
                    pProducto.oferta = oferta;

                    Lista.Add(pProducto);
                }
                Conx.Close();
                return Lista;
            }

        }



    }
}
