using ContaBancariaGood.Domain.Interfaces;
using ContaBancariaGood.Domain.Entities;

namespace ContaBancariaGood.Domain.Strategies
{
    public class TransferenciaPixStrategy : ITransferenciaStrategy
    {
        public void Transferir(Conta origem, Conta destino, decimal valor)
        {
            if (destino == null)
                throw new ArgumentNullException(nameof(destino));

            origem.Sacar(valor);
            destino.Depositar(valor);
        }
    }
}
