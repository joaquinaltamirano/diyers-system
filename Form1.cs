namespace Diyers_System
{
    public partial class Form1 : Form
    {
        List<Producto> productosRaw = new List<Producto>();
        List<ProductoFamilia> familias = new List<ProductoFamilia>();

        string categoriaSeleccionada = null;
        public Form1()
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
            listView1.Columns.Add("Producto", 250);
            listView1.Columns.Add("", 50);

            GenerarDataMock();
            GenerarFamilias();
            FiltrarTodo();

            MessageBox.Show(listView1.Items.Count.ToString());

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

            MessageBox.Show(familia.Nombre);
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
            productosRaw.Add(new Producto { NombreCompleto = "AEROSOL KUWAIT ROJO 80CC", Categoria = "Pintura" });
            productosRaw.Add(new Producto { NombreCompleto = "AEROSOL KUWAIT AZUL 60CC", Categoria = "Pintura" });
            productosRaw.Add(new Producto { NombreCompleto = "AEROSOL OTRA MARCA VERDE 40CC", Categoria = "Pintura" });

            productosRaw.Add(new Producto { NombreCompleto = "TORNILLO PHILIPS 10MM", Categoria = "Ferreteria" });
            productosRaw.Add(new Producto { NombreCompleto = "TORNILLO PLANO 8MM", Categoria = "Ferreteria" });

            productosRaw.Add(new Producto { NombreCompleto = "CAÑO ESTRUCTURAL 20X20", Categoria = "Construccion" });
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarTodo();
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AbrirDetalle();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            AbrirDetalle();
        }
    }
}
