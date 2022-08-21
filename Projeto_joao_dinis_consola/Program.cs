using Projeto_joao_dinis_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_joao_dinis
{
    class Program
    {
        static DadosClientes dadosClientes = new DadosClientes();
        static void Main(string[] args)
        {
            Menu();
        }

        static private int Menu()
        {
            Console.OutputEncoding = Encoding.Default;
            int nrCliente, opcao = 0;
            decimal valor;

            if (!dadosClientes.LerDadosClientes() || !dadosClientes.LerDadosMovimentos())
            {
                Console.WriteLine("Erro ao ler o ficheiro");
                Console.WriteLine("Pressione ENTER para sair...");
                Console.ReadLine();
                return -1;
            }

            while (true)
            {
                Console.WriteLine("00. Sair do Programa");
                Console.WriteLine("01. Listar todos os Clientes Ativos");
                Console.WriteLine("02. Listar os Clientes Ativos com saldo disponível");
                Console.WriteLine("03. Listar os Clientes Ativos com data de validade expirada");
                Console.WriteLine("04. Listar todos os dados de um único cliente");
                Console.WriteLine("05. Adicionar um novo Cliente");
                Console.WriteLine("06. Eliminar um Cliente");
                Console.WriteLine("07. Modificar os dados de um Cliente");
                Console.WriteLine("08. Listar os carregamentos de um Cliente");
                Console.WriteLine("09. Listar os consumos de um Cliente");
                Console.WriteLine("10. Adicionar um consumo de um Cliente");
                Console.WriteLine("11. Adicionar um carregamento de um cliente");
                Console.Write("\nEscolha uma das opções: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                }

                switch (opcao)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Clear();
                        ListarClientes(false);
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        ListarAtivosComSaldo();
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        ListarAtivosComDataExp();
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        try
                        {
                            Console.Clear();
                            if (ListarClientes(true))
                            {
                                Console.Write("\nInsira o número do cliente a listar: ");
                                nrCliente = int.Parse(Console.ReadLine());
                                Console.Clear();
                                ListarUmCliente(nrCliente);
                            } 
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                        }
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("\nInsira os dados do cliente: ");
                            
                            Console.Write("\nNome: ");
                            string nome = Console.ReadLine();
                            Console.Write("Morada: ");
                            string morada = Console.ReadLine();
                            Console.Write("Código Postal: ");
                            string codPostal = Console.ReadLine();
                            Console.Write("Localidade: ");
                            string localidade = Console.ReadLine();
                            Console.Write("Telefone: ");
                            int telefone = int.Parse(Console.ReadLine());
                            Console.Write("E-mail: ");
                            string email = Console.ReadLine();
                            Console.Write("Número de Contribuinte: ");
                            int nrContribuinte = int.Parse(Console.ReadLine());

                            dadosClientes.AdicionarCliente(nome, morada, codPostal, localidade, telefone, email, nrContribuinte);
                            Console.WriteLine("\nNovo cliente adicionado.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                        }
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        try
                        {
                            Console.Clear();
                            if (ListarClientes(false)){
                                Console.Write("\nInsira o número do cliente a eliminar: ");
                                nrCliente = int.Parse(Console.ReadLine());

                                if (!dadosClientes.EliminarCliente(nrCliente))
                                {
                                    Console.WriteLine("\nErro! Cliente não encontrado\n");
                                }
                                else
                                {
                                    Console.WriteLine("\nCliente eliminado.\n");
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                        }
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 7:
                        try
                        {
                            Console.Clear();
                            ListarClientes(true);
                            Console.Write("\nInsira o número do cliente a modificar os dados: ");
                            nrCliente = int.Parse(Console.ReadLine());

                            Console.Clear();
                            
                            if (!ListarUmCliente(nrCliente))
                                Menu();
                            
                            Console.WriteLine("\n");
                            Console.WriteLine("00. Voltar ao menu");
                            Console.WriteLine("01. Activar cliente");
                            Console.WriteLine("02. Nome");
                            Console.WriteLine("03. Morada");
                            Console.WriteLine("04. Código Postal");
                            Console.WriteLine("05. Localidade");
                            Console.WriteLine("06. Telefone");
                            Console.WriteLine("07. E-mail");
                            Console.WriteLine("08. Número de Contribuinte");
                            Console.Write("\nEscolha uma das opções: ");
                            opcao = int.Parse(Console.ReadLine());

                            switch (opcao)
                            {
                                case 0:
                                    Console.Clear();
                                    break;
                                case 1:
                                    try
                                    {
                                        bool estado = true;
                                        dadosClientes.ModificarEstado(nrCliente, estado);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                                    }
                                    Console.Clear();
                                    Console.WriteLine("\nCliente activado.\n");
                                    Console.WriteLine("Pressione ENTER para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 2:

                                    try
                                    {
                                        Console.Write("Insira o novo nome: ");
                                        string nome = Console.ReadLine();
                                        dadosClientes.ModificarNome(nrCliente, nome);
                                    }
                                    catch(Exception)
                                    {
                                        Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                                    }
                                    Console.WriteLine("Pressione ENTER para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 3:
                                    try
                                    {
                                        Console.Write("Insira a nova morada: ");
                                        string morada = Console.ReadLine();  
                                        dadosClientes.ModificarMorada(nrCliente, morada);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                                    }
                                    Console.WriteLine("Pressione ENTER para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 4:
                                    try
                                    {
                                        Console.Write("Insira o novo código postal: ");
                                        string codPostal = Console.ReadLine();
                                        dadosClientes.ModificarCodPostal(nrCliente, codPostal);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                                    }
                                    Console.WriteLine("Pressione ENTER para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 5:
                                    try
                                    {
                                        Console.Write("Insira a nova localidade: ");
                                        string localidade = Console.ReadLine();
                                        dadosClientes.ModificarLocalidade(nrCliente, localidade);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nErro! Introduziu um valor inválido...\n");;
                                    }
                                    Console.WriteLine("Pressione ENTER para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 6:
                                    try
                                    {
                                        Console.Write("Insira o novo telefone: ");
                                        int telefone = int.Parse(Console.ReadLine());
                                        dadosClientes.ModificarTelefone(nrCliente, telefone);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                                    }
                                    Console.WriteLine("Pressione ENTER para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 7:
                                    try
                                    {
                                        Console.Write("Insira o novo email: ");
                                        string email = Console.ReadLine();
                                        dadosClientes.ModificarEmail(nrCliente, email);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                                    }
                                    Console.WriteLine("Pressione ENTER para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 8:
                                    try
                                    {
                                        Console.Write("Insira o novo número de contribuinte: ");
                                        int nrContribuinte = int.Parse(Console.ReadLine());
                                        dadosClientes.ModificarNrContribuinte(nrCliente, nrContribuinte);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                                    }
                                    Console.WriteLine("Pressione ENTER para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("\nErro! Insira uma opção válida!\n");
                                    Console.WriteLine("Pressione ENTER para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                            Console.WriteLine("Pressione ENTER para continuar...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case 8:
                        
                        try
                        {
                            Console.Clear();
                            ListarClientes(false);
                            Console.Write("\nInsira o número do cliente a listar os carregamentos: ");
                            nrCliente = int.Parse(Console.ReadLine());
                            Console.Clear();
                            ListarCarregamentos(nrCliente);
                        }
                       
                        catch (Exception e)
                        {
                            Console.WriteLine("\nIntroduziu um valor inválido...\n");
                        }
                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 9:
                        
                        try
                        {
                            Console.Clear();
                            ListarClientes(false);
                            Console.Write("\nInsira o número do cliente a listar os consumos: ");
                            nrCliente = int.Parse(Console.ReadLine());
                            Console.Clear();
                            ListarConsumos(nrCliente);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                        }
                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 10:

                        try
                        {
                            Console.Clear();
                            ListarClientes(true);
                            Console.Write("\nInsira o número do cliente a adicionar um consumo: ");
                            nrCliente = int.Parse(Console.ReadLine());
                            Console.Write("\nInsira o valor do consumo: ");
                            valor = decimal.Parse(Console.ReadLine());
                            if(!dadosClientes.AdicionarConsumo(nrCliente, valor))
                            {
                                Console.WriteLine("Erro! O saldo é inferior ao consumo.");
                            }
                            else
                                Console.WriteLine("\nConsumo adicionado.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                        }
                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 11:

                        try
                        {
                            Console.Clear();
                            ListarClientes(true);
                            Console.Write("\nInsira o número do cliente a adicionar um carregamento: ");
                            nrCliente = int.Parse(Console.ReadLine());
                            Console.Write("\nInsira o valor do carregamento (valor mínimo de 5,00 EUR): ");
                            valor = Math.Round(decimal.Parse(Console.ReadLine()), 2);

                            if(valor < 5)
                            {
                                Console.WriteLine("\nERRO! O valor inserido é inferior a 5,00 EUR.\n");
                            }
                            dadosClientes.AdicionarCarregamento(nrCliente, valor);
                            Console.WriteLine("\nCarregamento adicionado.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nErro! Introduziu um valor inválido...\n");
                        }
                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("\nErro! Insira uma opção válida!\n");
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        private static bool ListarConsumos(int nrCliente)
        {
            int cont = 0;
            string nome = "";

            if(dadosClientes.Movimentos.Count == 0)
            {
                Console.WriteLine("Não existem movimentos a apresentar.");
                return false;
            }

            foreach (Cliente cliente in dadosClientes.Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                    nome = cliente.nome;
            }

            foreach (Movimento movimento in dadosClientes.Movimentos)
            {
                if (movimento.nrCliente == nrCliente && movimento.valor < 0)
                {
                    cont++;
                }
            }

            if (cont == 0)
            {
                Console.WriteLine("\nNão existem consumos a apresentar.");
                return false;
            }

            Console.WriteLine("\nNúmero Cliente......." + nrCliente +
                              "\nNome................." + nome +
                              "\nConsumos:");

            foreach (Movimento movimento in dadosClientes.Movimentos)
            {
                if(movimento.nrCliente == nrCliente && movimento.valor < 0)
                {
                    Console.WriteLine("   >" + movimento.dataMovimento + $" ...  {Math.Abs(movimento.valor):C2}");
                }
            }
            return true;
        }

        private static bool ListarCarregamentos(int nrCliente)
        {
            int cont = 0;
            string nome = "";

            if (dadosClientes.Movimentos.Count == 0)
            {
                Console.WriteLine("Não existem movimentos a apresentar.");
                return false;
            }

            foreach (Cliente cliente in dadosClientes.Clientes)
            {
                if (cliente.nrCliente == nrCliente)
                    nome = cliente.nome;
            }

            foreach (Movimento movimento in dadosClientes.Movimentos)
            {
                if (movimento.nrCliente == nrCliente && movimento.valor > 0)
                {
                    cont++;
                }
            }

            if (cont == 0)
            {
                Console.WriteLine("\nNão existem carregamentos a apresentar.");
                return false;
            }

            Console.WriteLine("\nNúmero Cliente......." + nrCliente +
                              "\nNome................." + nome +
                              "\nConsumos:");

            foreach (Movimento movimento in dadosClientes.Movimentos)
            {
                if (movimento.nrCliente == nrCliente && movimento.valor > 0)
                {
                    Console.WriteLine("   >" + movimento.dataMovimento + $" ... {movimento.valor:C2}");
                }
            }
            return true;
        }

        private static bool ListarUmCliente(int nrCliente)
        {
            if (dadosClientes.Clientes.Count == 0)
            {
                Console.WriteLine("\nNão existem clientes na lista.\n");
                return false;
            }
            Console.Write("\n----------------------------------------------");
            foreach (Cliente cliente in dadosClientes.Clientes)
            {
                if(cliente.nrCliente == nrCliente)
                        Console.WriteLine("\nNúmero Cliente............ " + cliente.nrCliente +
                        "\nNome...................... " + cliente.nome +
                        "\nMorada.................... " + cliente.morada +
                        "\nCódigo Postal............. " + cliente.codPostal +
                        "\nLocalidade................ " + cliente.localidade +
                        "\nTelefone.................. " + cliente.telefone +
                        "\nE-mail.................... " + cliente.email +
                        "\nNº Contribuinte........... " + cliente.nrContribuinte +
                        $"\nSaldo Disponível.........  {cliente.saldo:C2}" +
                        "\nData de Validade.......... " + cliente.validade +
                        "\n----------------------------------------------");
            }
            return true;
        }

        private static void ListarAtivosComDataExp()
        {
            int cont = 0;
            DateTime dt;

            if (dadosClientes.Clientes.Count == 0)
            {
                Console.WriteLine("\nNão existem clientes na lista.");
                return;
            }

            foreach (Cliente cliente in dadosClientes.Clientes)
            {
                if (cliente.validade < DateTime.Now)
                {
                    cont++;

                    Console.WriteLine("\n-----------------------------------------" +
                            "\nNumero Cliente...... " + cliente.nrCliente +
                            "\nNome................ " + cliente.nome +
                            $"\nSaldo Disponível.... {cliente.saldo:C2}" +
                            "\nData de Validade.... " + cliente.validade +
                            "\n-----------------------------------------");
                }
            }
            if (cont == 0)
            {
                Console.WriteLine("\nNão existem clientes com data de validade expirada.\n");
            }

        }

        private static void ListarAtivosComSaldo()
        {
            int cont = 0;

            if (dadosClientes.Clientes.Count == 0)
            {
                Console.WriteLine("\nNão existem clientes na lista.");
                return;
            }
                
            foreach (Cliente cliente in dadosClientes.Clientes)
            {
                if(cliente.saldo > 0)
                {
                    cont++;

                    Console.WriteLine("\n-----------------------------------------" +
                            "\nNumero Cliente...... " + cliente.nrCliente +
                            "\nNome................ " + cliente.nome +
                            $"\nSaldo Disponível.... {cliente.saldo:C2}" +
                            "\nData de Validade.... " + cliente.validade +
                            "\n-----------------------------------------");
                }  
            }
            if (cont == 0)
            {
                Console.WriteLine("\nNão existem clientes com saldo disponível.\n");
            }
        }

        static private bool ListarClientes(bool todos)
        {
            int cont = 0;

            if (dadosClientes.Clientes.Count == 0)
            {
                Console.WriteLine("\nNão existem clientes na lista.");
                return false;
            }

            
            
            foreach (Cliente cliente in dadosClientes.Clientes)
            {
                if (!todos)
                {
                    if (cliente.estado == true)
                    {
                        cont++;

                        Console.Write("\n----------------------------------------------");
                        Console.Write("\nNúmero cliente............. " + cliente.nrCliente +
                           "\nNome....................... " + cliente.nome +
                           "\nNúmero de Contribuinte..... " + cliente.nrContribuinte +
                           $"\nSaldo Disponível........... {cliente.saldo:C2}");
                        Console.Write("\n----------------------------------------------\n");
                    }
                    if (cont == 0)
                        Console.WriteLine("\nNão existem clientes activos.\n");
                }
                else
                {
                    
                    Console.Write("\n----------------------------------------------");
                    Console.Write("\nNúmero cliente............. " + cliente.nrCliente +
                       "\nNome....................... " + cliente.nome +
                       "\nNúmero de Contribuinte..... " + cliente.nrContribuinte +
                       $"\nSaldo Disponível........... {cliente.saldo:C2}");
                    Console.Write("\n----------------------------------------------\n");

                    
                }
            }
            return true;
        }
    }
}