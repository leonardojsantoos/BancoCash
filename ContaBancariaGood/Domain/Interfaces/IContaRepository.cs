using ContaBancariaGood.Domain.Entities;

namespace ContaBancariaGood.Domain.Interfaces
{
    public interface IContaRepository
    {
        void Adicionar(Conta conta);
        Conta ObterPorNumero(string numero);
        IEnumerable<Conta> ObterTodas();
    }
}
