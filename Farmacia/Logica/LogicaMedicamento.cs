using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaMedicamento
    {
        public static void Alta(Medicamento oMed)
        {
            PersistenciaMedicamento.Alta(oMed);
        }

        public static void Modificar(Medicamento oMed)
        {
            PersistenciaMedicamento.Modificar(oMed);
        }

        public static void Eliminar(Int64 oRUC, int oCodigo)
        {
            PersistenciaMedicamento.Eliminar(oRUC, oCodigo);
        }

        public static List<Medicamento> Listar()
        {
            return PersistenciaMedicamento.Listar();
        }

        public static List<Medicamento> ListarMedicamentosXFarmaceutica(Int64 oRUC)
        {
            return PersistenciaMedicamento.ListarMedicamentosXFarmaceutica(oRUC);
        }

        public static Medicamento Buscar(Int64 oRUC, int oCodigo)
        {
            Medicamento oMed = PersistenciaMedicamento.Buscar(oRUC, oCodigo);
            return oMed;
        }
    }
}
