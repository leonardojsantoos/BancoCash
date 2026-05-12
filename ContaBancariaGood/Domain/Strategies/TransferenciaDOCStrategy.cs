using ContaBancariaGood.Domain.Interfaces;
using ContaBancariaGood.Domain.Entities;

namespace ContaBancariaGood.Domain.Strategies 
{
    internal class TransferenciaDOCStrategy : ITransferenciaStrategy
    {
        private const decimal TAXA_DOC = 5.00m;
        public void Transferir(Conta origem, Conta destino, decimal valor)
        {         
            if (destino == null)
                throw new ArgumentNullException(nameof(destino));

            origem.Sacar(valor + TAXA_DOC);
            destino.Depositar(valor);
        }
    }
}
