using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Entidades
{
    public class Camion
    {
        public int Codigo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double CapacidadCarga { get; set; }
        public Chofer ChoferAsignado { get; set; }
        public double CantidadLecheTransportada { get; private set; }

        public Camion() { }

        public Camion(int codigo, string marca, string modelo, double capacidadCarga, Chofer choferasignado)
        {
            Codigo = codigo;
            Marca = marca;
            Modelo = modelo;
            CapacidadCarga = capacidadCarga;
            ChoferAsignado = choferasignado;
            CantidadLecheTransportada = 0;
        }

        public void AgregarLeche(double cantidadLeche)
        {
            if (CantidadLecheTransportada + cantidadLeche <= CapacidadCarga)
            {
                MessageBox.Show(string.Format("Cargando {0} litros de leche...", cantidadLeche));
                CantidadLecheTransportada += cantidadLeche;
            }
            else
            {
                double cargaRestante = CapacidadCarga - CantidadLecheTransportada;
                MessageBox.Show(string.Format("Solo se cargará {0} litros de leche de " + cantidadLeche + ". El camión está lleno.", cargaRestante));
                CantidadLecheTransportada += cargaRestante;
            }
        }

        public void RetirarLeche(double cantidadLeche)
        {
            if (cantidadLeche == 0)
            {
                MessageBox.Show("El camión no contiene carga");
                return;
            }
            if (CantidadLecheTransportada - cantidadLeche >= 0)
            {
                MessageBox.Show(string.Format("Se retiró {0} litros de leche", cantidadLeche));
                CantidadLecheTransportada -= cantidadLeche;
            }
            else
            {
                MessageBox.Show(string.Format("No se puede retirar esa cantidad de leche porque no hay suficiente en el camión."));
            }
        }

        public string NombreChofer
        {
            get { return ChoferAsignado.Nombre + " " + ChoferAsignado.Apellido; }
        }

        public void AgregarGanado(Ganado ganado)
        {
            if (ganado.Peso <= CapacidadCarga - CantidadLecheTransportada)
            {
                MessageBox.Show($"Cargando {ganado.Peso} kg de ganado...");
                CantidadLecheTransportada += ganado.Peso;
            }
            else
            {
                MessageBox.Show($"El camión está lleno. No se puede cargar más ganado.");
            }
        }
    }
}
