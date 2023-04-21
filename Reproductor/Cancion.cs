using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reproductor
{
    public class Cancion
    {
        public string Nombre { get; set; }
        public string Ruta { get; set;}

        public Cancion()
        {
        }


        public Cancion(string nombre, string ruta)
        {
            Nombre = nombre;
            Ruta = ruta;
        }
    }
}
