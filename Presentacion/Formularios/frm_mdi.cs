using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Formularios.Tablas;

namespace Presentacion.Formularios
{
    public partial class frm_mdi : Form
    {
        public frm_mdi()
        {
            InitializeComponent();
        }

        private void choferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_admin_chofer form = new frm_admin_chofer();
            form.Show();
        }

        private void ganadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_admin_ganado form = new frm_admin_ganado();
            form.Show();
        }

        private void camionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_admin_camion form = new frm_admin_camion();
            form.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
