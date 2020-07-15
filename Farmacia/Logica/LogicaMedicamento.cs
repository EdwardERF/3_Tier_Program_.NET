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

        public static void Eliminar(Medicamento oMed)
        {
            PersistenciaMedicamento.Eliminar(oMed);
        }

        public static List<Medicamento> Listar()
        {
            return PersistenciaMedicamento.Listar();
        }

        public static List<Medicamento> ListarMedicamentoUnico(Medicamento oMed)
        {
            return PersistenciaMedicamento.ListarMedicamentoUnico(oMed);
        }

        public static List<Medicamento> ListarMedicamentosXFarmaceutica(Farmaceutica oFar)
        {
            return PersistenciaMedicamento.ListarMedicamentosXFarmaceutica(oFar);
        }

        public static Medicamento Buscar(Int64 oRUC, int oCodigo)
        {
            Medicamento oMed = PersistenciaMedicamento.Buscar(oRUC, oCodigo);
            return oMed;
        }
    }
}
