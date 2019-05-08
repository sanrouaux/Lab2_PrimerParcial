using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Importador : Comercio
    {
        public EPaises paisOrigen;


        //CONSTRUC  
        public Importador(string nombreComercio, float precioAlquiler, Comerciante comerciante, EPaises paisOrigen) : base(nombreComercio, comerciante, precioAlquiler)
        {
            this.paisOrigen = paisOrigen;
        }


        public string Mostrar()
        {
            return ((Comercio)this) + "\nPais: " + this.paisOrigen.ToString() + "\n";
        }


        //OPERADORES
        public static bool operator ==(Importador a, Importador b)
        {
            if ((Comercio)a == (Comercio)b && a.paisOrigen == b.paisOrigen)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Importador a, Importador b)
        {
            return !(a == b);
        }


        //CONVERSION
        public static implicit operator double(Importador m)
        {
            return m._precioAlquiler;
        }
    }
}
