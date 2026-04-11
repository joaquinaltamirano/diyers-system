namespace Diyers_System
{
    public partial class form1 : Form
    {
        #region DATOS

        List<Producto> productosRaw = new List<Producto>();
        List<ProductoFamilia> familias = new List<ProductoFamilia>();

        string categoriaSeleccionada = null;

        #endregion

        #region OVERLAY

        Panel overlay;
        Panel modalContainer;
        Panel containerContenido;

        Stack<Nodo> historial = new Stack<Nodo>();
        Nodo nodoActual;

        #endregion

        #region INIT

        public form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;

            listView1.Columns.Add("", 250);
            listView1.Columns.Add("", 50);
            listView1.HeaderStyle = ColumnHeaderStyle.None;

            GenerarDataMock();
            GenerarFamilias();
            FiltrarTodo();

            InicializarOverlay();
        }

        #endregion

        #region OVERLAY SETUP

        void InicializarOverlay()
        {
            overlay = new Panel();
            overlay.Dock = DockStyle.Fill;
            overlay.BackColor = Color.FromArgb(150, 0, 0, 0);
            overlay.Visible = false;

            modalContainer = new Panel();
            modalContainer.Size = new Size(500, 400);
            modalContainer.BackColor = Color.White;

            modalContainer.Location = new Point(
                (this.ClientSize.Width - modalContainer.Width) / 2,
                (this.ClientSize.Height - modalContainer.Height) / 2
            );

            containerContenido = new Panel();
            containerContenido.Dock = DockStyle.Fill;

            modalContainer.Controls.Add(containerContenido);
            overlay.Controls.Add(modalContainer);
            this.Controls.Add(overlay);

            overlay.BringToFront();

            this.Resize += (s, e) =>
            {
                modalContainer.Location = new Point(
                    (this.ClientSize.Width - modalContainer.Width) / 2,
                    (this.ClientSize.Height - modalContainer.Height) / 2
                );
            };
        }

        void CerrarOverlay()
        {
            overlay.Visible = false;
        }

        #endregion

        #region RENDER

        void Render()
        {
            modalContainer.Controls.Clear();
            modalContainer.Controls.Add(containerContenido);

            containerContenido.Controls.Clear();

            if (nodoActual.EsFinal)
                RenderDetalle();
            else
                RenderOpciones();

            RenderBotonesBase();
        }

        void RenderOpciones()
        {
            for (int i = nodoActual.Hijos.Count - 1; i >= 0; i--)
            {
                int index = i;

                Button btn = new Button();
                btn.Text = $"{i + 1}. {nodoActual.Hijos[i].Nombre}";
                btn.Dock = DockStyle.Top;
                btn.Height = 40;

                btn.Click += (s, e) => Seleccionar(index);

                containerContenido.Controls.Add(btn);
            }
        }

        void RenderDetalle()
        {
            var p = nodoActual.ProductoFinal;

            Label lbl = new Label();
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = $"PRODUCTO\n\n{p.NombreCompleto}\n\nPRECIO: ---\nSTOCK: ---";

            containerContenido.Controls.Add(lbl);
        }

        void RenderBotonesBase()
        {
            Button btnClose = new Button();
            btnClose.Text = "X";
            btnClose.Size = new Size(40, 30);
            btnClose.Location = new Point(modalContainer.Width - 45, 5);
            btnClose.Click += (s, e) => CerrarOverlay();

            modalContainer.Controls.Add(btnClose);

            if (historial.Count > 0)
            {
                Button btnBack = new Button();
                btnBack.Text = "← Volver";
                btnBack.Size = new Size(100, 30);
                btnBack.Location = new Point(5, 5);

                btnBack.Click += (s, e) => Volver();

                modalContainer.Controls.Add(btnBack);
            }
        }

        #endregion

        #region NAVEGACION

        void AbrirDetalle()
        {
            if (listView1.SelectedItems.Count == 0) return;

            var familia = (ProductoFamilia)listView1.SelectedItems[0].Tag;

            Nodo raiz = GenerarArbolMock(familia.Nombre);

            historial.Clear();
            nodoActual = raiz;

            overlay.Visible = true;
            overlay.BringToFront();

            Render();
        }

        void Seleccionar(int index)
        {
            if (index >= nodoActual.Hijos.Count) return;

            historial.Push(nodoActual);
            nodoActual = nodoActual.Hijos[index];

            Render();
        }

        void Volver()
        {
            if (historial.Count > 0)
            {
                nodoActual = historial.Pop();
                Render();
            }
            else
            {
                CerrarOverlay();
            }
        }

        #endregion

        #region TECLADO

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!overlay.Visible)
                return base.ProcessCmdKey(ref msg, keyData);

            if (keyData >= Keys.D1 && keyData <= Keys.D9)
            {
                int index = keyData - Keys.D1;
                Seleccionar(index);
                return true;
            }

            if (keyData == Keys.Escape)
            {
                Volver();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region LISTVIEW

        void CargarListView(List<ProductoFamilia> lista)
        {
            listView1.Items.Clear();

            foreach (var f in lista)
            {
                var item = new ListViewItem(f.Nombre);
                item.SubItems.Add("→");
                item.Tag = f;

                listView1.Items.Add(item);
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            int index = listView1.SelectedItems[0].Index;

            if (e.KeyCode == Keys.Up)
            {
                if (index == 0)
                {
                    txt_Busqueda.Focus();
                    listView1.SelectedItems.Clear();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                AbrirDetalle();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            AbrirDetalle();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_Busqueda.Focus();
        }

        #endregion

        #region BUSQUEDA

        void FiltrarTodo()
        {
            var texto = txt_Busqueda.Text.ToLower();

            var filtrados = familias
                .Where(f =>
                    (categoriaSeleccionada == null || f.Categoria == categoriaSeleccionada)
                    && f.Nombre.ToLower().Contains(texto)
                )
                .ToList();

            CargarListView(filtrados);
        }

        private void txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarTodo();
        }

        private void txt_Busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (listView1.Items.Count > 0)
                {
                    listView1.Items[0].Selected = true;
                    listView1.Focus();
                }
            }
        }

        #endregion

        #region CATEGORIAS

        private void btn_Ferreteria_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Ferreteria";
            FiltrarTodo();
            txt_Busqueda.Focus();
        }

        private void btn_Pintura_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Pintura";
            FiltrarTodo();
            txt_Busqueda.Focus();
        }

        private void btn_Maderas_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Maderera";
            FiltrarTodo();
            txt_Busqueda.Focus();
        }

        private void btn_Instalaciones_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Instalaciones";
            FiltrarTodo();
            txt_Busqueda.Focus();
        }

        private void btnConstruccion_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Construccion";
            FiltrarTodo();
            txt_Busqueda.Focus();
        }

        private void btn_Todas_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = null;
            FiltrarTodo();
            txt_Busqueda.Focus();
        }

        #endregion

        #region DATA MOCK

        void GenerarFamilias()
        {
            familias = productosRaw
                .Select(p => new ProductoFamilia
                {
                    Nombre = p.NombreCompleto.Split(' ')[0],
                    Categoria = p.Categoria
                })
                .GroupBy(f => f.Nombre + f.Categoria)
                .Select(g => g.First())
                .ToList();
        }

        void GenerarDataMock()
        {
            productosRaw.Add(new Producto { NombreCompleto = "AEROSOL KUWAIT ROJO 80CC", Categoria = "Pintura" });
            productosRaw.Add(new Producto { NombreCompleto = "TORNILLO PHILIPS 10MM", Categoria = "Ferreteria" });
            productosRaw.Add(new Producto { NombreCompleto = "CAÑO ESTRUCTURAL 20X20", Categoria = "Construccion" });
            productosRaw.Add(new Producto { NombreCompleto = "CABLE 2.5MM ROJO", Categoria = "Instalaciones" });
            productosRaw.Add(new Producto { NombreCompleto = "TABLA PINO 2X4", Categoria = "Maderera" });
        }

        #endregion

        #region ARBOL MOCK

        Nodo GenerarArbolMock(string familia)
        {
            if (familia == "AEROSOL")
                return new Nodo { Nombre = "AEROSOL", Hijos = new List<Nodo> { CrearColor("ROJO"), CrearColor("AZUL") } };

            if (familia == "TORNILLO")
                return new Nodo { Nombre = "TORNILLO", Hijos = new List<Nodo> { CrearTipoTornillo("PHILIPS") } };

            return new Nodo { Nombre = "VACIO" };
        }

        Nodo CrearColor(string color)
        {
            return new Nodo
            {
                Nombre = color,
                Hijos = new List<Nodo>
                {
                    CrearMarca(color, "KUWAIT")
                }
            };
        }

        Nodo CrearMarca(string color, string marca)
        {
            return new Nodo
            {
                Nombre = marca,
                Hijos = new List<Nodo>
                {
                    CrearProductoFinal($"AEROSOL {marca} {color} 80CC")
                }
            };
        }

        Nodo CrearTipoTornillo(string tipo)
        {
            return new Nodo
            {
                Nombre = tipo,
                Hijos = new List<Nodo>
                {
                    CrearProductoFinal($"TORNILLO {tipo} 10MM")
                }
            };
        }

        Nodo CrearProductoFinal(string nombre)
        {
            return new Nodo
            {
                Nombre = nombre,
                EsFinal = true,
                ProductoFinal = new Producto
                {
                    NombreCompleto = nombre
                }
            };
        }

        #endregion
    }
}