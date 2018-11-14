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
    public partial class Inventario : Form
    {
        int aprovacion;
        String Producto = "";
        String Cantidad = "";
        String Precio = "";
        Int32 Cant = 0;
        Int32 Prec = 0;
        int a, b, c,va = 0;

        public Inventario()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Inventario_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            va = a + b + c;
            if (va == 4)
            {
                int resultado = funciones.AddProduct(textBox1.Text, textBox2.Text, textBox3.Text);
                if (resultado > 0)
                {
                    dataGridView1.DataSource = funciones.SearchProducts();
                }
            }
            if (va == 2)
            {
                int resultado = funciones.AddProduct(textBox1.Text, textBox2.Text, textBox3.Text);
                if (resultado > 0)
                {
                    
                }
            }



                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            
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

                    //////////////////Select nombre from producto_inventario



                    label7.Text = " ";
                a = 1;
            }
            else
            {
                label7.ForeColor = Color.Red;
                label7.Text = "Nombre de producto incorrecto.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = funciones.SearchProducts();
            /*  int resultado = funciones.SerachProduct(textBox1.Text, textBox2.Text, textBox3.Text);
              if (resultado > 0)
              {
                  dataGridView1.DataSource = funciones.SearchProducts();
              }
              textBox1.Text = "";
              textBox2.Text = "";
              textBox3.Text = "";*/

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Producto = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Cantidad = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Precio = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            int retorno = funciones.UpdateProduct(Producto, Cantidad, Precio);

            Cant = Convert.ToInt32(Cantidad);
            Prec = Convert.ToInt32(Precio);

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int resultado = funciones.DeleteProduct(textBox1.Text);
            if (resultado > 0)
            {
                dataGridView1.DataSource = funciones.SearchProducts();
            }
            textBox1.Text = "";


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string pattern2 = "(^[0-9|.| ]+$)";
            if (Regex.IsMatch(textBox2.Text, pattern2) == true)
            {
                label7.Text = " ";
                b = 1;
            }
            else
            {
                label7.ForeColor = Color.Red;
                label7.Text = "Dato incorrecto.";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string pattern3 = "(^[0-9|.| ]+$)";
            if (Regex.IsMatch(textBox3.Text, pattern3) == true)
            {
                label7.Text = " ";
                c = 2;
            }
            else
            {
                label7.ForeColor = Color.Red;
                label7.Text = "Precio incorrecto.";
            }
        }
    }
}
