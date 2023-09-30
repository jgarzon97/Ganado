using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Entidades;

namespace Presentacion.Controlador
{
    public class TListaGanado
    {
        public static List<Ganado> ListaGanado = new List<Ganado>();

        public static void Insert(Ganado op)
        {
            ListaGanado.Add(op);
        }

        public static void Update(Ganado op, int pos)
        {
            ListaGanado[pos] = op;
        }

        public static void Delete(int pos)
        {
            ListaGanado.Remove(ListaGanado.ElementAtOrDefault(pos));
        }

        public static int Buscar(int cod)
        {
            int pos = -1;
            for (int i = 0; i < ListaGanado.Count; i++)
            {
                if (ListaGanado[i].IdGanado == cod)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public static Ganado GetGanado(int pos)
        {
            if (pos < 0 || pos >= ListaGanado.Count)
            {
                throw new IndexOutOfRangeException("El índice está fuera del rango de la lista de ganado.");
            }
            return ListaGanado[pos];
        }

        public static int Count()
        {
            return ListaGanado.Count;
        }
    }
}
