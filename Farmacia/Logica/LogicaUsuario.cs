using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static Usuario Logueo(string nomUsu, string pass)
        {
            Usuario oUsu = null;

            oUsu = PersistenciaEmpleado.Logueo(nomUsu, pass);

            if(oUsu == null)
            {
                oUsu = PersistenciaCliente.Logueo(nomUsu, pass);
            }

            return oUsu;
        }

        public static void AltaCliente(Cliente oCli)
        {
            PersistenciaCliente.Alta(oCli);
        }

        public static void AltaEmpleado(Empleado oEmp)
        {
            PersistenciaEmpleado.Alta(oEmp);
        }

        public static void ModificarEmpleado(Empleado oEmp)
        {
            PersistenciaEmpleado.Modificar(oEmp);
        }

        public static void EliminarEmpleado(Empleado oEmp)
        {
            PersistenciaEmpleado.Eliminar(oEmp);
        }

        public static Empleado BuscarEmpleado(string nomUsu)
        {
            Empleado oEmp = PersistenciaEmpleado.Buscar(nomUsu);
            return oEmp;
        }

        public static Cliente BuscarCliente(string nomUsu)
        {
            Cliente oCli = PersistenciaCliente.Buscar(nomUsu);
            return oCli;
        }

        public static Usuario BuscarUsuario(string nomUsu)
        {
            return PersistenciaUsuario.Buscar(nomUsu);
        }
    }
}
