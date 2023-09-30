using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Controlador;
using Presentacion.Entidades;
using Presentacion.Formularios.Ingresos;

namespace Presentacion.Formularios.Tablas
{
    public partial class frm_admin_chofer : Form
    {
        public frm_admin_chofer()
        {
            InitializeComponent();
            Tabla();
        }

        public List<Chofer> ListaChoferes
        {
            get { return TListaChofer.ListaChofer; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frm_edit_chofer frm = new frm_edit_chofer();
                Hide();
                frm.Text = "Ingresar chofer";
                frm.label5.Text = "INGRESAR CHOFER";
                frm.button1.Text = "Ingresar";
                frm.ShowDialog();
                Show();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Chofer obj = frm.CrearOb();
                    TListaChofer.Insert(obj);
                    dataGridView1.DataSource = TListaChofer.ListaChofer.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo crear el objeto Camion");
            }
        }

        private void Modificar()
        {
            try
            {
                int pos = dataGridView1.CurrentRow.Index;
                Chofer ob = TListaChofer.GetChofer(pos);
                frm_edit_chofer frm = new frm_edit_chofer
                {
                    auxiliar = ob
                };
                frm.SetDatos();
                Hide();
                frm.Text = "Editar chofer";
                frm.label5.Text = "EDITAR CHOFER";
                frm.button1.Text = "Editar";
                frm.ShowDialog();
                Show();
                TListaChofer.Update(frm.CrearOb(), pos);
                dataGridView1.DataSource = TListaChofer.ListaChofer.ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                int pos = dataGridView1.CurrentRow.Index;
                TListaChofer.Delete(pos);
                dataGridView1.DataSource = TListaChofer.ListaChofer.ToList();

            }
            else
                MessageBox.Show("Seleccione un dato para eliminar");
        }

        private void Tabla()
        {
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn IdChofer = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdChofer",
                HeaderText = "ID del Chofer"
            };
            DataGridViewTextBoxColumn Nombre = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre del Chofer"
            };
            DataGridViewTextBoxColumn Apellido = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido del Chofer"
            };
            DataGridViewTextBoxColumn Licencia = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Licencia",
                HeaderText = "Licencia del Chofer"
            };

            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IdChofer, Nombre, Apellido, Licencia });
            dataGridView1.DataSource = TListaChofer.ListaChofer.ToList();
        }
    }
}
