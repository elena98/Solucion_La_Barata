using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace La_Barata
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
        int x;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox6.Text== textBox7.Text)
            {
                int resultado = funciones.AddUser(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
                if (resultado > 0)
                {

                }
            }
            else
            {
                MessageBox.Show("Error altratar registrar usuario"+"  "+textBox1.Text);
            }
           
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string pattern1 = "(^[A-Z/s|a-z/s| ]+$)";
            if (Regex.IsMatch(textBox1.Text, pattern1) == true)
            {
                label10.Text = " ";
            }
            else
            {
                label10.ForeColor = Color.Red;
                label10.Text = "Nombre de usuario incorrecto.";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string pattern2 = "(^[A-Z/s|a-z/s| ]+$)";
            if (Regex.IsMatch(textBox2.Text, pattern2) == true)
            {
                label10.Text = " ";

            }
            else
            {
                label10.ForeColor = Color.Red;
                label10.Text = "Nombre incorrecto.";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string pattern3 = "(^[A-Z/s|a-z/s| ]+$)";
            if (Regex.IsMatch(textBox3.Text, pattern3) == true)
            {
                label10.Text = " ";
            }
            else
            {
                label10.ForeColor = Color.Red;
                label10.Text = "Apellidos incorrecto.";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string pattern4 = "(^[0-9]+$)";
            if (Regex.IsMatch(textBox4.Text, pattern4) == true)
            {
                label10.Text = " ";
            }
            else
            {
                label10.ForeColor = Color.Red;
                label10.Text = "Numero incorrecto.";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string pattern6 = "(^[A-Z/s|a-z/s|_|@|-|#|*]+$)";
            if (Regex.IsMatch(textBox6.Text, pattern6) == true)
            {
                label10.Text = " ";
            }
            else
            {
                label10.ForeColor = Color.Red;
                label10.Text = "Contraseña incorrecto.";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string pattern7 = "(^[A-Z/s|a-z/s|_|@|-|#|*|]+$)";
            if (Regex.IsMatch(textBox7.Text, pattern7) == true)
            {
                label10.Text = " ";
            }
            else
            {
                label10.ForeColor = Color.Red;
                label10.Text = "Contraseña incorrecto.";
            }
            if (textBox6.Text != textBox7.Text)
            {
                label10.Text = "Las contraseñas nocoinsiden.";
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
