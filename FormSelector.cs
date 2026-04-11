using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diyers_System
{
    public partial class FormSelector : Form
    {
        Nodo nodoActual;
        Stack<Nodo> historial = new Stack<Nodo>();

        void CargarNodo(Nodo nodo)
        {
            nodoActual = nodo;
            panel1.Controls.Clear();

            foreach (var hijo in nodo.Hijos)
            {
                Button btn = new Button();
                btn.Text = hijo.Nombre;
                btn.Width = 200;
                btn.Height = 40;
                btn.Top = panel1.Controls.Count * 50;

                btn.Click += (s, e) =>
                {
                    if (hijo.EsFinal)
                    {
                        MessageBox.Show(hijo.ProductoFinal.NombreCompleto);
                    }
                    else
                    {
                        historial.Push(nodoActual);
                        CargarNodo(hijo);
                    }
                };

                panel1.Controls.Add(btn);
            }
        }

        public FormSelector(Nodo nodo)
        {
            InitializeComponent();
            CargarNodo(nodo);
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            if (historial.Count > 0)
            {
                var anterior = historial.Pop();
                CargarNodo(anterior);
            }
            else
            {
                this.Close();
            }
        }
    }
}
