using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Medicamento
    {
        //Atributo de asociacion
        private Farmaceutica _far;

        private Int64 _ruc;
        private int _codigo;
        private string _nombre;
        private string _descripcion;
        private int _precio;

        public Farmaceutica Far
        {
            get { return _far; }
            set { _far = value; }
        }

        public Int64 Ruc
        {
            get { return _ruc; }
            set { _ruc = value; }
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Nombre
        {
            set
            {
                if (value.Length <= 20)
                    _nombre = value;
                else
                    throw new Exception("Error - Nombre muy extenso");
            }
            get { return _nombre; }
        }

        public string Descripcion
        {
            set
            {
                if (value.Length <= 100)
                    _descripcion = value;
                else
                    throw new Exception("Error - Descripcion muy extensa");
            }
            get { return _descripcion; }
        }

        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public Medicamento(Farmaceutica pFar, int pcodigo, string pnombre, string pdescripcion, int pprecio)
        {
            Ruc = pFar.ruc;
            Codigo = pcodigo;
            Nombre = pnombre;
            Descripcion = pdescripcion;
            Precio = pprecio;
        }

        public override string ToString()
        {
            return ("Farmaceutica: " + Far.ruc + "\n Codigo: " + Codigo + "\n Nombre: " + Nombre + "\n Descripcion: " + Descripcion + "\n Precio: " + Precio);
        }
    }
}
