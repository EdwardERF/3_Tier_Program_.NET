using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente : Usuario
    {
        private string _dirEntrega;
        private List<int> _telefonos;

        public string dirEntrega
        {
            get { return _dirEntrega; }
            set { _dirEntrega = value; }
        }

        public List<int> Telefonos
        {
            get { return _telefonos; }
            set { _telefonos = value; }
        }

        public Cliente(string pnomUsu, string ppass, string pnombre, string papellido, string pdirEntrega, List<int> pTelefonos)
            : base(pnomUsu, ppass, pnombre, papellido)
        {
            dirEntrega = pdirEntrega;
            Telefonos = pTelefonos;
        }

        public override string ToString()
        {
            return base.ToString() + "Direccion de Entrega: " + dirEntrega + "\n Telefonos: " + Telefonos; //Chequear el resultado de este string, por la List<>
        }
    }
}
