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

        private int _codigo;
        private string _nombre;
        private string _descripcion;
        private int _precio;

        public Farmaceutica Far
        {
            get { return _far; }
            set { _far = value; }
        }

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string nombre
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

        public string descripcion
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

        public int precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public Medicamento(Farmaceutica pFar, int pcodigo, string pnombre, string pdescripcion, int pprecio)
        {
            Far = pFar;
            codigo = pcodigo;
            nombre = pnombre;
            descripcion = pdescripcion;
            precio = pprecio;
        }

        public override string ToString()
        {
            return ("Farmaceutica: " + Far.ruc + "\n Codigo: " + codigo + "\n Nombre: " + nombre + "\n Descripcion: " + descripcion + "\n Precio: " + precio);
        }
    }
}
