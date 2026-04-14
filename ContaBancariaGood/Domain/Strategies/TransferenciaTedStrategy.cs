using ContaBancariaGood.Domain.Interfaces;
using ContaBancariaGood.Domain.Entities;

namespace ContaBancariaGood.Domain.Strategies
{
    internal class TransferenciaTedStrategy : ITransferenciaStrategy
    {
        private const decimal TAXA_TED = 5.00m;

        public void Transferir(Conta origem, Conta destino, decimal valor)
        {
            if (destino == null)
                throw new ArgumentNullException(nameof(destino));

            origem.Sacar(valor + TAXA_TED);
            destino.Depositar(valor);
        }
    }
}
