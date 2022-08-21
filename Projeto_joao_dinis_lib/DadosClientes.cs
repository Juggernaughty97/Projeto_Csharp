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
        string FilePathClientes = $@"C:\Users\Test\Code\C#\Exercicios\Projeto_joao_dinis\Projeto_joao_dinis_lib\Clientes\clientes.csv";
        string FilePathMovimentos = $@"C:\Users\Test\Code\C#\Exercicios\Projeto_joao_dinis\Projeto_joao_dinis_lib\Movimentos\movimentos.csv";
        public List <Cliente> Clientes { get; set; }
        public List <Movimento> Movimentos { get; set; }
        public DadosClientes()
        {
            Clientes = new List<Cliente>();
            Movimentos = new List<Movimento>();
        }
        public bool LerDadosClientes()
        {
            
            char[] delimitadores = { ';', '\t' };

            try
            {
                StreamReader streamReader = new StreamReader(FilePathClientes);
                string linha;

                while((linha = streamReader.ReadLine()) != null)
                {
                    string[] tokens = linha.Split(delimitadores);

                    if(tokens.Length != 11)
                    {
                        continue;
                    }

                    int nrCliente = int.Parse(tokens[0]);
                    bool estado = bool.Parse(tokens[1]);
                    string nome = tokens[2];
                    string morada = tokens[3];
                    string codPostal = tokens[4];
                    string localidade = tokens[5];
                    int telefone = int.Parse(tokens[6]);
                    string email = tokens[7];
                    int nrContribuinte = int.Parse(tokens[8]);
                    decimal saldo = decimal.Parse(tokens[9]);
                    DateTime validade = Convert.ToDateTime(tokens[10]);

                    Cliente cliente = new Cliente(nrCliente, estado, nome, morada, codPostal, localidade, telefone, email, nrContribuinte, saldo, validade);
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

        public bool GuardarDadosClientes()
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(FilePathClientes);
                string linha;

                foreach(Cliente cliente in Clientes)
                {
                    linha = cliente.nrCliente + ";" + cliente.estado + ";" + cliente.nome + ";" + cliente.morada + ";" + cliente.codPostal + ";" + cliente.localidade + ";" + cliente.telefone + ";" + cliente.email + ";" + cliente.nrContribuinte + ";" + cliente.saldo + ";" + cliente.validade;

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

        public void AdicionarCliente(string nome, string morada, string codPostal, string localidade, int telefone, string email, int nrContribuinte)
        {

            Cliente cliente = new Cliente(SetIndex(), true, nome, morada, codPostal, localidade, telefone, email, nrContribuinte, 0, DateTime.Now);

            Clientes.Add(cliente);

            GuardarDadosClientes();
        }

        public bool EliminarCliente(int nrCliente)
        {

            foreach(Cliente cliente in Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                {
                    cliente.estado = false;
                    GuardarDadosClientes();
                    return true;
                }
            }
            return false;
        }
        public void ModificarEstado(int nrCliente, bool estado)
        {
            
            foreach (Cliente cliente in Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                {
                    if (cliente.estado == estado)
                    {
                        Console.WriteLine("\nCliente já estava ativo!\n");
                        break;
                    }
                    else
                    {
                        cliente.estado = estado;
                        GuardarDadosClientes();
                    }    
                }
            }
        }

        public void ModificarNome(int nrCliente, string nome)
        {
            foreach (Cliente cliente in Clientes)
            {
                if(cliente.nrCliente == nrCliente)
                {
                    cliente.nome = nome;
                    GuardarDadosClientes();
                }
            }
        }
        public void ModificarMorada(int nrCliente, string morada)
        {
            foreach (Cliente cliente in Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                {
                    cliente.morada = morada;
                    GuardarDadosClientes();
                }
            }
        }
        public void ModificarCodPostal(int nrCliente, string codPostal)
        {
            foreach (Cliente cliente in Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                {
                    cliente.codPostal = codPostal;
                    GuardarDadosClientes();
                }
            }
        }
        public void ModificarLocalidade(int nrCliente, string localidade)
        {
            foreach (Cliente cliente in Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                {
                    cliente.localidade = localidade;
                    GuardarDadosClientes();
                }
            }
        }
        public void ModificarTelefone(int nrCliente, int telefone)
        {
            foreach (Cliente cliente in Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                {
                    cliente.telefone = telefone;
                    GuardarDadosClientes();
                }
            }
        }
        public void ModificarEmail(int nrCliente, string email)
        {
            foreach (Cliente cliente in Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                {
                    cliente.email = email;
                    GuardarDadosClientes();
                }
            }
        }
        public void ModificarNrContribuinte(int nrCliente, int nrContribuinte)
        {
            foreach (Cliente cliente in Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                {
                    cliente.nrContribuinte = nrContribuinte;
                    GuardarDadosClientes();
                }
            }
        }

        public bool AdicionarConsumo(int nrCliente, decimal valor)
        {
            Movimento movimento = new Movimento(nrCliente, DateTime.Now, -valor);
  
            foreach (Cliente cliente in Clientes)
            {
                if(cliente.nrCliente == nrCliente)
                {
                    if (cliente.saldo >= valor)
                    {
                        cliente.saldo -= valor;
                        
                        Movimentos.Add(movimento);

                        GuardarDadosMovimentos(movimento);
                        GuardarDadosClientes();
                    }
                    else
                        return false;  
                }
            }
            return true;
        }

        public void AdicionarCarregamento(int nrCliente, decimal valor)
        {
            Movimento movimento = new Movimento(nrCliente, DateTime.Now, valor);

            foreach (Cliente cliente in Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                {
                    cliente.saldo += valor;
                    cliente.validade = DateTime.Now.AddDays(30);
                    Movimentos.Add(movimento);

                    GuardarDadosMovimentos(movimento);
                    GuardarDadosClientes();
                }
            }
        }

        public int SetIndex()
        {
            if (Clientes.Count() == 0)
                return 1;
            return Clientes.Count() + 1;
        }

        public bool LerDadosMovimentos()
        {

            char[] delimitadores = { ';', '\t' };

            try
            {
                StreamReader streamReader = new StreamReader(FilePathMovimentos);
                string linha;

                while ((linha = streamReader.ReadLine()) != null)
                {
                    string[] tokens = linha.Split(delimitadores);

                    if (tokens.Length != 3)
                    {
                        continue;
                    }
                    
                    int nrCliente = int.Parse(tokens[0]);
                    DateTime dataMovimento = Convert.ToDateTime(tokens[1]);
                    decimal valor = decimal.Parse(tokens[2]);

                    Movimento movimento = new Movimento(nrCliente, dataMovimento, valor);
                    Movimentos.Add(movimento);
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

        public bool GuardarDadosMovimentos(Movimento movimento)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(FilePathMovimentos, true);
                string linha;

                
                linha = movimento.nrCliente + ";" + movimento.dataMovimento + ";" + movimento.valor;

                streamWriter.WriteLine(linha);
                
                streamWriter.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
