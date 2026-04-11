namespace Diyers_System
{
    public partial class form1 : Form
    {
        List<Producto> productosRaw = new List<Producto>();
        List<ProductoFamilia> familias = new List<ProductoFamilia>();

        string categoriaSeleccionada = null;

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

        public form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Dolar.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;

            listView1.Columns.Add("", 250);
            listView1.Columns.Add("", 50);

            GenerarDataMock();
            GenerarFamilias();
            FiltrarTodo();
        }

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

        void AbrirDetalle()
        {
            if (listView1.SelectedItems.Count == 0) return;

            var familia = (ProductoFamilia)listView1.SelectedItems[0].Tag;

            Nodo raiz = GenerarArbolMock(familia.Nombre);

            FormSelector fs = new FormSelector(raiz);
            fs.ShowDialog();
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

        void GenerarDataMock()
        {
            // PINTURA
            productosRaw.Add(new Producto { NombreCompleto = "AEROSOL KUWAIT ROJO 80CC", Categoria = "Pintura" });
            productosRaw.Add(new Producto { NombreCompleto = "AEROSOL KUWAIT AZUL 60CC", Categoria = "Pintura" });
            productosRaw.Add(new Producto { NombreCompleto = "LATEX INTERIOR BLANCO 20L", Categoria = "Pintura" });
            productosRaw.Add(new Producto { NombreCompleto = "ESMALTE SINTETICO NEGRO 4L", Categoria = "Pintura" });

            // FERRETERIA
            productosRaw.Add(new Producto { NombreCompleto = "TORNILLO PHILIPS 10MM", Categoria = "Ferreteria" });
            productosRaw.Add(new Producto { NombreCompleto = "TORNILLO PLANO 8MM", Categoria = "Ferreteria" });
            productosRaw.Add(new Producto { NombreCompleto = "TUERCA HEXAGONAL 10MM", Categoria = "Ferreteria" });
            productosRaw.Add(new Producto { NombreCompleto = "ARANDELA 8MM", Categoria = "Ferreteria" });

            // CONSTRUCCION
            productosRaw.Add(new Producto { NombreCompleto = "CAÑO ESTRUCTURAL 20X20", Categoria = "Construccion" });
            productosRaw.Add(new Producto { NombreCompleto = "CAÑO ESTRUCTURAL 40X40", Categoria = "Construccion" });
            productosRaw.Add(new Producto { NombreCompleto = "PERFIL U 100MM", Categoria = "Construccion" });

            // INSTALACIONES
            productosRaw.Add(new Producto { NombreCompleto = "CABLE 2.5MM ROJO", Categoria = "Instalaciones" });
            productosRaw.Add(new Producto { NombreCompleto = "CABLE 4MM NEGRO", Categoria = "Instalaciones" });
            productosRaw.Add(new Producto { NombreCompleto = "TERMICA 20A", Categoria = "Instalaciones" });

            // MADERERA 
            productosRaw.Add(new Producto { NombreCompleto = "TABLA PINO 2X4", Categoria = "Maderera" });
            productosRaw.Add(new Producto { NombreCompleto = "FENOLICO 18MM", Categoria = "Maderera" });
            productosRaw.Add(new Producto { NombreCompleto = "LISTON EUCALIPTO 3M", Categoria = "Maderera" });
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

        private void btn_Ferreteria_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Ferreteria";
            FiltrarTodo();
            txt_Busqueda.Focus();
        }

        private void btnPintura_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Pintura";
            FiltrarTodo();
            txt_Busqueda.Focus();
        }

        private void btn_Maderera_Click(object sender, EventArgs e)
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

        private void btn_Construccion_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Construccion";
            FiltrarTodo();
            txt_Busqueda.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            categoriaSeleccionada = null;
            FiltrarTodo();
            txt_Busqueda.Focus();
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

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_Busqueda.Focus();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
