using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comercio
    {
        //ATRIB
        protected int _cantidadDeEmpleados;
        protected Comerciante _comerciante;
        protected static Random _generadorDeEmpleados;
        protected string _nombre;
        protected float _precioAlquiler;

        //PROP
        public int CantidadDeEmpleados
        {            
            get
            {
                if (this._cantidadDeEmpleados == 0)
                {
                    this._cantidadDeEmpleados = Comercio._generadorDeEmpleados.Next(0, 10);
                }
                return this._cantidadDeEmpleados;
            }
        }


        //CONSTR
        static Comercio()
        {
            Comercio._generadorDeEmpleados = new Random();            
        }

        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido): this(nombreComercio, new Comerciante(nombre, apellido), precioAlquiler)
        {
            
            //this._comerciante = new Comerciante(nombre, apellido);
        }

        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler) 
        {
            this._nombre = nombre;
            this._precioAlquiler = precioAlquiler;
            this._comerciante = comerciante;
        }

        //METODOS
        private string Mostrar()
        {
            return "NOMBRE: " + this._nombre + "\nCANTIDAD DE EMPLEADOS: " + this._cantidadDeEmpleados + "\nCOMERCIANTE: " + this._comerciante + "\nPRECIO ALQUILER: " + this._precioAlquiler; 
        }


        //OPERADORES
        public static bool operator ==(Comercio a, Comercio b)
        {
            if (a._nombre == b._nombre && a._comerciante == b._comerciante)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Comercio a, Comercio b)
        {
            return !(a == b);
        }


        //CONVERSION
        public static implicit operator string(Comercio a)
        {
            return a.Mostrar();
        }
    }    
}
