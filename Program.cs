using System;
using System.Collections.Generic; //biblioteca para usar a lista

namespace Atividade_Fran
{
    class Program
    {
        static List<Carro> carros = new List<Carro>(); //lista de carros
        static List<Cliente> clientes = new List<Cliente>(); //lista de clientes
        static List<Aluguel> alugueis = new List<Aluguel>();//lista de alugueis
        static void Main(string[] args)
        {
            iniciarListaCarros();
            iniciarClientes();

            bool rodando = true;

            while (rodando) // operação para rodar o código em loop
            {
                Console.WriteLine("Pressione 'c' se você for cliente ou 's' se você for administrador do sistema.\n");

                string opcao;

                opcao = Console.ReadLine();

                if (opcao == "s")
                {
                    Console.WriteLine("Pressione '1' para registrar um cliente ou '2' para registrar um carro\n");

                    string opcaoSistema = Console.ReadLine();
                    if (opcaoSistema == "1")
                    {
                        Console.WriteLine("Informe Nome, CPF, Endereço, CNH e Telefone.\n");

                        string nome = Console.ReadLine();
                        string cpf = Console.ReadLine();
                        string endereco = Console.ReadLine();
                        string cnh = Console.ReadLine();
                        string telefone = Console.ReadLine();

                        cadastrarCliente(nome, cpf, endereco, cnh, telefone);

                        Console.WriteLine("Cliente cadastrado com sucesso!\n");
                    }
                    else
                    {
                        Console.WriteLine("Informe a Marca, modelo, ano, Chassi e preço.\n");

                        string marca = Console.ReadLine();
                        string modelo = Console.ReadLine();
                        int ano = Int32.Parse(Console.ReadLine());
                        string chassi = Console.ReadLine();
                        double preco = double.Parse(Console.ReadLine());

                        cadastrarCarro(marca, modelo, ano, chassi, preco);

                        Console.WriteLine("Carro cadastrado com sucesso!\n");
                    }
                }
                else
                {
                    Console.Write("Pressione '1' se você quiser alugar um carro ou pressione '2' se você quiser devolver um carro.\n");

                    string opcaoCliente = Console.ReadLine();

                    if (opcaoCliente == "1")
                    {
                        Console.WriteLine("Essas são as opções de carros: \n");

                        for (int i = 0; i < carros.Count; i++)
                        {
                            Console.WriteLine("Opção " + i + ": " + carros[i].Marca + " " + carros[i].Modelo + " " + carros[i].Ano + " " + carros[i].Preco + " reais a hora. \n");
                        }

                        Console.WriteLine("Por favor insira o CPF, nome, quantidade de horas e a opção do carro. \n");

                        string cpf = Console.ReadLine();
                        string nome = Console.ReadLine();
                        int qntHoras = Int32.Parse(Console.ReadLine());
                        int opcaoCarro = Int32.Parse(Console.ReadLine());

                        registrarAluguel(nome, cpf, qntHoras, opcaoCarro);
                    }
                    else
                    {
                        Console.WriteLine("Insira seu CPF\n");

                        string cpf = Console.ReadLine();

                        registrarDevolucao(cpf);
                    }
                }

                Console.WriteLine("Digite 's' se quiser realizar outra operação ou digite 'n' se quiser fechar o programa. \n");

                rodando = "s" == Console.ReadLine();
            }
        }

        static bool verificarCliente(string cpf) // método para verificar se o cliente ja está cadastrado
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.CPF == cpf)
                {
                    return true;
                }
            }
            Console.WriteLine("CPF inválido!\n");
            return false;
        }

        static bool verificarCarro(int index) // método para verificar se o carro está disponível
        {
            foreach (Cliente cliente in clientes)
            {
                if (!carros[index].Status)
                {
                    Console.WriteLine("Carro indisponível!\n");
                    return false;
                }
            }

            return true;
        }
        static void registrarAluguel(string nome, string cpf, int horas, int indexCarro) // metódo para registrar o aluguel
        {
            if (!verificarCliente(cpf))
            {
                return;
            }

            if (indexCarro >= carros.Count)
            {
                Console.WriteLine("Carro inexistente!\n");
                return;
            }

            if (!verificarCarro(indexCarro))
            {
                return;
            }

            carros[indexCarro].Status = false;

            Console.WriteLine("Carro alugado com sucesso! O valor do aluguel é: " + carros[indexCarro].calcularPreco(horas) + "\n");

            alugueis.Add(new Aluguel(carros[indexCarro], cpf));
            return;

        }

        static void registrarDevolucao(string cpf) // método para registrar a devolução
        {
            if (!verificarCliente(cpf))
            {
                return;
            }

            foreach (Aluguel aluguel in alugueis)
            {
                if (aluguel.cpfCliente == cpf)
                {
                    aluguel.carro.Status = true;
                    alugueis.Remove(aluguel);
                    Console.WriteLine("Devolução efetuada com sucesso!!!\n");
                    return;
                }
            }
            Console.WriteLine("Cliente não possue aluguel registrado!\n");
        }
        static void cadastrarCarro(string marca, string modelo, int ano, string chassi, double preco) // método para cadastrar o carro
        {
            carros.Add(new Carro(marca, modelo, ano, chassi, preco, true));
        }
        static void cadastrarCliente(string nome, string cpf, string endereco, string cnh, string telefone) // método para cadastrar o cliente
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.CPF == cpf)
                {
                    cliente.Nome = nome;
                    cliente.Endereco = endereco;
                    cliente.CNH = cnh;
                    cliente.Telefone = telefone;
                    return;
                }
            }

            clientes.Add(new Cliente(cpf, nome, endereco, cnh, telefone));

        }
        static void iniciarListaCarros() // método com os carros já criados
        {
            carros.Add(new Carro("Ford", "Focus", 2012, "000000000", 100, false));
            carros.Add(new Carro("Fiat", "Toro", 2015, "000000000", 150, true));
            carros.Add(new Carro("Chevrolet", "Camaro", 2019, "000000000", 600, false));
            carros.Add(new Carro("Audi", "TT", 2006, "000000000", 400, true));
            carros.Add(new Carro("Ferrari", "California", 2021, "000000000", 1000, true));
        }
        static void iniciarClientes() // método com os clientes já criados
        {
            clientes.Add(new Cliente("070.707.070-70", "Renata", "Rua boa vista, 28", "000000000", "71981406641"));
            clientes.Add(new Cliente("060.060.060-60", "Luis", "Rua boa vista, 28", "000000000", "71981406641"));
            clientes.Add(new Cliente("050.050.050-50", "Rogerio", "Rua boa vista, 28", "000000000", "71981406641"));
            clientes.Add(new Cliente("040.040.040-40", "Genison", "Rua boa vista, 28", "000000000", "71981406641"));
            clientes.Add(new Cliente("030.030.030-30", "Humberto", "Rua boa vista, 28", "000000000", "71981406641"));
        }
    }
}
