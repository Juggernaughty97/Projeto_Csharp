using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_joao_dinis_lib
{
    public class Cliente
    {
        public Cliente(int nrCliente, string nome, string morada, string codPostal, string localidade, int telefone, string email, int nrContribuinte, float saldo, DateTime validade)
        {
            this.nrCliente = nrCliente;
            this.nome = nome;
            this.morada = morada;
            this.codPostal = codPostal;
            this.localidade = localidade;
            this.telefone = telefone;
            this.email = email;
            this.nrContribuinte = nrContribuinte;
            this.saldo = saldo;
            this.validade = validade;
        }

        public int nrCliente { get; set; }
        public string nome { get; set; }
        public string morada { get; set; }
        public string codPostal { get; set; }
        public string localidade { get; set; }
        public int telefone { get; set; }
        public string email { get; set; }
        public int nrContribuinte { get; set; }
        public float saldo { get; set; }
        public DateTime validade { get; set; }
    }
}
