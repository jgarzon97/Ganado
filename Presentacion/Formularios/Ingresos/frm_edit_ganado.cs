using Presentacion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios.Ingresos
{
    public partial class frm_edit_ganado : Form
    {
        public frm_edit_ganado()
        {
            InitializeComponent();
        }

        public Ganado auxiliar;
        Ganado obj;

        public void SetDatos()
        {
            textBox1.Text = auxiliar.IdGanado.ToString();
            comboBox1.Text = auxiliar.Tipo;
            textBox2.Text = auxiliar.Peso.ToString();
            textBox3.Text = auxiliar.Descripcion;
            textBox4.Text = auxiliar.Costo.ToString();
        }

        public Ganado CrearOb()
        {
            int cod = int.Parse(textBox1.Text);
            string tip = comboBox1.Text;
            double pes = double.Parse(textBox2.Text);
            string des = textBox3.Text;
            double cos = double.Parse(textBox4.Text);

            obj = new Ganado(cod, tip, pes, des, cos);

            return obj;
        }

        public bool Validar()
        {
            bool ban = true;

            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 ||
                textBox4.Text.Trim().Length == 0 )
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

        private void frm_edit_ganado_Load(object sender, EventArgs e)
        {
            if (auxiliar != null)
            {
                SetDatos();
            }
        }
    }
}
