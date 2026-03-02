using System;
using System.ComponentModel;
using Conta_Bancaria;

namespace Conta_Bancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();
            banco.AddConta(new Conta("Leonardo", 444222));
            banco.AddConta(new Conta("Maria", 444223));
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine($"Menu:\n\n" +
                                  $"1 - Depositar\n" +
                                  $"2 - Sacar\n" +
                                  $"3 - Transferir\n" +
                                  $"4 - Criar/Adicionar Conta\n" +
                                  $"5 - Listar contas\n" +
                                  $"6 - Fechar programa");
                opcao = Convert.ToInt32( Console.ReadLine() );
                switch ( opcao )
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.Write("Insira o valor para Depositar: ");
                            decimal deposito = decimal.Parse(Console.ReadLine());

                            Conta conta = ObterConta(banco);
                            if (conta == null)
                            {
                                Console.ReadKey();
                                break;
                            }

                            try
                            {
                                conta.Depositar(deposito);
                                Console.WriteLine($"R${deposito} depositado!");
                                Console.WriteLine($"Saldo atual: {conta.Saldo}");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.Write("Insira o valor para sacar: ");
                            decimal saque = decimal.Parse(Console.ReadLine());

                            Conta conta = ObterConta(banco);
                            if (conta == null)
                            {
                                Console.ReadKey();
                                break;
                            }

                            try
                            {
                                conta.Sacar(saque);
                                Console.WriteLine($"Valor sacado!");
                                Console.WriteLine($"Saldo atual: {conta.Saldo}");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.Write("Conta de origem: ");
                            Conta origem = ObterConta(banco);
                            if (origem == null)
                            {
                                Console.ReadKey();
                                break;
                            }
                            Console.Write("Conta de destino: ");
                            Conta destino = ObterConta(banco);
                            if (destino == null)
                            {
                                Console.ReadKey();
                                break;
                            }
                            Console.Write("Valor para transferir: ");
                            decimal transferencia = decimal.Parse(Console.ReadLine());

                            if (transferencia <= origem.Saldo)
                            {
                                origem.Transferir(destino, transferencia);
                                Console.WriteLine($"Saldo transferido de {origem.Titular} -> {destino.Titular}");
                                Console.WriteLine($"Saldo atual: {origem.Saldo}");
                            }
                            else
                            {
                                Console.WriteLine("Saldo insuficiente para realizar a transferência!");
                                Console.WriteLine($"Saldo atual: {origem.Saldo}");
                            }
                            Console.ReadKey();
                            break;
                        }

                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Criação de Conta\n");
                            Console.Write("Insira o nome do titular da conta: ");
                            string nome = Console.ReadLine();
                            Console.Write("Insira o número da conta: ");
                            if (!int.TryParse(Console.ReadLine(), out int num))
                            {
                                Console.Clear();
                                Console.WriteLine("Número de conta inválido!");
                                Console.ReadKey();
                                break;
                            }
                            banco.AddConta(new Conta(nome, num));
                            Console.Clear();
                            Console.WriteLine("Conta criada com sucesso!");
                            Console.ReadKey();
                            break;
                        }

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Contas Registradas:\n");
                        banco.ListarContas();
                        Console.ReadKey();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Programa fechado...");
                        Console.ReadKey();
                        break;
                }
            }while (opcao != 6);
            
        }
        private static Conta ObterConta(Banco banco)
        {
            Console.Write("Número da conta: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Número inválido!");
                return null;
            }
            Conta conta = banco.BuscarConta(numero);
            if (conta == null)
                Console.WriteLine("Conta não encontrada!");

            return conta;
        }
    }
}