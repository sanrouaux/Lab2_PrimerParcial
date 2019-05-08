using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Shopping
    {
        private int _capacidad;
        private List<Comercio> _comercios;

        //PROP
        public double PrecioDeExportadores
        {
            get
            {
                return this.ObtenerPrecio(EComercio.Exportador);
            }
        }

        public double PrecioDeImportadores
        {
            get
            {
                return this.ObtenerPrecio(EComercio.Importador);
            }
        }

        public double PrecioTotal
        {
            get
            {
                return this.ObtenerPrecio(EComercio.Ambos);
            }
        }

        //CONSTRUC
        private Shopping()
        {
            this._comercios = new List<Comercio>();
        }

        private Shopping(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }


        public static string Mostrar(Shopping s)
        {
            string retorno = "Capacidad del Shopping: " + s._capacidad.ToString() + "\n";
            retorno += "Total por importadores: $" + s.PrecioDeImportadores.ToString() + "\n";
            retorno += "Total por exportadores: $" + s.PrecioDeExportadores.ToString() + "\n";
            retorno += "Total: $" + s.PrecioTotal.ToString() + "\n";

            retorno += "**********************************************************\n";
            retorno += "Listado de comercios\n";
            retorno += "**********************************************************\n";

            foreach (Comercio c in s._comercios)
            {
                if(c is Exportador)
                {
                    retorno += ((Exportador)c).Mostrar() + "\n"; 
                }
                else if(c is Importador)
                {
                    retorno += ((Importador)c).Mostrar() + "\n";
                }
            }
            return retorno;
        }

        //OPERAD
        public static bool operator ==(Shopping s, Comercio c)
        {
            bool retorno = false;
            foreach(Comercio com in s._comercios)
            {                
                if(com == c)
                {
                    retorno = true;
                }                
            }
            return retorno;         
        }

        public static bool operator !=(Shopping s, Comercio c)
        {
            return !(s == c);
        }

        
        public static Shopping operator +(Shopping s, Comercio c)
        {
            if (s._capacidad > s._comercios.Count)
            {
                if(s != c)
                {
                    s._comercios.Add(c);
                }
                else
                {
                    Console.Write("El comercio ya está en el Shopping!!!\n");
                }
            }
            else
            {
                Console.Write("No hay más lugar en el Shopping!!!\n");
            }
            return s;
        }


        public static implicit operator Shopping(int capacidad)
        {
            return new Shopping(capacidad);
        }


        private double ObtenerPrecio(EComercio tipoComercio)
        {
            double precioExp = 0;
            double precioImp = 0;
            if(tipoComercio == EComercio.Exportador || tipoComercio == EComercio.Ambos)
            {
                foreach(Comercio c in this._comercios)
                {
                    if(c is Exportador)
                    {
                        precioExp += (Exportador)c;
                    }
                }                
            }
            else if(tipoComercio == EComercio.Importador || tipoComercio == EComercio.Ambos)
            {
                foreach (Comercio c in this._comercios)
                {
                    if (c is Importador)
                    {
                        precioImp += (Importador)c;
                    }
                }                
            }
            
            if(tipoComercio == EComercio.Exportador)
            {
                return precioExp;
            }
            else if(tipoComercio == EComercio.Importador)
            {
                return precioImp;
            }
            else
            {
                return precioExp + precioImp;
            }
        }
    }
}
