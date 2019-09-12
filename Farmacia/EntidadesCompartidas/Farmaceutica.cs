using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Farmaceutica
    {
        private int _ruc;
        private string _nombre;
        private string _correo;
        private string _calle;
        private int _numero;
        private int _apto;

        public int ruc
        {
            get { return _ruc; }
            set { _ruc = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string calle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        public int numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public int apto
        {
            get { return _apto; }
            set { _apto = value; }
        }

        public Farmaceutica(int pruc, string pnombre, string pcorreo, string pcalle, int pnumero, int papto)
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
