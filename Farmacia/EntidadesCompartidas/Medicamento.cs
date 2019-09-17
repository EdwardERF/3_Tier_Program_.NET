using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Medicamento
    {
        private Int64 _ruc;
        private int _codigo;
        private string _nombre;
        private string _descripcion;
        private int _precio;

        public Int64 ruc
        {
            get { return _ruc; }
            set { _ruc = value; }
        }

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public Medicamento(Int64 pruc, int pcodigo, string pnombre, string pdescripcion, int pprecio)
        {
            ruc = pruc;
            codigo = pcodigo;
            nombre = pnombre;
            descripcion = pdescripcion;
            precio = pprecio;
        }

        public override string ToString()
        {
            return ("Farmaceutica: " + ruc + "\n Codigo: " + codigo + "\n Nombre: " + nombre + "\n Descripcion: " + descripcion + "\n Precio: " + precio);
        }
    }
}
