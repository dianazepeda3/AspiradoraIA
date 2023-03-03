using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aspiradora_parte_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            reset_val();
        }

        public void reset_val()
        {
            /* Basura
             * -0 Vacio
             * -1 Izquierda
             * -2 Derecha
             * -3 Ambas
             * 
             * Aspiradora
             * -0 Izquierda
             * -1 Derecha
             */
            int basura, aspiradora;
            Random random = new Random();
            basura = random.Next(0, 4);
            aspiradora = random.Next(0, 2);

            if (aspiradora == 0)
            {
                picBox_Aspiradora1.Visible = true;
                picBox_Aspiradora2.Visible = false;
                lblCaract.Text = "Aspiradora en habitación 1";

            }
            else
            {
                picBox_Aspiradora1.Visible = false;
                picBox_Aspiradora2.Visible = true;
                lblCaract.Text = "Aspiradora en habitación 2";
            }

            switch (basura)
            {
                case 0:
                    picBox_Basura1.Visible = false;
                    picBox_Basura2.Visible = false;
                    lblCaract.Text = lblCaract.Text + "- Habitaciones Limpias";
                    break;

                case 1:
                    picBox_Basura1.Visible = true;
                    picBox_Basura2.Visible = false;
                    lblCaract.Text = lblCaract.Text + " - Habitación 1 Sucia";
                    break;

                case 2:
                    picBox_Basura1.Visible = false;
                    picBox_Basura2.Visible = true;
                    lblCaract.Text = lblCaract.Text + " - Habitación 2 Sucia";
                    break;

                case 3:
                    picBox_Basura1.Visible = true;
                    picBox_Basura2.Visible = true;
                    lblCaract.Text = lblCaract.Text + " - Habitaciones Sucias";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset_val();   
        }
        
    }
}
