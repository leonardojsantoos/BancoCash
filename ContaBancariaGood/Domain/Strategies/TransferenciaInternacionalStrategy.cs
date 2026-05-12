using ContaBancariaGood.Domain.Interfaces;
using ContaBancariaGood.Domain.Entities;

namespace ContaBancariaGood.Domain.Strategies
{
    internal class TransferenciaInternacionalStrategy : ITransferenciaStrategy
    {
        private const decimal TAXA_INTER = 0.10m;
        public void Transferir(Conta origem, Conta destino, decimal valor)
        {
            if (destino == null)
                throw new ArgumentNullException(nameof(destino));

            origem.Sacar(valor + (valor * TAXA_INTER));
            destino.Depositar(valor);
        }
    }
}
