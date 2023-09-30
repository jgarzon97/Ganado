using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Presentacion.Controlador;
using Presentacion.Entidades;
using Presentacion.Formularios.Ingresos;

namespace Presentacion.Formularios.Tablas
{
    public partial class frm_admin_camion : Form
    {
        public frm_admin_camion()
        {
            InitializeComponent();
            Tabla();
        }

        private void frm_admin_camion_Load(object sender, EventArgs e)
        {
            if (TListaCamiones.ListaCamion.Count == 0)
            {
                Chofer chofer1 = new Chofer(0761675664, "Juan", "Perez", "L-0787");
                Chofer chofer2 = new Chofer(0778218748, "Mario", "Ruiz", "L-0459");
                Chofer chofer3 = new Chofer(0761675664, "Luis", "Cevallos", "L-0589");

                Camion camion1 = new Camion(1, "Cummins", "2628e", 2800.5, chofer1);
                Camion camion2 = new Camion(2, "Mercedes", "L710a", 3000.75, chofer2);
                Camion camion3 = new Camion(3, "Jac", "ER31o", 2500.42, chofer3);

                TListaCamiones.Insert(camion1);
                TListaCamiones.Insert(camion2);
                TListaCamiones.Insert(camion3);

                TListaChofer.Insert(chofer1);
                TListaChofer.Insert(chofer2);
                TListaChofer.Insert(chofer3);
            }

            dataGridView1.DataSource = TListaCamiones.ListaCamion.ToList();
        }

        private void Tabla()
        {
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn Codigo = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Codigo",
                HeaderText = "ID"
            };

            DataGridViewTextBoxColumn Marca = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Marca",
                HeaderText = "Marca Camión"
            };

            DataGridViewTextBoxColumn Modelo = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Modelo",
                HeaderText = "Modelo Camión"
            };

            DataGridViewTextBoxColumn CapacidadCarga = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CapacidadCarga",
                HeaderText = "Capacidad (Kg)"
            };

            DataGridViewTextBoxColumn choferCol = new DataGridViewTextBoxColumn
            {
                Name = "choferCol",
                HeaderText = "Nombre Chofer",
                DataPropertyName = "NombreChofer",
            };

            DataGridViewTextBoxColumn CantidadLecheTransportada = new DataGridViewTextBoxColumn
            {
                Name = "Carga litros",
                DataPropertyName = "CantidadLecheTransportada",
                HeaderText = "Carga litros"
            };

            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Codigo, Marca, Modelo, CapacidadCarga, choferCol, CantidadLecheTransportada });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frm_edit_camion frm = new frm_edit_camion(TListaChofer.ListaChofer.ToList());
                Hide();
                frm.Text = "Ingresar Camión";
                frm.label7.Text = "INGRESAR CAMIONES";
                frm.button1.Text = "Ingresar";
                frm.ShowDialog();
                Show();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Camion obj = frm.CrearOb();
                    TListaCamiones.Insert(obj);
                    dataGridView1.DataSource = TListaCamiones.ListaCamion.ToList();
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
                Camion ob = TListaCamiones.GetCamion(pos);
                frm_edit_camion frm = new frm_edit_camion(TListaChofer.ListaChofer.ToList())
                {
                    auxiliar = ob
                };
                Hide();
                frm.SetDatos();                
                frm.Text = "Editar Camión";
                frm.button1.Text = "Editar";
                frm.label7.Text = "EDITAR CAMIÓN";
                frm.ShowDialog();
                Show();
                TListaCamiones.Update(frm.CrearOb(), pos);
                dataGridView1.DataSource = TListaCamiones.ListaCamion.ToList();
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
                TListaCamiones.Delete(pos);
                dataGridView1.DataSource = TListaCamiones.ListaCamion.ToList();

            }
            else
                MessageBox.Show("Seleccione un dato para eliminar");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Ingrese los litros de leche:", "Cargar camión");
            try
            {
                if (double.TryParse(input, out double litros))
                {
                    // Obtener la fila seleccionada en el DataGridView
                    int index = dataGridView1.CurrentRow.Index;

                    // Actualizar la carga actual del camión en esa fila
                    Camion camion = TListaCamiones.GetCamion(index);
                    camion.AgregarLeche(litros);

                    // Actualizar el valor en la celda correspondiente en el DataGridView
                    dataGridView1.Rows[index].Cells["Carga litros"].Value = camion.CantidadLecheTransportada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridView1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la fila seleccionada en el DataGridView
                int index = dataGridView1.CurrentRow.Index;

                // Obtener la referencia al objeto Camion correspondiente
                Camion camion = TListaCamiones.GetCamion(index);

                // Retirar toda la carga actual del camión
                camion.RetirarLeche(camion.CantidadLecheTransportada);

                // Actualizar el valor en la celda correspondiente en el DataGridView
                dataGridView1.Rows[index].Cells["Carga litros"].Value = camion.CantidadLecheTransportada;

                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la fila seleccionada en el DataGridView
                int index = dataGridView1.CurrentRow.Index;

                // Obtener el camión correspondiente a la fila seleccionada
                Camion camion = TListaCamiones.GetCamion(index);

                // Abrir ventana de selección de ganado
                frm_admin_ganado form = new frm_admin_ganado();
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Agregar el ganado seleccionado al camión
                    Ganado ganado = new Ganado();
                    //camion.AgregarGanado(ganado);

                    // Actualizar el DataGridView con los detalles del ganado agregado
                    dataGridView1.Rows[index].Cells["Ganado"].Value = $"{ganado.IdGanado} - {ganado.Tipo}";

                    // Mostrar mensaje de éxito
                    MessageBox.Show($"El ganado {ganado.IdGanado} se ha agregado al camión.", "Ganado agregado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
