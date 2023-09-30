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

namespace Presentacion.Formularios.Ingresos
{
    public partial class frm_edit_chofer : Form
    {
        public frm_edit_chofer()
        {
            InitializeComponent();
        }

        public Chofer auxiliar;
        Chofer obj;

        // Este método está actualizando los valores de los objetos TextBox.
        public void SetDatos()
        {
            textBox1.Text = auxiliar.IdChofer.ToString();
            textBox2.Text = auxiliar.Nombre;
            textBox3.Text = auxiliar.Apellido;
            textBox4.Text = auxiliar.Licencia;
        }

        // Este método crea un objeto de la clase Chofer apartir de los valores TextBox.
        public Chofer CrearOb()
        {
            int id = int.Parse(textBox1.Text);
            string nom = textBox2.Text;
            string ape = textBox3.Text;
            string lin = textBox4.Text;

            obj = new Chofer(id, nom, ape, lin);

            return obj;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void frm_edit_chofer_Load(object sender, EventArgs e)
        {
            if (auxiliar != null)
            {
                SetDatos();
            }
        }
    }
}
