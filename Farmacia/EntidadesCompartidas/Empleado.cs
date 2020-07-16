using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Empleado : Usuario
    {
        private string _horaInicio;
        private string _horaFinal;

        public string horaInicio
        {
            get { return _horaInicio; }
            set { _horaInicio = value; }
        }

        public string horaFinal
        {
            get { return _horaFinal; }
            set { _horaFinal = value; }
        }

        public Empleado(string pnomUsu, string ppass, string pnombre, string papellido, string phoraInicio, string phoraFinal)
            : base(pnomUsu, ppass, pnombre, papellido)
        {
            horaInicio = phoraInicio;
            horaFinal = phoraFinal;
        }
    }
}
    