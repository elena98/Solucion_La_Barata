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
        int a, b, c, va = 0;
        public Ofertas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            va = a + b;

            if (va >= 3) {
               int Dato = funciones.AddOfert(textBox1.Text, textBox2.Text);
                if (Dato > 0)
                {
                    dataGridView1.DataSource = funciones.OfertProducts();
                
                }
  

            }
            if (va == 1)
            {
                MessageBox.Show("ERROR..");
            }
 

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string pattern3 = "(^[0-9|.| ]+$)";
            if (Regex.IsMatch(textBox2.Text, pattern3) == true)
            {
                label7.Text = " ";
                b = 1;
            }
            else
            {
                label7.ForeColor = Color.Red;
                label7.Text = "Precio incorrecto.";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Dato = funciones.DeleteOfert(textBox1.Text);
            if (Dato > 0)
            {
                dataGridView1.DataSource = funciones.OfertProducts();
            }
        }

        private void Ofertas_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
                int Dato = funciones.ActiveOfert(textBox1.Text);
            if (Dato > 0)
            {
                dataGridView1.DataSource = funciones.OfertProducts();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = funciones.SearchProducts();
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
                    a = 2;
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
             dataGridView1.DataSource = funciones.OfertProducts();
        }
    }
}
