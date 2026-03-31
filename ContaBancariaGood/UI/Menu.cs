using ContaBancariaGood.Application.Services;

namespace ContaBancariaGood.UI
{
    public class Menu
    {
        private readonly BancoService _service;

        public Menu(BancoService service)
        {
            _service = service;
        }
        public void Executar()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("""
                MENU:

                1 - Depositar
                2 - Sacar
                3 - Transferir
                4 - Criar Conta
                5 - Listar Contas
                6 - Sair
                """);

                int.TryParse(Console.ReadLine(), out opcao);

                try
                {
                    switch (opcao)
                    {
                        case 1: Depositar(); break;
                        case 2: Sacar(); break;
                        case 3: Transferir(); break;
                        case 4: CriarConta(); break;
                        case 5: Listar(); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    Console.ReadKey();
                }

            } while (opcao != 6);
        }
        private void Depositar()
        {
            Console.Clear();
            Console.Write("Conta: ");
            string numero = Console.ReadLine();
            decimal valor = LerDecimal("Valor: ");  

            _service.Depositar(numero, valor);

            Console.WriteLine("Depósito realizado!");
            Console.ReadKey();
        }
        private void Sacar()
        {
            Console.Clear();
            Console.Write("Conta: ");
            string numero = Console.ReadLine();
            decimal valor = LerDecimal("Valor: ");

            _service.Sacar(numero, valor);

            Console.WriteLine("Saque realizado!");
            Console.ReadKey();
        }
        private void Transferir()
        {
            Console.Clear();
            Console.Write("Origem: ");
            string origem = Console.ReadLine();
            Console.Write("Destino: ");
            string destino = Console.ReadLine();
            decimal valor = LerDecimal("Valor: ");

            _service.Transferir(origem, destino, valor);

            Console.WriteLine("Transferência realizada!");
            Console.ReadKey();
        }
        private void CriarConta()
        {
            Console.Clear();
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Numero: ");
            string numero = Console.ReadLine();

            _service.CriarConta(nome, numero);

            Console.WriteLine("Conta criada!");
            Console.ReadKey();
        }
        private void Listar()
        {
            Console.Clear();
            var contas = _service.ListarContas();

            if (!contas.Any())
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
            }
            else
            {
                foreach (var conta in contas)
                {
                    Console.WriteLine($"""
                    Titular: {conta.Titular}
                    Número: {conta.Numero}
                    Saldo: R$ {conta.Saldo:N2}
                    """);
                }
            }
            Console.ReadKey();
        }
        private decimal LerDecimal(string mensagem)
        {
            Console.Write(mensagem);
            return decimal.Parse(Console.ReadLine());
        }
    }
}
