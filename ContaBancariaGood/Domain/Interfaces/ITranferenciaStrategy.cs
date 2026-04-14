using ContaBancariaGood.Domain.Entities;

namespace ContaBancariaGood.Domain.Interfaces
{
    public interface ITransferenciaStrategy
    {
        void Transferir(Conta origem, Conta destino, decimal valor);
    }
}
