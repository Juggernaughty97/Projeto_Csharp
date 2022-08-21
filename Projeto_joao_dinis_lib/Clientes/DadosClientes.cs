using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_joao_dinis_lib
{
    public class DadosClientes
    {
        string FilePath = $@"{Environment.CurrentDirectory}\clientes.csv";
        public List <Cliente> Clientes { get; set; }
        public DadosClientes()
        {
            Clientes = new List<Cliente>();
        }
        public bool LerDados()
        {
            
            char[] delimitadores = { ';', '\t' };

            try
            {
                StreamReader streamReader = new StreamReader(FilePath);
                string linha;

                while((linha = streamReader.ReadLine()) != null)
                {
                    string[] tokens = linha.Split(delimitadores);

                    if(tokens.Length != 10)
                    {
                        continue;
                    }

                    int nrCliente = int.Parse(tokens[0]);
                    string nome = tokens[1];
                    string morada = tokens[2];
                    string codPostal = tokens[3];
                    string localidade = tokens[4];
                    int telefone = int.Parse(tokens[5]);
                    string email = tokens[6];
                    int nrContribuinte = int.Parse(tokens[7]);
                    float saldo = float.Parse(tokens[8]);
                    DateTime validade = Convert.ToDateTime(tokens[9]);

                    Cliente cliente = new Cliente(nrCliente, nome, morada, codPostal, localidade, telefone, email, nrContribuinte, saldo, validade);
                    Clientes.Add(cliente);
                }
                streamReader.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool GuardarDados()
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(FilePath);
                string linha;

                foreach(Cliente cliente in Clientes)
                {
                    linha = cliente.nrCliente + ";" + cliente.nome + ";" + cliente.morada + ";" + cliente.codPostal + ";" + cliente.localidade + ";" + cliente.telefone + ";" + cliente.email + ";" + cliente.nrContribuinte + ";" + cliente.saldo + ";" + cliente.validade;

                    streamWriter.WriteLine(linha);
                }
                streamWriter.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AdicionarCliente()
        {
            throw new NotImplementedException();
        }

        public void EliminarCliente()
        {
            throw new NotImplementedException();
        }

        public void ModificarCliente()
        {
            throw new NotImplementedException();
        }

        public void AdicionarConsumo(int nrCliente)
        {
            throw new NotImplementedException();
        }

        public void AdicionarCarregamento(int nrCliente)
        {
            throw new NotImplementedException();
        }
    }
}
