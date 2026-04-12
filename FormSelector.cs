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
        #region CAMPOS

        Nodo nodoRaiz;
        Nodo nodoActual;
        Stack<Nodo> historial = new Stack<Nodo>();

        #endregion

        #region INIT

        public FormSelector(Nodo nodo)
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.ActiveControl = null;

            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;

            nodoRaiz = nodo;

            CargarNodo(nodo);
        }

        #endregion

        #region CARGA

        void CargarNodo(Nodo nodo)
        {
            nodoActual = nodo;

            flowLayoutPanel1.Controls.Clear();

            // TITULO (siempre raíz)
            lbl_Titulo.Text = nodoRaiz.Nombre;
            lbl_Titulo.Visible = !nodoActual.EsFinal;

            // ATRIBUTO
            lbl_Atributo.Text = ObtenerAtributo();

            int i = 1;

            foreach (var hijo in nodo.Hijos)
            {
                var btn = CrearFoxButton(hijo, i);
                flowLayoutPanel1.Controls.Add(btn);
                i++;
            }
        }

        string ObtenerAtributo()
        {
            if (nodoActual.EsFinal)
                return "DETALLE";

            int nivel = historial.Count;

            switch (nivel)
            {
                case 0: return "COLOR";
                case 1: return "MARCA";
                case 2: return "MEDIDA";
                default: return "OPCION";
            }
        }

        #endregion

        #region FOX BUTTON

        Control CrearFoxButton(Nodo hijo, int index)
        {
            Panel foxButton = new Panel();
            foxButton.Width = 118;
            foxButton.Height = 45;
            foxButton.Margin = new Padding(10);
            foxButton.BackColor = Color.WhiteSmoke;
            foxButton.BorderStyle = BorderStyle.FixedSingle;
            foxButton.Cursor = Cursors.Hand;
            foxButton.Tag = hijo;

            // 🟨 BLOQUE IZQUIERDO
            Panel panelNumero = new Panel();
            panelNumero.Width = 19;
            panelNumero.Dock = DockStyle.Left;
            panelNumero.BackColor = Color.FromArgb(239, 192, 74);

            // 🔵 NUMERO
            Label lblNumero = new Label();
            lblNumero.Text = index.ToString();
            lblNumero.Dock = DockStyle.Fill;
            lblNumero.TextAlign = ContentAlignment.MiddleCenter;
            lblNumero.Font = new Font("MADE TOMMY", 14, FontStyle.Bold);
            lblNumero.ForeColor = Color.Blue;

            panelNumero.Controls.Add(lblNumero);

            // TEXTO
            Label lblTexto = new Label();
            lblTexto.Text = ObtenerTextoCorto(hijo);
            lblTexto.Dock = DockStyle.Fill;
            lblTexto.TextAlign = ContentAlignment.MiddleLeft;
            lblTexto.Font = new Font("MADE TOMMY", 9, FontStyle.Bold);
            lblTexto.Padding = new Padding(6, 0, 0, 0);

            foxButton.Controls.Add(lblTexto);
            foxButton.Controls.Add(panelNumero);

            // EVENTOS (click en todo)
            foxButton.Click += (s, e) => ClickOpcion(foxButton);
            lblTexto.Click += (s, e) => ClickOpcion(foxButton);
            panelNumero.Click += (s, e) => ClickOpcion(foxButton);
            lblNumero.Click += (s, e) => ClickOpcion(foxButton);

            foxButton.TabStop = false;

            return foxButton;
        }

        void ClickOpcion(Control ctrl)
        {
            var nodo = (Nodo)ctrl.Tag;

            historial.Push(nodoActual);

            if (nodo.EsFinal)
            {
                nodoActual = nodo;
                MostrarDetalle(nodo);
            }
            else
            {
                nodoActual = nodo;
                CargarNodo(nodo);
            }
        }

        #endregion

        #region DETALLE

        void MostrarDetalle(Nodo nodo)
        {

            flowLayoutPanel1.Controls.Clear();

            lbl_Titulo.Visible = false;
            lbl_Atributo.Text = "DETALLE";

            Label lbl = new Label();
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            lbl.Text = $"PRODUCTO\n\n{nodo.ProductoFinal.NombreCompleto}\n\nPRECIO: ---\nSTOCK: ---";

            flowLayoutPanel1.Controls.Add(lbl);
        }

        #endregion

        #region NAVEGACION

        private void btn_Volver_Click_1(object sender, EventArgs e)
        {
            if (historial.Count > 0)
            {
                nodoActual = historial.Pop();
                CargarNodo(nodoActual);
            }
            else
            {
                this.Close();
            }
        }
        private void btn_Cerrar_Click_1(object sender, EventArgs e)
        {
            Form root = this;

            while (root.Owner != null)
                root = root.Owner;

            root.Close();
        }

        #endregion

        #region TECLADO

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData >= Keys.D1 && keyData <= Keys.D9)
            {
                int index = keyData - Keys.D1;

                if (index < flowLayoutPanel1.Controls.Count)
                {
                    var ctrl = flowLayoutPanel1.Controls[index];

                    ctrl.BackColor = Color.Gainsboro;
                    ClickOpcion(ctrl);
                }

                return true;
            }

            if (keyData == Keys.Escape)
            {
                btn_Volver_Click_1(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        string ObtenerTextoCorto(Nodo nodo)
        {
            if (!nodo.EsFinal)
                return nodo.Nombre;

            var partes = nodo.ProductoFinal.NombreCompleto.Split(' ');
            return partes.Last(); // 80CC
        }
    }
}