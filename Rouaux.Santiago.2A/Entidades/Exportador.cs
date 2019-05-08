using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Exportador : Comercio
    {
        public ETipoProducto tipo;

        public Exportador(string nombreComercio, float precioAlquiler, string nombre, string apellido, ETipoProducto tipo) : base(precioAlquiler, nombreComercio, nombre, apellido)
        {
            this.tipo = tipo;
        }

        public string Mostrar()
        {
            return ((Comercio)this) + "\nTipo: " + this.tipo.ToString() + "\n";
        }

        //OPERADORES
        public static bool operator ==(Exportador a, Exportador b)
        {
            if (a.GetType() == b.GetType() && (Comercio)a == (Comercio)b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Exportador a, Exportador b)
        {
            return !(a == b);
        }


        //CONVERSION
        public static implicit operator double(Exportador m)
        {
            return m._precioAlquiler;
        }
    }

}
