using System;
using Conta_Bancaria;

namespace Conta_Bancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Conta> contas = new List<Conta>();

            Conta conta1 = new Conta("Leonardo", 444222);
            Conta conta2 = new Conta("Maria", 444222);
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine($"Menu:\n\n" +
                                  $"1 - Depositar\n" +
                                  $"2 - Sacar\n" +
                                  $"3 - Transferir\n" +
                                  //$"4 - Criar/Adicionar Conta\n" +
                                  $"5 - Fechar programa");
                opcao = Convert.ToInt32( Console.ReadLine() );
                switch ( opcao )
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Insira o valor para Depositar: ");
                        decimal deposito = decimal.Parse(Console.ReadLine());
                        Console.Clear();
                        try
                        {
                            conta1.Depositar(deposito);
                            Console.WriteLine($"R${deposito} depositado!\n" +
                                              $"Saldo atual: {conta1.Saldo}");
                            Console.ReadKey();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Insira o valor para sacar: ");
                        decimal saque = decimal.Parse(Console.ReadLine());
                        Console.Clear();
                        try
                        {
                            conta1.Sacar(saque);
                            Console.WriteLine("Valor sacado!\n" +
                                              $"Saldo atual: {conta1.Saldo}");
                            Console.ReadKey();
                        }
                        catch ( ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (InvalidCastException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Insira o valor para tranferir: ");
                        decimal transferencia = decimal.Parse(Console.ReadLine());
                        Console.Clear() ;
                        if ( transferencia <= conta1.Saldo)
                        {
                            conta1.Transferir(conta2, transferencia);
                            Console.WriteLine($"Saldo transferido de:\n" +
                                              $"{conta1.Titular} -> {conta2.Titular}\n\n" +
                                              $"Saldo atual: {conta1.Saldo}");
                            Console.ReadKey();
                        }
                        else
                            Console.WriteLine($"Insira um válor valido!\n\n" +
                                              $"Saldo atual: {conta1.Saldo}");
                            Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Criação de Conta\n");
                        Console.Write("Insira o nome do titular da conta: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("\nInsira o número da conta: ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        decimal saldo = 0;
                        Console.WriteLine("Conta criada!");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Programa fechado...");
                        Console.ReadKey();
                        break;
                }
            }while (opcao != 5);
            
        }
    }
}