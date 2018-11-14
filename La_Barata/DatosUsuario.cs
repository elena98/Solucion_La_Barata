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
    class DatosUsuario
    {

        public static int Login(string usuario, string contraseña)
        {
            int retorno = 0;
            using (MySqlConnection Conn = conection.Conexion())
            {
                MySqlCommand cm = new MySqlCommand(string.Format("select usuario, password, activo from usuarios where usuario='{0}' and password='{1}'",
                    usuario, contraseña), Conn);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    retorno = readr.GetInt32(2);
                }
            }
            return retorno;
        }

        public static void usuario(string usuario, string contraseña, Label label1, Label label2)
        {
            using (MySqlConnection Conn = conection.Conexion())
            {
                MySqlCommand cm = new MySqlCommand(string.Format("select nombres, apellidos, activo from usuarios where usuario='{0}' and password='{1}'", usuario, contraseña), Conn);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    label1.Text = readr.GetString(0) + " ";
                    label2.Text = readr.GetString(1) + " ";
                }
            }
        }


    }
}
