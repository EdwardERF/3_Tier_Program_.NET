using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Empleado : Usuario
    {
        private DateTime _horaInicio;
        private DateTime _horaFinal;

        public DateTime horaInicio
        {
            get { return _horaInicio; }
            set { _horaInicio = value; }
        }

        public DateTime horaFinal
        {
            get { return _horaFinal; }
            set { _horaFinal = value; }
        }

        public Empleado(string pnomUsu, string ppass, string pnombre, string papellido, DateTime phoraInicio, DateTime phoraFinal)
            : base(pnomUsu, ppass, pnombre, papellido)
        {
            horaInicio = phoraInicio;
            horaFinal = phoraFinal;
        }
    }
}
