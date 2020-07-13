using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Schema;

namespace EntidadesCompartidas
{
    public class Pedido
    {
        private Medicamento _oMed;
        private Cliente _oCli;

        private int _numero;
        private string _cliente;
        private Int64 _rucMedicamento;
        private int _codMedicamento;
        private int _cantidad;
        private int _estado;

        
        public Medicamento oMed
        {
            set
            {
                if (_oMed is null)
                    throw new Exception("Error - Medicamento invalido");
                else
                    _oMed = value;
            }
            get { return _oMed; }
        }

        public Cliente oCli
        {
            set
            {
                if (_oCli != null)
                    _oCli = value;
                else
                    throw new Exception("Error - Cliente invalido");
            }
            get { return _oCli; }
        }

        public int numero
        {
            set
            {
                if (_numero >= 0)
                    _numero = value;
                else
                    throw new Exception("Error - Numero invalido");
            }
            get { return _numero; }
        }

        public string cliente
        {
            set
            {
                if (value.Length <= 20)
                    _cliente = value;
                else
                    throw new Exception("Error - Nombre de cliente muy extenso");
            }
            get { return _cliente; }
        }

        public Int64 rucMedicamento
        {
            set
            {
                if (_rucMedicamento >= 0)
                    _rucMedicamento = value;
                else
                    throw new Exception("Error - RUC invalido");
            }
            get { return _rucMedicamento; }
        }

        public int codMedicamento
        {
            set
            {
                if (_codMedicamento >= 0)
                    _codMedicamento = value;
                else
                    throw new Exception("Error - Codigo invalido");
            }
            get { return _codMedicamento; }
        }

        public int cantidad
        {
            set
            {
                if (_cantidad >= 0)
                    _cantidad = value;
                else
                    throw new Exception("Error - Cantidad invalida");
            }
            get { return _cantidad; }
        }

        public int estado
        {
            set
            {
                if ((value >= 0) && (value <= 2))
                    _estado = value;
                else
                    throw new Exception("Error - Solo existe estado 0, 1, 2");
            
            }
            get { return _estado; }
        }

        public Pedido(int pNum, Cliente poCli, Medicamento poMed, int pCantidad, int pEstado)
        {
            numero = pNum;
            cliente = poCli.nomUsu;
            rucMedicamento = poMed.Ruc;
            codMedicamento = poMed.Codigo;
            cantidad = pCantidad;
            estado = pEstado;
        }

        public override string ToString()
        {
            string estadoTraducido;
            if (estado == 0)
                estadoTraducido = "Generado";
            else if (estado == 1)
                estadoTraducido = "Enviado";
            else
                estadoTraducido = "Entregado";

            return "Nro Pedido: " + numero + "<br/>Cliente: " + cliente + "<br/>RUC Medicamento: " + rucMedicamento + "<br/>Codigo Medicamento: "
                + codMedicamento + "<br/>Cantidad: " + cantidad + "<br/>Estado: " + estadoTraducido;
        }
    }
}
