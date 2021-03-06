﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaFarmaceutica
    {
        public static void Alta(Farmaceutica oFar)
        {
            PersistenciaFarmaceutica.Alta(oFar);
        }

        public static void Modificar(Farmaceutica oFar)
        {
            PersistenciaFarmaceutica.Modificar(oFar);
        }

        public static void Eliminar(Farmaceutica oFar)
        {
            PersistenciaFarmaceutica.Eliminar(oFar);
        }

        public static Farmaceutica Buscar(Int64 oRUC)
        {
            Farmaceutica oFar = PersistenciaFarmaceutica.Buscar(oRUC);
            return oFar;
        }

        public static Farmaceutica BuscarXNombre(string Nombre)
        {
            Farmaceutica oFar = PersistenciaFarmaceutica.BuscarXNombre(Nombre);
            return oFar;
        }

        public static List<Farmaceutica> ListarFarmaceuticas()
        {
            return PersistenciaFarmaceutica.ListarFarmaceuticas();
        }
    }
}
