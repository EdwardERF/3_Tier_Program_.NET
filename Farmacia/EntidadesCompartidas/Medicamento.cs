using System;
using System.Collections.Generic;
using System.Data;
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
            set
            {
                if (_far != null)
                    _far = value;
                else
                    throw new Exception("Error - Farmaceutica es nula");
            }
            get { return _far; }
        }

        public Int64 Ruc
        {
            set
            {
                if (_ruc != 0)
                    _ruc = value;
                else
                    throw new Exception("Error - RUC invalido");
            }
            get { return Far.ruc; }
        }
        
        public int Codigo
        {
            set
            {
                if (_codigo != 0)
                    _codigo = value;
                else
                    throw new Exception("Error - Codigo invalido");
            }
            get { return _codigo; }
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
            set
            {
                if (_precio != 0)
                    _precio = value;
                else
                    throw new Exception("Error - Precio invalido");
            }
            get { return _precio; }
        }

        public Medicamento(Farmaceutica pFar, int pcodigo, string pnombre, string pdescripcion, int pprecio)
        {
            Far = pFar;
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
