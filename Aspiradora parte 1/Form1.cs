using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aspiradora_parte_1
{
    public partial class Form1 : Form
    {
        //int num = 0;
        int basura, aspiradora, costo=0;
        string url = "C:\\Users\\diana\\OneDrive\\Escritorio\\8vo semestre\\Inteligencia Artificial\\Aspiradora-parte1\\img\\";
        Random random = new Random();
        
        public Form1()
        {
            InitializeComponent();
            reset_val();
            evaluar_aspiradora();
            evaluar_basura();
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
            
            aspiradora = random.Next(0, 2);
            basura = random.Next(1, 4);
        }

        public void evaluar_aspiradora()
        {            
            if (aspiradora == 0)
            {
                picBox_Aspiradora1.Image = Image.FromFile(url+"aspiradora.png");
                picBox_Aspiradora2.Image = null;
                lblCaract.Text = "Aspiradora en habitación 1";

            }
            else
            {
                picBox_Aspiradora2.Image = Image.FromFile(url+"aspiradora.png");
                picBox_Aspiradora1.Image = null;
                lblCaract.Text = "Aspiradora en habitación 2";
            }
            Thread.Sleep(2000);
        }
        public void limpio(Boolean i)
        {
            if (i) { 
                picBox_Basura1.Image = Image.FromFile(url + "clean.png");
            }
            else
            {
                picBox_Basura2.Image = Image.FromFile(url + "clean.png");
            }
            Thread.Sleep(2000);
        }

        public void evaluar_basura()
        {
            switch (basura)
            {
                case 0:
                    picBox_Basura1.Image = null;
                    picBox_Basura2.Image = null;
                    lblBasura.Text = "Habitaciones Limpias";
                    break;

                case 1:                 
                    picBox_Basura1.Image = Image.FromFile(url+"basura.png");
                    picBox_Basura2.Image = null;
                    lblBasura.Text = "Habitación 1 Sucia";
                    break;

                case 2: 
                    picBox_Basura2.Image = Image.FromFile(url + "basura.png");
                    picBox_Basura1.Image = null;
                    lblBasura.Text = "Habitación 2 Sucia";
                    break;

                case 3:                    
                    picBox_Basura1.Image = Image.FromFile(url + "basura.png");
                    picBox_Basura2.Image = Image.FromFile(url + "basura.png");
                    lblBasura.Text = "Habitaciones Sucias";
                    break;
            }
            
            Thread.Sleep(2000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset_val();
            evaluar_aspiradora();
            evaluar_basura();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start(); // Funcion iniciar Timer            
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (aspiradora == 0)
            {
                switch (basura)
                {
                    case 0:
                        timer1.Stop();
                        btnValores.Enabled = true;
                        lblEstadoA.Text = "Nada     -    Costo: " + costo;
                        break;
                    case 1:
                        basura = 0;
                        costo += 2;
                        lblEstadoA.Text = "Aspirando +2     -     Costo: " + costo;
                        limpio(true);
                        //evaluar_basura();
                        break;
                    case 2:
                        aspiradora = 1;
                        costo++;
                        lblEstadoA.Text = "Moviendo +1     -    Costo: " + costo;
                        evaluar_aspiradora();
                        break;
                    case 3:
                        basura = 2;
                        costo += 2;
                        lblEstadoA.Text = "Aspirando +2     -    Costo: " + costo;
                        limpio(true);
                        //evaluar_basura();
                        break;
                }
            }
            else
            {
                switch (basura)
                {
                    case 0:
                        timer1.Stop();
                        btnValores.Enabled = true;
                        lblEstadoA.Text = "Nada     -     Costo: " + costo;
                        break;
                    case 1:
                        aspiradora = 0;
                        costo++;
                        lblEstadoA.Text = "Moviendo +1     -     Costo: " + costo;
                        evaluar_aspiradora();
                        break;
                    case 2:
                        basura = 0;
                        costo += 2;
                        lblEstadoA.Text = "Aspirando +2     -     Costo: " + costo;
                        limpio(false);
                        //evaluar_basura();
                        break;
                    case 3:
                        basura = 1;
                        costo += 2;
                        lblEstadoA.Text = "Aspirando +2     -     Costo: " + costo;
                        limpio(false);
                        //evaluar_basura();                       
                        break;
                }


            }

            

        }
    }
}
