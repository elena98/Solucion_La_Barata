using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace La_Barata
{
    public partial class Ofertas : Form
    {
        public Ofertas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = funciones.OfertProducts();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string pattern1 = "(^[A-Z/s|a-z/s| ]+$)";
            if (Regex.IsMatch(textBox1.Text, pattern1) == true)
            {

                using (MySqlConnection Conx = conection.Conexion())
                {
                    MySqlCommand cm = new MySqlCommand("Select nombre from producto_inventario", Conx);
                    MySqlDataReader readr = cm.ExecuteReader();
                    AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();

                    while (readr.Read())
                    {
                        // string idProductoInventario = readr.GetString(0);
                        mycollection.Add(readr.GetString(0));

                    }
                    textBox1.AutoCompleteCustomSource = mycollection;
                    Conx.Close();
                }

                

                label7.Text = " ";
               
            }
            else
            {
                label7.ForeColor = Color.Red;
                label7.Text = "Nombre de producto incorrecto.";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = funciones.OFProducts();
        }
    }
}
