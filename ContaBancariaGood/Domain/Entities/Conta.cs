using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancariaGood.Domain.Entities
{
    public class Conta
    {
        //implementar stategy pattern
        public string Titular { get; }
        public string Numero { get; }
        public decimal Saldo { get; private set; }

        public Conta(string titular, string numero)
        {
            if (string.IsNullOrWhiteSpace(titular))
                throw new ArgumentException("Insira o nome do titular");

            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Insira o numero da conta");

            Titular = titular;
            Numero = numero;
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor deve ser maior que zero.");

            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor inválido.");

            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente.");

            Saldo -= valor;
        }

        public void Transferir(Conta destino, decimal valor)
        {
            if (destino == null)
                throw new ArgumentNullException(nameof(destino));

            Sacar(valor);
            destino.Depositar(valor);
        }
    }
}
