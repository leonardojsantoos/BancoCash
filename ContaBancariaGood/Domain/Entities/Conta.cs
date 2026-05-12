using ContaBancariaGood.Domain.Entities.ContaBancariaGood.Domain.Entities;
using ContaBancariaGood.Domain.Interfaces;

namespace ContaBancariaGood.Domain.Entities
{
    public class Conta
    {
        public string Titular { get; }
        public string Numero { get; }
        public decimal Saldo { get; private set; }
        public List<Transacao> Historico { get; } = new();
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

            Historico.Add(new Transacao("Depósito", valor));
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor inválido.");

            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente.");

            Saldo -= valor;

            Historico.Add(new Transacao("Saque", valor));
        }

        public void ExecutarTransferencia(ITransferenciaStrategy estrategia, Conta destino, decimal valor)
        {
            if (destino == null) throw new ArgumentNullException(nameof(destino));

            estrategia.Transferir(this, destino, valor);
            Historico.Add(new Transacao("Transacao", valor));
        }
    }
}
