using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Entidades
{
    public class Chofer
    {
        public int IdChofer { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Licencia { get; set; }

        public Chofer() { }
        
        public Chofer(int idChofer, string nombre, string apellido, string licencia)
        {
            IdChofer = idChofer;
            Nombre = nombre;
            Apellido = apellido;
            Licencia = licencia;
        }
    }
}
