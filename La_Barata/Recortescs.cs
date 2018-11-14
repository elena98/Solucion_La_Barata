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
    public partial class Recortescs : Form
    {
        ///String suma;
        public Recortescs()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Recortescs_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int control = funciones.SearchRec();
            if(control !=0  )
            {
                dataGridView1.DataSource = funciones.SearchRecorte();
                string datos= funciones.SumVentas();
                label3.Text = datos + " ";
            
            } 

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //funciones.SumVentas();

  int control = funciones.SearchRec();
            funciones.DeleteRec();

          


        }
    }
}
