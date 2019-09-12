using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public abstract class Usuario
    {
        private string _nomUsu;
        private string _pass;
        private string _nombre;
        private string _apellido;

        public string nomUsu
        {
            get { return _nomUsu; }
            set { _nomUsu = value; }
        }

        public string pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public Usuario(string pnomUsu, string ppass, string pnombre, string papellido)
        {
            nomUsu = pnomUsu;
            pass = ppass;
            nombre = pnombre;
            apellido = papellido;
        }

        public override string ToString()
        {
            return ("Usuario: " + nomUsu + "\n Nombre: " + nombre + "\n Apellido: " + apellido);
        }
    }
}
