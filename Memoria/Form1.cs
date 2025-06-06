﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memoria
{
    public partial class Form1 : Form
    {
        Random random = new Random();   

        List<string> iconos = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        Label primerclick = null;

        Label segundoclick = null;
        public Form1()
        {
            InitializeComponent();
            Asignar(); 
        }
        private void verificaGana()
        {
            // Recorremos todos los controles del TableLayoutPanel
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    // Si encontramos algún label que aún esté oculto (ForeColor != Black)
                    // significa que el juego no ha terminado
                    if (iconLabel.ForeColor != Color.Black)
                    {
                        return; // Salimos del método sin mostrar el mensaje
                    }
                }
            }

            // Si llegamos hasta aquí, significa que todos los iconos están visibles
            MessageBox.Show("¡Felicidades! Has encontrado todas las parejas. Ganaste el juego!",
                            "¡WUUUUU!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        

        private void Clic_sobre_Etiqueta(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

                Label clickedLabel = sender as Label;

                if (clickedLabel != null)
                {
                    if (clickedLabel.ForeColor == Color.Black)
                        return;
                    
                if (primerclick == null)
                {
                    primerclick = clickedLabel;

                    primerclick.ForeColor = Color.Black;
                    return;
                }


                segundoclick = clickedLabel;

                segundoclick.ForeColor = Color.Black;

                if (primerclick.Text == segundoclick.Text)
                {
                    primerclick = null;
                    segundoclick = null;
                    verificaGana();
                    return;
                }
                timer1.Start();
                }
            
        }
        private void Asignar()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int numeroRandom = random.Next(iconos.Count);
                    iconLabel.Text = iconos[numeroRandom];
                    iconos.RemoveAt(numeroRandom);

                    iconLabel.Click += new System.EventHandler(this.Clic_sobre_Etiqueta);
                }
                iconLabel.ForeColor = iconLabel.BackColor;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            primerclick.ForeColor = primerclick.BackColor;
            segundoclick.ForeColor = segundoclick.BackColor;
            primerclick = null;
            segundoclick = null;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
