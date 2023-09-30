using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Formularios.Ingresos;
using Presentacion.Entidades;
using Presentacion.Controlador;


namespace Presentacion.Formularios.Tablas
{
    public partial class frm_admin_ganado : Form
    {
        public frm_admin_ganado()
        {
            InitializeComponent();
            Tabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frm_edit_ganado frm = new frm_edit_ganado();
                Hide();
                frm.Text = "Ingreso Vacas/Toros";
                frm.label7.Text = "INGRESAR GANADO";
                frm.button1.Text = "Ingresar";
                frm.ShowDialog();
                Show();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Ganado obj = frm.CrearOb();
                    TListaGanado.Insert(obj);
                    dataGridView1.DataSource = TListaGanado.ListaGanado.ToList();
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
                Ganado ob = TListaGanado.GetGanado(pos);
                frm_edit_ganado frm = new frm_edit_ganado
                {
                    auxiliar = ob
                };
                frm.SetDatos();
                Hide();
                frm.Text = "Editar ganado";
                frm.label7.Text = "EDITAR GANADO";
                frm.button1.Text = "Editar";
                frm.ShowDialog();
                Show();
                TListaGanado.Update(frm.CrearOb(), pos);
                dataGridView1.DataSource = TListaGanado.ListaGanado.ToList();
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
                TListaGanado.Delete(pos);
                dataGridView1.DataSource = TListaGanado.ListaGanado.ToList();

            }
            else
                MessageBox.Show("Seleccione un dato para eliminar");
        }

        private void frm_admin_ganado_Load(object sender, EventArgs e)
        {
            if (TListaGanado.ListaGanado.Count == 0)
            {
                Ganado Ganado1 = new Ganado(1, "Vaca", 360, "En buena salud", 2800.50);
                Ganado Ganado2 = new Ganado(2, "Toro", 350, "En buena salud", 1600.75);
                Ganado Ganado3 = new Ganado(3, "Vaca", 180, "En buena salud", 2100.99);
                Ganado Ganado4 = new Ganado(4, "Becerro", 45, "En buena salud", 520);
                Ganado Ganado5 = new Ganado(5, "Vaca", 50, "En buena salud", 1920.10);
                
                TListaGanado.Insert(Ganado1);
                TListaGanado.Insert(Ganado2);
                TListaGanado.Insert(Ganado3);
                TListaGanado.Insert(Ganado4);
                TListaGanado.Insert(Ganado5);
            }

            dataGridView1.DataSource = TListaGanado.ListaGanado.ToList();
        }

        private void Tabla()
        {
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idGanado = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "idGanado",
                HeaderText = "ID"
            };
            DataGridViewTextBoxColumn tipo = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "tipo",
                HeaderText = "Tipo de ganado"
            };
            DataGridViewTextBoxColumn peso = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "peso",
                HeaderText = "Peso (Kg)"
            };
            DataGridViewTextBoxColumn descripcion = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "descripcion",
                HeaderText = "Descripción"
            };
            DataGridViewTextBoxColumn costo = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "costo",
                HeaderText = "Costo de ganado"
            };
            DataGridViewTextBoxColumn ProduccionDiaria = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProduccionDiaria",
                Name = "ProduccionDiaria",
                HeaderText = "Litros por día"
            };

            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idGanado, tipo, peso, descripcion, costo, ProduccionDiaria });
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double totalLeche = 0, pesoTotal = 0;
            int cantidadVacas = 0;

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    Ganado ganado = TListaGanado.GetGanado(row.Index);
                    if (ganado.Tipo == "Vaca")
                    {
                        cantidadVacas++;
                        pesoTotal += ganado.Peso;
                        totalLeche += ganado.Leche_diaria();
                    }
                }

                MessageBox.Show($"El total de litros de leche es: {totalLeche} litros\nLa cantidad de vacas es: {cantidadVacas}\nEl peso total de las vacas es: {pesoTotal} kg", "Resumen de ganado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
