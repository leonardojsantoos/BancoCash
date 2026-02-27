using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta_Bancaria
{
    internal class Conta
    {
        public string Titular { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; private set; }
        List<Conta> contas = new List<Conta>();

        public Conta(string titular, int numero)
        {
            Titular = titular;
            Numero = numero;
            Saldo = 0;
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
            Sacar(valor);
            destino.Depositar(valor);
        }
    }
}
