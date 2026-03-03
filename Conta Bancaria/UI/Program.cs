using ContaBancaria.Domain;
using ContaBancaria.Application;

namespace ContaBancaria.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var banco = new Banco();
            var service = new BancoService(banco);
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU:\n\n" +
                                  "1 - Depositar\n" +
                                  "2 - Sacar\n" +
                                  "3 - Transferir\n" +
                                  "4 - Criar Conta\n" +
                                  "5 - Listar Contas\n" +
                                  "6 - Sair");
                int.TryParse(Console.ReadLine(), out opcao);
                try
                {
                    switch (opcao)
                    {
                        case 1:
                            Depositar(service);
                            break;

                        case 2:
                            Sacar(service);
                            break;

                        case 3:
                            Transferir(service);
                            break;

                        case 4:
                            CriarConta(service);
                            break;

                        case 5:
                            Listar(service);
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    Console.ReadKey();
                }
            } while (opcao != 6);
        }

        static void Depositar(BancoService service)
        {
            Console.Clear();
            Console.Write("Deposito:\n\n" +
                          "Número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Valor: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            service.Depositar(numero, valor);
            Console.WriteLine("Depósito realizado!");
            Console.ReadKey();
        }

        static void Sacar(BancoService service)
        {
            Console.Clear();
            Console.Write("Sacar:\n\n" +
                          "Número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Valor: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            service.Sacar(numero, valor);
            Console.Clear();
            Console.WriteLine("Saque realizado!");
            Console.ReadKey();
        }

        static void Transferir(BancoService service)
        {
            Console.Clear();
            Console.Write("Tranferencia:\n\n" +
                          "Conta origem: ");
            int origem = int.Parse(Console.ReadLine());
            Console.Write("Conta destino: ");
            int destino = int.Parse(Console.ReadLine());
            Console.Write("Valor: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            service.Transferir(origem, destino, valor);
            Console.Clear();
            Console.WriteLine("Transferência realizada!");
            Console.ReadKey();
        }

        static void Listar(BancoService service)
        {
            Console.Clear();
            
            var contas = service.ListarContas();
            if (contas == null || !contas.Any())
                Console.WriteLine("Nenhuma conta registrada!");
            else
            {
                Console.WriteLine("Contas Registradas:\n");
                foreach (var conta in contas)
                {
                    Console.WriteLine($"Titular: {conta.Titular}\n" +
                                      $"Número: {conta.Numero}\n" +
                                      $"Saldo: R${conta.Saldo:N2}\n");
                }
            }
            Console.ReadKey();
        }
        static void CriarConta(BancoService service)
        {
            Console.Clear();
            Console.Write("Criação de conta:\n\n" +
                          "Nome do titular: ");
            string nome = Console.ReadLine();

            Console.Write("Número da conta: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Número inválido!");
                Console.ReadKey();
                return;
            }
            service.CriarConta(nome, numero);
            Console.Clear();
            Console.WriteLine("Conta criada com sucesso!");
            Console.ReadKey();
        }
    }
}