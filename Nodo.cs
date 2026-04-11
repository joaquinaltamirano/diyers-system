using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyers_System
{    public class Nodo
    {
        public string Nombre { get; set; }
        public List<Nodo> Hijos { get; set; } = new List<Nodo>();
        public bool EsFinal { get; set; }

        // Opcional (para el último nivel)
        public Producto ProductoFinal { get; set; }
    }
}
