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
            set
            {
                if (value.Length <= 20)
                    _nomUsu = value;
                else
                    throw new Exception("Error - Nombre usuario muy extenso");
            }
            get { return _nomUsu; }
        }

        public string pass
        {
            set
            {
                if (value.Length <= 20)
                    _pass = value;
                else
                    throw new Exception("Error - Contraseña muy extensa");
            }
            get { return _pass; }
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

        public string apellido
        {
            set
            {
                if (value.Length <= 20)
                    _apellido = value;
                else
                    throw new Exception("Error - Apellido muy extenso");
            }
            get { return _apellido; }
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
