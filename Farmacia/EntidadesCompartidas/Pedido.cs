using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            get { return _numero; }
            set { _numero = value; }
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
            get { return _rucMedicamento; }
            set { _rucMedicamento = value; }
        }

        public int codMedicamento
        {
            get { return _codMedicamento; }
            set { _codMedicamento = value; }
        }

        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
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
    }
}
