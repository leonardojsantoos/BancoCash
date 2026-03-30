using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancariaGood.Domain.Entities
{
    public class Conta
    {
        public string Titular { get; }
        public int Numero { get; }
        public decimal Saldo { get; private set; }

        public Conta(string titular, int numero)
        {
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
