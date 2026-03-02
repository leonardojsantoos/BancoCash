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
                        Console.Clear();
                        Console.Write("Insira o valor para Depositar: ");
                        decimal deposito = decimal.Parse(Console.ReadLine());
                        Console.Clear();
                        try
                        {
                            Console.Write("Número da conta: ");
                            int numero = int.Parse(Console.ReadLine());
                            Conta conta = banco.BuscarConta(numero);
                            if (conta == null)
                                Console.WriteLine("Conta não encontrada!");
                            else
                            {
                                conta.Depositar(deposito);
                                Console.WriteLine($"R${deposito} depositado!\n" +
                                $"Saldo atual: {conta.Saldo}");    
                            }
                            
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
                        Console.Write("\nInsira o número da conta: ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Conta criada!");
                        conta1.contas.Add(new Conta(nome, num));
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Contas Registradas:\n\n");
                        conta1.ExibirLista();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Programa fechado...");
                        Console.ReadKey();
                        break;
                }
            }while (opcao != 6);
            
        }
    }
}