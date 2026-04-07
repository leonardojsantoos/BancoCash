using ContaBancariaGood.Domain.Entities;

namespace ContaBancariaGood.Domain.Interfaces
{
    internal interface ITranferenciaStrategy
    {
        void Depositar(Conta origem, Conta destino, decimal valor);
    }
}
