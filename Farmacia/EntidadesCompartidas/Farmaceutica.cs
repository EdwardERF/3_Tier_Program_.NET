using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Farmaceutica
    {
        private Int64 _ruc;
        private string _nombre;
        private string _correo;
        private string _calle;
        private int _numero;
        private int _apto;

        public Int64 ruc
        {
            set
            {
                if (value != 0)
                    _ruc = value;
                else
                    throw new Exception("Error - RUC invalido");
            }
            get { return _ruc; }
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

        public string correo
        {
            set
            {
                if (value.Length <= 50)
                    _correo = value;
                else
                    throw new Exception("Error - Correo muy extenso");
            }
            get { return _correo; }
        }

        public string calle
        {
            set
            {
                if (value.Length <= 50)
                    _calle = value;
                else
                    throw new Exception("Error - Calle muy extensa");
            }
            get { return _calle; }
        }

        public int numero
        {
            set
            {
                if (value != 0)
                    _numero = value;
                else
                    throw new Exception("Error - RUC nulo");
            }
            get { return _numero; }
        }

        public int apto
        {
            set
            {
                if (value != 0)
                    _apto = value;
                else
                    throw new Exception("Error - Numero de apto invalido");
            }
            get { return _apto; }
        }

        public Farmaceutica(Int64 pruc, string pnombre, string pcorreo, string pcalle, int pnumero, int papto)
        {
            ruc = pruc;
            nombre = pnombre;
            correo = pcorreo;
            calle = pcalle;
            numero = pnumero;
            apto = papto;
        }

        public override string ToString()
        {
            return ("RUC: " + ruc + "\n Nombre: " + nombre + "\n Correo: " + correo + "\n Calle: " + calle + "\n Numero: " + numero + "\n Apto: " + apto);
        }
    }
}
