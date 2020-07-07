using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Schema;

namespace EntidadesCompartidas
{
    public class Pedido
    {
        private int _numero;
        private string _cliente;
        private Int64 _rucMedicamento;
        private int _codMedicamento;
        private int _cantidad;
        private int _estado;

        public int numero
        {
            set
            {
                if (_numero != 0)
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
                if (_rucMedicamento != 0)
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
                if (_codMedicamento != 0)
                    _codMedicamento = value;
                else
                    throw new Exception("Error - RUC invalido");
            }
            get { return _codMedicamento; }
        }

        public int cantidad
        {
            set
            {
                if (_cantidad != 0)
                    _cantidad = value;
                else
                    throw new Exception("Error - RUC invalido");
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

        /*
        public Pedido(int pNumero, string pCliente, Int64 pRucMedicamento, int pCodMedicamento, int pCantidad, int pEstado)
        {
            numero = pNumero;
            cliente = pCliente;
            rucMedicamento = pRucMedicamento;
            codMedicamento = pCodMedicamento;
            cantidad = pCantidad;
            estado = pEstado;
        }

        public Pedido(string pCliente, Int64 pRucMedicamento, int pCodMedicamento, int pCantidad, int pEstado)
        {
            cliente = pCliente;
            rucMedicamento = pRucMedicamento;
            codMedicamento = pCodMedicamento;
            cantidad = pCantidad;
            estado = pEstado;
        }
        */


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
