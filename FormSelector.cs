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

        public FormSelector(Nodo nodo)
        {
            InitializeComponent();
            this.ActiveControl = null;

            this.KeyPreview = true; 
            CargarNodo(nodo);
        }

        void CargarNodo(Nodo nodo)
        {
            nodoActual = nodo;
            flowLayoutPanel1.Controls.Clear();

            int i = 1;

            foreach (var hijo in nodo.Hijos)
            {
                Button btn = new Button();
                btn.Text = $"{i}. {hijo.Nombre}";
                btn.Width = 200;
                btn.Height = 50;
                btn.Tag = hijo;

                btn.TabStop = false; // 🔥 evita foco

                btn.Click += (s, e) =>
                {
                    var seleccionado = (Nodo)btn.Tag;

                    if (seleccionado.EsFinal)
                    {
                        MessageBox.Show(seleccionado.ProductoFinal.NombreCompleto);
                    }
                    else
                    {
                        historial.Push(nodoActual);
                        CargarNodo(seleccionado);
                    }
                };

                flowLayoutPanel1.Controls.Add(btn);
                i++;
            }
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // NÚMEROS (1–9)
            if (keyData >= Keys.D1 && keyData <= Keys.D9)
            {
                int index = keyData - Keys.D1;

                if (index < flowLayoutPanel1.Controls.Count)
                {
                    var btn = (Button)flowLayoutPanel1.Controls[index];
                    btn.PerformClick();
                }

                return true;
            }

            // ESC = volver
            if (keyData == Keys.Escape)
            {
                btn_Volver_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
