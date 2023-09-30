using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Entidades;

namespace Presentacion.Controlador
{
    public class TListaChofer
    {
        public static List<Chofer> ListaChofer = new List<Chofer>();

        public static void Insert(Chofer op)
        {
            ListaChofer.Add(op);
        }

        public static void Update(Chofer op, int pos)
        {
            ListaChofer[pos] = op;
        }

        public static void Delete(int pos)
        {
            ListaChofer.Remove(ListaChofer.ElementAtOrDefault(pos));
        }

        public static int Buscar(int cod)
        {
            int pos = -1;
            for (int i = 0; i < ListaChofer.Count; i++)
            {
                if (ListaChofer[i].IdChofer == cod)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public static Chofer GetChofer(int pos)
        {
            return ListaChofer[pos];
        }
    }
}
