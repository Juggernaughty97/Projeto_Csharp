using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_joao_dinis_lib
{
    public class Movimento
    {
        public Movimento(int nrCliente, DateTime dataMovimento, decimal valor)
        {
            this.nrCliente = nrCliente;
            this.dataMovimento = dataMovimento;
            this.valor = valor;
        }

        public int nrCliente { get; set; }
        public DateTime dataMovimento { get; set; }
        public decimal valor { get; set; }
    }
}
