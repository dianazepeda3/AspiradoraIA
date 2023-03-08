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
        int basura, aspiradora;
        Random random = new Random();
        
        public Form1()
        {
            InitializeComponent();
            reset_val();
            evaluar_aspiradora();
            evaluar_basura();
        }
        // public void wait (int seconds)
        // {
        //     var timer1 = new System.Windows.Forms.Timer();
        //     if (seconds == 0 || seconds < 0) return;

        //     timer1.Interval = seconds;
        //     timer1.Enabled = true;
        //     timer1.Start();

        //     timer1.Tick += (s, e) =>
        //     {
        //         timer1.Enabled = false;
        //         timer1.Stop();
        //     };

        //     while (timer1.Enabled)
        //     {
        //         Application.DoEvents();
        //     }
        // }
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
            basura = random.Next(0, 4);
        }

        public void evaluar_aspiradora()
        {
            Thread.Sleep(1000);
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
        }

        public void evaluar_basura()
        {
            Thread.Sleep(1000);
            switch (basura)
            {
                case 0:
                    picBox_Basura1.Visible = false;
                    picBox_Basura2.Visible = false;
                    lblBasura.Text = "- Habitaciones Limpias";
                    break;

                case 1:
                    picBox_Basura1.Visible = true;
                    picBox_Basura2.Visible = false;
                    lblBasura.Text = " - Habitación 1 Sucia";
                    break;

                case 2:
                    picBox_Basura1.Visible = false;
                    picBox_Basura2.Visible = true;
                    lblBasura.Text = " - Habitación 2 Sucia";
                    break;

                case 3:
                    picBox_Basura1.Visible = true;
                    picBox_Basura2.Visible = true;
                    lblBasura.Text = " - Habitaciones Sucias";
                    break;
            }
            Thread.Sleep(1000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset_val();
            evaluar_aspiradora();
            evaluar_basura();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //wait(500);
            //timer1.Start(); // Funcion iniciar Timer
            while(basura != 0)
            {
                if (aspiradora == 0)
                {
                    switch (basura)
                    {
                        case 0:
                           // timer1.Stop();
                            btnValores.Enabled = true;
                            label5.Text = "aspiradora 0 caso 0";
                            break;
                        case 1:
                            basura = 0;
                            label5.Text = "basura aspiradora 0 caso 1";
                            evaluar_basura();
                            break;
                        case 2:
                            aspiradora = 1;
                            label5.Text = "aspiradora - aspiradora 0 caso 2";
                            evaluar_aspiradora();
                            Thread.Sleep(1000);
                            basura = 0;
                            label5.Text = "basura - aspiradora 0 caso 2";
                            evaluar_basura();
                            break;
                        case 3:
                            basura = 2;
                            label5.Text = "basura - aspiradora 0 caso 3";
                            evaluar_basura();
                            Thread.Sleep(1000);
                            aspiradora = 1;
                            label5.Text = "aspiradora - aspiradora 0 caso 3";
                            evaluar_aspiradora();
                            break;
                    }

                }
                else
                {
                    switch (basura)
                    {
                        case 0:
                            //timer1.Stop();
                            btnValores.Enabled = true;
                            label5.Text = "aspiradora 1 caso 0";
                            break;
                        case 1:
                            aspiradora = 0;
                            label5.Text = "aspiradora - aspiradora 1 caso 1";
                            evaluar_aspiradora();
                            Thread.Sleep(1000);
                            basura = 0;
                            label5.Text = "basura - aspiradora 1 caso 1";
                            evaluar_basura();
                            break;
                        case 2:
                            basura = 0;
                            label5.Text = "basura - aspiradora 1 caso 2";
                            evaluar_basura();

                            break;
                        case 3:
                            basura = 1;
                            label5.Text = "basura - aspiradora 1 caso 3";
                            evaluar_basura();
                            Thread.Sleep(1000);
                            aspiradora = 0;
                            label5.Text = "aspiradora - aspiradora 1 caso 3";
                            evaluar_aspiradora();

                            break;
                    }
                    Thread.Sleep(2000);


                }
            }

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {                        
            

        }
    }
}
