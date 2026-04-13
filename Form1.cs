using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Diyers_System
{
    public partial class form1 : Form
    {
        #region CAMPOS

        List<Producto> productosRaw = new();
        List<ProductoFamilia> familias = new();
        List<ProductoFamilia> itemsActuales = new();

        int selectedIndex = -1;
        string categoriaSeleccionada = null;
        bool bloqueandoFiltro = false;

        #endregion

        #region INIT

        public form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_Busqueda.Text = "";
            txt_Busqueda.ForeColor = Color.Black;
            txt_Busqueda.Focus();
            txt_Busqueda.ForeColor = Color.Gray;

            ConfigurarFlow();

            GenerarDataMock();
            GenerarFamilias();
            FiltrarTodo();
        }

        void ConfigurarFlow()
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(0);
        }

        #endregion

        #region LISTADO

        void CargarFlow(List<ProductoFamilia> lista)
        {
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            itemsActuales = lista;

            for (int i = 0; i < lista.Count; i++)
                flowLayoutPanel1.Controls.Add(CrearItem(lista[i], i));

            selectedIndex = -1;

            flowLayoutPanel1.ResumeLayout();

            AjustarAlturaFlow(); // opcional (mejora UX)
        }

        System.Windows.Forms.Panel CrearItem(ProductoFamilia f, int index)
        {
            int scrollWidth = flowLayoutPanel1.VerticalScroll.Visible
                ? SystemInformation.VerticalScrollBarWidth
                : 0;

            System.Windows.Forms.Panel item = new()
            {
                Width = flowLayoutPanel1.ClientSize.Width - scrollWidth - 2,
                Height = 32,
                Margin = new Padding(0, 1, 0, 1),
                Tag = f,
                BackColor = Color.Transparent
            };

            Label lbl = new()
            {
                Text = f.Nombre,
                Height = 32,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(60, 60, 60),
                Dock = DockStyle.Left,
                Width = item.Width - 40 // deja espacio al botón
            };

            var btn = CrearBotonDetalle(f, item);

            item.Click += (s, e) => SeleccionarItem(index);
            lbl.Click += (s, e) => SeleccionarItem(index);

            item.Controls.Add(lbl);
            item.Controls.Add(btn);

            return item;
        }

        ReaLTaiizor.Controls.Button CrearBotonDetalle(ProductoFamilia f, System.Windows.Forms.Panel item)
        {
            var btn = new ReaLTaiizor.Controls.Button();

            btn.Size = new Size(26, 26);

            btn.Location = new Point(item.Width - btn.Width - 16, 3);
            btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btn.InactiveColor = Color.FromArgb(239, 192, 74);
            btn.EnteredColor = Color.FromArgb(44, 30, 155);
            btn.EnteredBorderColor = Color.FromArgb(247, 246, 234);
            btn.BorderColor = Color.FromArgb(247, 246, 234);
            btn.BackColor = Color.FromArgb(247, 246, 234);

            btn.Image = Properties.Resources.flecha;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.Tag = f;
            btn.TabStop = false;

            btn.Click += (s, e) =>
            {
                AbrirDetalleDesdeItem((ProductoFamilia)btn.Tag);
            };

            return btn;
        }

        void SeleccionarItem(int index)
        {
            if (index < 0 || index >= flowLayoutPanel1.Controls.Count) return;

            foreach (Control c in flowLayoutPanel1.Controls)
                c.BackColor = Color.Transparent;

            var item = flowLayoutPanel1.Controls[index];
            item.BackColor = Color.FromArgb(220, 220, 220);

            selectedIndex = index;
        }

        void AbrirDetalleDesdeItem(ProductoFamilia familia)
        {
            bloqueandoFiltro = true;

            Nodo raiz = GenerarArbolMock(familia.Nombre);

            FormSelector fs = new FormSelector(raiz)
            {
                Owner = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(
                    this.Location.X + (this.Width - 500) / 2,
                    this.Location.Y + (this.Height - 400) / 2
                )
            };

            fs.ShowDialog();

            Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y + 1);

            bloqueandoFiltro = false;

            FiltrarTodo();
            ResetUI();
        }

        #endregion

        #region AJUSTE ALTURA (ANTI-SCROLL PRO)

        void AjustarAlturaFlow()
        {
            int totalHeight = 0;

            foreach (Control c in flowLayoutPanel1.Controls)
                totalHeight += c.Height + c.Margin.Vertical;

            int maxAltura = 300;

            flowLayoutPanel1.Height = Math.Min(totalHeight + 5, maxAltura);
            flowLayoutPanel1.AutoScroll = totalHeight > maxAltura;
        }

        #endregion

        #region FILTRO

        void FiltrarTodo()
        {
            string texto = txt_Busqueda.Text.ToLower();

            var filtrados = familias
                .Where(f =>
                    (categoriaSeleccionada == null || f.Categoria == categoriaSeleccionada)
                    && f.Nombre.ToLower().Contains(texto)
                )
                .ToList();

            CargarFlow(filtrados);
        }

        #endregion

        void ResetUI()
        {
            // limpiar selección de lista
            foreach (Control c in flowLayoutPanel1.Controls)
                c.BackColor = Color.Transparent;

            selectedIndex = -1;

            // foco al buscador
            txt_Busqueda.Focus();

            // cursor al final (NO seleccionar todo)
            txt_Busqueda.SelectionStart = txt_Busqueda.Text.Length;
            txt_Busqueda.SelectionLength = 0;
        }

        #region TECLADO

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {
                if (selectedIndex == -1 && flowLayoutPanel1.Controls.Count > 0)
                    SeleccionarItem(0);
                else
                    SeleccionarItem(Math.Min(selectedIndex + 1, flowLayoutPanel1.Controls.Count - 1));

                return true;
            }

            if (keyData == Keys.Up)
            {
                if (selectedIndex <= 0)
                {
                    txt_Busqueda.Focus();
                    txt_Busqueda.SelectionStart = txt_Busqueda.Text.Length;
                    selectedIndex = -1;

                    foreach (Control c in flowLayoutPanel1.Controls)
                        c.BackColor = Color.Transparent;
                }
                else
                {
                    SeleccionarItem(selectedIndex - 1);
                }

                return true;
            }

            if (keyData == Keys.Enter && selectedIndex >= 0)
            {
                var f = (ProductoFamilia)flowLayoutPanel1.Controls[selectedIndex].Tag;
                AbrirDetalleDesdeItem(f);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region MOCK DATA + ARBOLES

        void GenerarDataMock()
        {
            productosRaw.AddRange(new List<Producto>
    {
        new Producto { NombreCompleto = "AEROSOL KUWAIT ROJO 80CC", Categoria = "Pintura" },
        new Producto { NombreCompleto = "LATEX SINTEPLAST BLANCO 20L", Categoria = "Pintura" },
        new Producto { NombreCompleto = "TORNILLO PHILIPS 10MM", Categoria = "Ferreteria" },
        new Producto { NombreCompleto = "TUERCA HEXAGONAL 10MM", Categoria = "Ferreteria" },
        new Producto { NombreCompleto = "CAÑO ESTRUCTURAL 20X20", Categoria = "Construccion" },
        new Producto { NombreCompleto = "PERFIL U 100MM", Categoria = "Construccion" },
        new Producto { NombreCompleto = "CABLE 2.5MM ROJO", Categoria = "Instalaciones" },
        new Producto { NombreCompleto = "TERMICA 20A", Categoria = "Instalaciones" },
        new Producto { NombreCompleto = "TABLA PINO 2M", Categoria = "Maderera" },
        new Producto { NombreCompleto = "FENOLICO 18MM", Categoria = "Maderera" }
    });
        }

        Nodo GenerarArbolMock(string familia)
        {
            return familia switch
            {
                "AEROSOL" => NodoBase("AEROSOL", "MARCA",
                    n => Marca("KUWAIT", n,
                        n2 => Colour("ROJO", n2),
                        n2 => Colour("AZUL", n2)
                    ),
                    n => Marca("SINTEPLAST", n,
                        n2 => Colour("NEGRO", n2),
                        n2 => Colour("BLANCO", n2)
                    )
                ),

                "LATEX" => NodoBase("LATEX", "MARCA",
                    n => Marca("SINTEPLAST", n,
                        n2 => Presentacion("10L", n2),
                        n2 => Presentacion("20L", n2)
                    ),
                    n => Marca("ALBA", n,
                        n2 => Presentacion("4L", n2),
                        n2 => Presentacion("20L", n2)
                    )
                ),

                "TORNILLO" => NodoBase("TORNILLO", "TIPO",
                    n => TipoConMedidas("PHILIPS", n, "6MM", "8MM", "10MM"),
                    n => TipoConMedidas("ALLEN", n, "6MM", "8MM", "10MM"),
                    n => TipoConMedidas("PLANO", n, "6MM", "8MM", "10MM")
                ),

                "TUERCA" => NodoBase("TUERCA", "MEDIDA",
                    n => Medida("8MM", n),
                    n => Medida("10MM", n),
                    n => Medida("12MM", n)
                ),

                "CAÑO" => NodoBase("CAÑO", "TIPO",
                    n => TipoConMedidas("ESTRUCTURAL", n, "20x20", "40x40"),
                    n => TipoConMedidas("REDONDO", n, "1/2", "3/4")
                ),

                "PERFIL" => NodoBase("PERFIL", "TIPO",
                    n => TipoConMedidas("U", n, "80MM", "100MM", "120MM"),
                    n => TipoConMedidas("C", n, "80MM", "100MM")
                ),

                "CABLE" => NodoBase("CABLE", "SECCION",
                    n => CableSeccion("1.5MM", n),
                    n => CableSeccion("2.5MM", n),
                    n => CableSeccion("4MM", n)
                ),

                "TERMICA" => NodoBase("TERMICA", "AMPERAJE",
                    n => Amperaje("10A", n),
                    n => Amperaje("20A", n),
                    n => Amperaje("32A", n)
                ),

                "TABLA" => NodoBase("TABLA", "MADERA",
                    n => Madera("PINO", n),
                    n => Madera("EUCALIPTO", n)
                ),

                "FENOLICO" => NodoBase("FENOLICO", "ESPESOR",
                    n => Espesor("9MM", n),
                    n => Espesor("18MM", n)
                ),

                _ => NodoBase("VACIO", "", null)
            };
        }

        #endregion

        #region HELPERS NODOS

        Nodo NodoBase(string nombre, string atributo, params Func<Nodo, Nodo>[] hijosBuilders)
        {
            var nodo = new Nodo
            {
                Nombre = nombre,
                Atributo = atributo,
                Path = new List<string> { nombre }
            };

            nodo.Hijos = hijosBuilders
                ?.Select(builder => builder(nodo))
                .ToList() ?? new List<Nodo>();

            return nodo;
        }

        Nodo CrearNodo(string nombre, string atributo, Nodo padre)
        {
            return new Nodo
            {
                Nombre = nombre,
                Atributo = atributo,
                Path = new List<string>(padre.Path) { nombre }
            };
        }

        Nodo TipoConMedidas(string nombre, Nodo padre, params string[] medidas)
        {
            var nodo = CrearNodo(nombre, "MEDIDA", padre);

            nodo.Hijos = medidas
                .Select(m => Medida(m, nodo))
                .ToList();

            return nodo;
        }

        Nodo Medida(string nombre, Nodo padre)
        {
            return CrearProductoFinal(nombre, padre);
        }

        Nodo Presentacion(string nombre, Nodo padre)
        {
            return CrearProductoFinal(nombre, padre);
        }

        Nodo Amperaje(string nombre, Nodo padre)
        {
            return CrearProductoFinal(nombre, padre);
        }

        Nodo Espesor(string nombre, Nodo padre)
        {
            return CrearProductoFinal(nombre, padre);
        }

        Nodo CableSeccion(string nombre, Nodo padre)
        {
            var nodo = CrearNodo(nombre, "COLOR", padre);

            nodo.Hijos = new List<Nodo>
    {
        CrearProductoFinal($"{nombre} ROJO", nodo),
        CrearProductoFinal($"{nombre} NEGRO", nodo)
    };

            return nodo;
        }

        Nodo Madera(string nombre, Nodo padre)
        {
            var nodo = CrearNodo(nombre, "LARGO", padre);

            nodo.Hijos = new List<Nodo>
    {
        CrearProductoFinal($"{nombre} 2M", nodo),
        CrearProductoFinal($"{nombre} 3M", nodo)
    };

            return nodo;
        }

        Nodo Marca(string nombre, Nodo padre, params Func<Nodo, Nodo>[] hijos)
        {
            var nodo = CrearNodo(nombre, "COLOR", padre);

            nodo.Hijos = hijos.Select(h => h(nodo)).ToList();

            return nodo;
        }

        Nodo Tipo(string nombre, Nodo padre)
        {
            var nodo = CrearNodo(nombre, "MEDIDA", padre);

            nodo.Hijos = new List<Nodo>
    {
        CrearProductoFinal(nombre, nodo)
    };

            return nodo;
        }

        Nodo Colour(string nombre, Nodo padre)
        {
            var nodo = CrearNodo(nombre, "PRESENTACION", padre);

            nodo.Hijos = new List<Nodo>
    {
        CrearProductoFinal("40CC", nodo),
        CrearProductoFinal("80CC", nodo)
    };

            return nodo;
        }

        Nodo CrearProductoFinal(string nombre, Nodo padre)
        {
            var path = new List<string>(padre.Path) { nombre };

            return new Nodo
            {
                Nombre = nombre,
                EsFinal = true,
                Path = path,
                ProductoFinal = new Producto
                {
                    NombreCompleto = string.Join(" ", path)
                }
            };
        }

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

        #endregion

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


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

        private void txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            if (bloqueandoFiltro) return;

            FiltrarTodo();
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            Form menuPrincipal = Application.OpenForms["menu"];

            if (menuPrincipal != null)
            {
                menuPrincipal.Show(); 
            }

            this.Close();
        }

        private void txt_Busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (flowLayoutPanel1.Controls.Count > 0)
                {
                    SeleccionarItem(0);
                }
            }
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_Busqueda.Text = "";
            categoriaSeleccionada = null;

            FiltrarTodo();
            ResetUI();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Acceso denegado");
        }
    }
}