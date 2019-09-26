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

        public static void EliminarEmpleado(string nomUsu)
        {
            PersistenciaEmpleado.Eliminar(nomUsu);
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
    }
}
