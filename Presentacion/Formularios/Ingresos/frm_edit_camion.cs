using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Entidades;
using Presentacion.Controlador;


namespace Presentacion.Formularios.Ingresos
{
    public partial class frm_edit_camion : Form
    {
        private List<Chofer> _listaChoferes;

        public frm_edit_camion(List<Chofer> listaChoferes)
        {
            InitializeComponent();
            _listaChoferes = listaChoferes;

            comboBox1.DataSource = listaChoferes;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdChofer";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public Camion auxiliar;
        Camion camion;

        // Este método está actualizando los valores de los objetos TextBox.
        public void SetDatos()
        {
            textBox1.Text = auxiliar.Codigo.ToString();
            textBox2.Text = auxiliar.Marca;
            textBox3.Text = auxiliar.Modelo;
            comboBox1.Text = auxiliar.ChoferAsignado.ToString();
            textBox4.Text = auxiliar.CapacidadCarga.ToString();
        }

        // Este método crea un objeto de la clase Camion a partir de los valores TextBox y ComboBox.
        public Camion CrearOb()
        {
            try
            {
                int cod = int.Parse(textBox1.Text);
                string mar = textBox2.Text;
                string mod = textBox3.Text;
                double cap = double.Parse(textBox4.Text);

                Chofer choferSeleccionado = (Chofer)comboBox1.SelectedItem;

                // Crear el objeto Camion con el Chofer correspondiente.
                camion = new Camion(cod, mar, mod, cap, choferSeleccionado);
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }          
            return camion;
        }

        // Este método controla que no haya ingresos vacíos.
        public bool Validar()
        {
            bool ban = true;

            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 ||
                textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 )
            {
                ban = false;
                MessageBox.Show("No deje campos vacíos.");
            }
            return ban;
        }

        private void frm_edit_camion_Load(object sender, EventArgs e)
        {
            if (auxiliar != null)
            {
                SetDatos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
