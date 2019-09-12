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
        private int _rucMedicamento;
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
            get { return _cliente; }
            set { _cliente = value; }
        }

        public int rucMedicamento
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
            get { return _estado; }
            set { _estado = value; }
        }

        public Pedido(int pNumero, string pCliente, int pRucMedicamento, int pCodMedicamento, int pCantidad, int pEstado)
        {
            numero = pNumero;
            cliente = pCliente;
            rucMedicamento = pRucMedicamento;
            codMedicamento = pCodMedicamento;
            cantidad = pCantidad;
            estado = pEstado;
        }
    }
}
