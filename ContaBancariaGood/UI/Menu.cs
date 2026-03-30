using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            int numero = LerInt("Conta: ");
            decimal valor = LerDecimal("Valor: ");

            _service.Depositar(numero, valor);

            Console.WriteLine("Depósito realizado!");
            Console.ReadKey();
        }
        private void Sacar()
        {
            int numero = LerInt("Conta: ");
            decimal valor = LerDecimal("Valor: ");

            _service.Sacar(numero, valor);

            Console.WriteLine("Saque realizado!");
            Console.ReadKey();
        }
        private void Transferir()
        {
            int origem = LerInt("Origem: ");
            int destino = LerInt("Destino: ");
            decimal valor = LerDecimal("Valor: ");

            _service.Transferir(origem, destino, valor);

            Console.WriteLine("Transferência realizada!");
            Console.ReadKey();
        }
        private void CriarConta()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            int numero = LerInt("Número: ");

            _service.CriarConta(nome, numero);

            Console.WriteLine("Conta criada!");
            Console.ReadKey();
        }
        private void Listar()
        {
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
        private int LerInt(string mensagem)
        {
            Console.Write(mensagem);
            return int.Parse(Console.ReadLine());
        }
        private decimal LerDecimal(string mensagem)
        {
            Console.Write(mensagem);
            return decimal.Parse(Console.ReadLine());
        }
    }
}
