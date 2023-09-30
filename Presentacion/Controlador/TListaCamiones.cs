using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Entidades;

namespace Presentacion.Controlador
{
    public class TListaCamiones
    {
        public static List<Camion> ListaCamion = new List<Camion>();

        public static void Insert(Camion op)
        {
            ListaCamion.Add(op);
        }

        public static void Update(Camion op, int pos)
        {
            ListaCamion[pos] = op;
        }

        public static void Delete(int pos)
        {
            ListaCamion.Remove(ListaCamion.ElementAtOrDefault(pos));
        }

        public static int Buscar(int cod)
        {
            int pos = -1;
            for (int i = 0; i < ListaCamion.Count; i++)
            {
                if (ListaCamion[i].Codigo == cod)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public static Camion GetCamion(int pos)
        {
            return ListaCamion[pos];
        }
    }
}
