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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_verProductos_Click(object sender, EventArgs e)
        {
            form1 f1 = new form1();
            f1.Show();
            this.Hide();
        }

        private void btn_Cerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
