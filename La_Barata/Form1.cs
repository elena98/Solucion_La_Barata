using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Barata
{
    public partial class Form1 : Form

    {
        string usuario = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int nivel = DatosUsuario.Login(textBox3.Text, textBox4.Text);
            if (nivel > 0)
            {
                inicio Inicio = new inicio (nivel, usuario);
                DatosUsuario.usuario(textBox3.Text, textBox4.Text, Inicio.label1, Inicio.label2);
                Inicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            textBox3.Text = "";
            textBox4.Text = "";



        }
        int posY, posX = 0;

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBox6.Visible = false;
            pictureBox5.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox6.Visible = true;
            pictureBox5.Visible = false;
        }

        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left){posX = e.X;posY = e.Y;}else{Left = Left + (e.X - posX);Top = Top + (e.Y - posY);}
        }
    }
}
