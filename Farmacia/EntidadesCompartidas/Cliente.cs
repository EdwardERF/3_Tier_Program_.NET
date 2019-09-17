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
            get { return _dirEntrega; }
            set { _dirEntrega = value; }
        }

        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
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
