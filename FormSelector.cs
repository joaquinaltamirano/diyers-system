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
            lblTexto.ForeColor = Color.FromArgb(56, 56, 56);

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
            flowLayoutPanel1.AutoScroll = true;

            lbl_Titulo.Visible = false;
            lbl_Atributo.Text = "DETALLE";

            var producto = nodo.ProductoFinal;

            // PANEL CONTENEDOR 
            Panel card = new Panel();

            card.Width = flowLayoutPanel1.Width - 25;
            card.Height = 220;
            card.BackColor = Color.White;
            card.Margin = new Padding(10, 5, 10, 10);

            // TÍTULOS
            Label lblNombre = new Label();
            lblNombre.Text = ObtenerNombreBase(producto.NombreCompleto).ToUpper();
            lblNombre.Font = new Font("MADE TOMMY", 14, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(40, 40, 140);
            lblNombre.Location = new Point(20, 15);
            lblNombre.AutoSize = true;

            Label lblVariante = new Label();
            lblVariante.Text = ObtenerUltimaParte(producto.NombreCompleto).ToUpper();
            lblVariante.Font = new Font("MADE TOMMY", 12, FontStyle.Bold);
            lblVariante.ForeColor = Color.FromArgb(56, 56, 56);
            lblVariante.Location = new Point(20, 42);
            lblVariante.AutoSize = true;

            // COLUMNAS DE DATOS
            // Columna 1 (Izquierda) 
            card.Controls.Add(CrearCampo("COSTO", "$6453", 20, 90));
            card.Controls.Add(CrearCampo("PRECIO", "$11531", 20, 135));

            // Columna 2 (Derecha)  
            card.Controls.Add(CrearCampo("STOCK", "132", 240, 90));
            card.Controls.Add(CrearCampo("¿ESTÁ EN ML?", "✔", 240, 135, true));

            card.Controls.Add(lblNombre);
            card.Controls.Add(lblVariante);

            flowLayoutPanel1.Controls.Add(card);
        }

        Control CrearCampo(string label, string valor, int x, int y, bool esCheck = false)
        {
            Panel cont = new Panel();
            cont.Size = new Size(210, 35); // Ancho suficiente para que no se corte el valor
            cont.Location = new Point(x, y);

            // Indicador naranja
            Panel bullet = new Panel();
            bullet.Size = new Size(12, 12);
            bullet.BackColor = Color.FromArgb(239, 192, 74);
            bullet.Location = new Point(0, 10);

            // Etiqueta (COSTO, PRECIO, etc)
            Label lbl = new Label();
            lbl.Text = label.ToUpper();
            lbl.Font = new Font("MADE TOMMY", 9, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(56, 56, 56);
            lbl.AutoSize = true;
            lbl.Location = new Point(20, 8);

            // Valor con fondo gris
            Label val = new Label();
            val.Text = valor;
            val.AutoSize = false;
            val.Size = new Size(85, 26);
            val.Location = new Point(115, 4); // Separación entre label y valor
            val.BackColor = Color.FromArgb(225, 227, 232); // Gris suave
            val.TextAlign = ContentAlignment.MiddleCenter;
            val.Font = new Font("MADE TOMMY", 9, FontStyle.Bold);
            val.ForeColor = Color.FromArgb(40, 40, 140);

            if (esCheck)
            {
                val.BackColor = Color.Transparent;
                val.ForeColor = Color.FromArgb(0, 200, 100);
                val.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                val.Location = new Point(115, 0);
            }

            cont.Controls.Add(bullet);
            cont.Controls.Add(lbl);
            cont.Controls.Add(val);

            return cont;
        }

        string ObtenerUltimaParte(string nombre)
        {
            return nombre.Split(' ').Last();
        }

        string ObtenerNombreBase(string nombre)
        {
            var partes = nombre.Split(' ');

            if (partes.Length <= 1)
                return nombre;

            return string.Join(" ", partes.Take(partes.Length - 1));
        }

        #endregion

        #region NAVEGACION

        private void btn_Volver_Click(object sender, EventArgs e)
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

        private void btn_Cerrar_Click(object sender, EventArgs e)
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
            //SI ES DETALLE = ignorar números
            if (nodoActual.EsFinal)
            {
                if (keyData == Keys.Escape)
                {
                    btn_Volver_Click(null, null);
                    return true;
                }

                return base.ProcessCmdKey(ref msg, keyData);
            }

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

            // ESC
            if (keyData == Keys.Escape)
            {
                btn_Volver_Click(null, null);
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

        private void FormSelector_Load(object sender, EventArgs e)
        {

        }
    }
}