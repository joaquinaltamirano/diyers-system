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
            flowLayoutPanel1.Controls.Clear();
            itemsActuales = lista;

            for (int i = 0; i < lista.Count; i++)
                flowLayoutPanel1.Controls.Add(CrearItem(lista[i], i));

            selectedIndex = -1;
        }

        System.Windows.Forms.Panel CrearItem(ProductoFamilia f, int index)
        {
            System.Windows.Forms.Panel item = new()
            {
                Width = flowLayoutPanel1.ClientSize.Width - 5,
                Height = 32,
                Margin = new Padding(0, 1, 0, 1),
                Tag = f,
                BackColor = Color.Transparent
            };

            Label lbl = new()
            {
                Text = f.Nombre,
                Width = item.Width - 45,
                Height = 32,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(60, 60, 60)
            };

            var btn = CrearBotonDetalle(f);

            item.Click += (s, e) => SeleccionarItem(index);
            lbl.Click += (s, e) => SeleccionarItem(index);

            item.Controls.Add(lbl);
            item.Controls.Add(btn);

            return item;
        }

        ReaLTaiizor.Controls.Button CrearBotonDetalle(ProductoFamilia f)
        {
            var btn = new ReaLTaiizor.Controls.Button();

            btn.Size = new Size(26, 26);
            btn.Location = new Point(flowLayoutPanel1.ClientSize.Width - 35, 3);

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
            // Agregá más acá para probar el scroll...
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

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Nodo GenerarArbolMock(string familia)

        {

            if (familia == "AEROSOL")

            {

                return new Nodo

                {

                    Nombre = "AEROSOL",

                    Hijos = new List<Nodo>

            {

                CrearColor("ROJO"),

                CrearColor("AZUL"),

                CrearColor("VERDE")

            }

                };

            }



            if (familia == "TORNILLO")

            {

                return new Nodo

                {

                    Nombre = "TORNILLO",

                    Hijos = new List<Nodo>

            {

                CrearTipoTornillo("PHILIPS"),

                CrearTipoTornillo("PLANO"),

                CrearTipoTornillo("ALLEN")

            }

                };

            }



            if (familia == "CAÑO")

            {

                return new Nodo

                {

                    Nombre = "CAÑO",

                    Hijos = new List<Nodo>

            {

                CrearMedidaCaño("20x20"),

                CrearMedidaCaño("40x40"),

                CrearMedidaCaño("60x40")

            }

                };

            }



            if (familia == "TABLA")

            {

                return new Nodo

                {

                    Nombre = "TABLA",

                    Hijos = new List<Nodo>

            {

                CrearMadera("PINO"),

                CrearMadera("EUCALIPTO"),

                CrearMadera("CEDRO")

            }

                };

            }



            return new Nodo { Nombre = "VACIO" };

        }

        Nodo CrearColor(string color)

        {

            return new Nodo

            {

                Nombre = color,

                Hijos = new List<Nodo>

        {

            CrearMarca(color, "KUWAIT"),

            CrearMarca(color, "SINTEPLAST")

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

            CrearProductoFinal($"AEROSOL {marca} {color} 40CC"),

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

            CrearProductoFinal($"TORNILLO {tipo} 8MM"),

            CrearProductoFinal($"TORNILLO {tipo} 10MM")

        }

            };

        }



        Nodo CrearMedidaCaño(string medida)

        {

            return new Nodo

            {

                Nombre = medida,

                Hijos = new List<Nodo>

        {

            CrearProductoFinal($"CAÑO ESTRUCTURAL {medida}"),

        }

            };

        }



        Nodo CrearMadera(string tipo)

        {

            return new Nodo

            {

                Nombre = tipo,

                Hijos = new List<Nodo>

        {

            CrearProductoFinal($"TABLA {tipo} 2M"),

            CrearProductoFinal($"TABLA {tipo} 3M")

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

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {

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
    }
}