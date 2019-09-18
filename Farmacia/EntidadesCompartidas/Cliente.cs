using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente : Usuario
    {
        private string _dirEntrega;
        private int _telefono;

        public string dirEntrega
        {
            set
            {
                if (value.Length <= 100)
                    _dirEntrega = value;
                else
                    throw new Exception("Error - Direccion muy extensa");
            }
            get { return _dirEntrega; }
        }

        public int Telefono
        {
            set
            {
                if ((value > 99999) && (value <= 999999999))
                    _telefono = value;
                else
                    throw new Exception("Error - Telefono invalido");
            }
            get { return _telefono; }
        }

        public Cliente(string pnomUsu, string ppass, string pnombre, string papellido, string pdirEntrega, int pTelefono)
            : base(pnomUsu, ppass, pnombre, papellido)
        {
            dirEntrega = pdirEntrega;
            Telefono = pTelefono;
        }

        public override string ToString()
        {
            return base.ToString() + "Direccion de Entrega: " + dirEntrega + "\n Telefonos: " + Telefono; //Chequear el resultado de este string, por la List<>
        }
    }
}
