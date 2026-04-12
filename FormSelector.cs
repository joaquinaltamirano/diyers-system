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

            KeyPreview = true;
            ActiveControl = null;

            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;

            nodoRaiz = nodo;

            CargarNodo(nodo);
        }

        #endregion

        #region CARGA

        void CargarNodo(Nodo nodo)
        {
            nodoActual = nodo;

            flowLayoutPanel1.Controls.Clear();

            lbl_Titulo.Text = nodoRaiz.Nombre;
            lbl_Titulo.Visible = !nodoActual.EsFinal;

            lbl_Atributo.Text = ObtenerAtributo();

            int i = 1;

            foreach (var hijo in nodo.Hijos)
            {
                flowLayoutPanel1.Controls.Add(CrearFoxButton(hijo, i));
                i++;
            }
        }

        string ObtenerAtributo()
        {
            if (nodoActual.EsFinal)
                return "DETALLE";

            return historial.Count switch
            {
                0 => "COLOR",
                1 => "MARCA",
                2 => "MEDIDA",
                _ => "OPCIÓN"
            };
        }

        #endregion

        #region FOX BUTTON

        Control CrearFoxButton(Nodo hijo, int index)
        {
            Panel btn = new Panel
            {
                Width = 150,
                Height = 60,
                Margin = new Padding(10),
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = hijo
            };

            Panel bloque = new Panel
            {
                Width = 35,
                Dock = DockStyle.Left,
                BackColor = Color.Gold
            };

            Label lblNum = new Label
            {
                Text = index.ToString(),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.Blue
            };

            bloque.Controls.Add(lblNum);

            Label lblTexto = new Label
            {
                Text = ObtenerTextoCorto(hijo),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Padding = new Padding(6, 0, 0, 0)
            };

            btn.Controls.Add(lblTexto);
            btn.Controls.Add(bloque);

            btn.Click += (s, e) => ClickOpcion(btn);
            lblTexto.Click += (s, e) => ClickOpcion(btn);
            bloque.Click += (s, e) => ClickOpcion(btn);
            lblNum.Click += (s, e) => ClickOpcion(btn);

            btn.TabStop = false;

            return btn;
        }

        void ClickOpcion(Control ctrl)
        {
            var nodo = (Nodo)ctrl.Tag;

            historial.Push(nodoActual);

            nodoActual = nodo;

            if (nodo.EsFinal)
                MostrarDetalle(nodo);
            else
                CargarNodo(nodo);
        }

        string ObtenerTextoCorto(Nodo nodo)
        {
            if (!nodo.EsFinal)
                return nodo.Nombre;

            return nodo.ProductoFinal.NombreCompleto.Split(' ').Last();
        }

        #endregion

        #region DETALLE

        void MostrarDetalle(Nodo nodo)
        {
            flowLayoutPanel1.Controls.Clear();

            lbl_Titulo.Visible = false;
            lbl_Atributo.Text = "DETALLE";

            var nombre = ObtenerNombreBase(nodo.ProductoFinal.NombreCompleto);
            var variante = ObtenerUltimaParte(nodo.ProductoFinal.NombreCompleto);

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;

            flowLayoutPanel1.Controls.Add(CrearLabelTitulo(nombre));
            flowLayoutPanel1.Controls.Add(CrearLabelSub(variante));

            flowLayoutPanel1.Controls.Add(CrearCampo("COSTO", "$6453"));
            flowLayoutPanel1.Controls.Add(CrearCampo("PRECIO", "$11531"));
            flowLayoutPanel1.Controls.Add(CrearCampo("PRECIO ML", "$14564"));
            flowLayoutPanel1.Controls.Add(CrearCampo("STOCK", "132"));
            flowLayoutPanel1.Controls.Add(CrearCampo("EN ML", "✔"));
        }

        Control CrearLabelTitulo(string texto)
        {
            return new Label
            {
                Text = texto,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 140),
                AutoSize = true,
                Margin = new Padding(10, 20, 10, 5)
            };
        }

        Control CrearLabelSub(string texto)
        {
            return new Label
            {
                Text = texto,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(10, 0, 10, 15)
            };
        }

        Control CrearCampo(string label, string valor)
        {
            Panel cont = new Panel
            {
                Width = 300,
                Height = 30,
                Margin = new Padding(10, 5, 10, 5)
            };

            Label lbl = new Label
            {
                Text = label,
                Width = 120,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label val = new Label
            {
                Text = valor,
                BackColor = Color.Gainsboro,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(130, 3),
                Size = new Size(100, 24)
            };

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
            return string.Join(" ", partes.Take(partes.Length - 1));
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
                Close();
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
    }
}