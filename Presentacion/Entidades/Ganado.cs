using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Entidades
{
    public class Ganado
    {
        public int IdGanado { get; set; }
        public string Tipo { get; set; }
        public double Peso { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double ProduccionDiaria { get; private set; }

        public Ganado() { }

        public Ganado(int idGanado, string tipo, double peso, string descripcion, double costo)
        {
            IdGanado = idGanado;
            Tipo = tipo;
            Peso = peso;
            Descripcion = descripcion;
            Costo = costo;
            ProduccionDiaria = 0;
        }

        public double Leche_diaria()
        {
            if (Tipo == "Vaca")
            {
                // Agregamos la producción aleatoria a la producción diaria esperada
                // Se asume que una vaca produce 0.05 litros de leche por cada Kg de peso
                double produccionDiaria = Peso * 0.05;

                return produccionDiaria;

                //// De la clase Random generamos un número aleatorio entre 0 y 5
                //Random rand = new Random();
                //double produccionAleatoria = rand.NextDouble() * 5;

                //// Agregamos la producción aleatoria a la producción diaria esperada
                //// Se asume que una vaca produce 0.05 litros de leche por cada Kg de peso
                //double produccionDiaria = Peso * 0.05 + produccionAleatoria;

                //// Redondeamos la producción diaria a dos decimales
                //produccionDiaria = Math.Round(produccionDiaria, 2);
                //return produccionDiaria;
            }
            else
            {
                // Toros y Becerros
                return 0;
            }
        }
    }
}