using ContaBancariaGood.Domain.Entities;
using ContaBancariaGood.Domain.Interfaces;

namespace ContaBancariaGood.Infrastructure.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly Dictionary<string, Conta> _contas = new();

        public void Adicionar(Conta conta)
        {
            if (!_contas.TryAdd(conta.Numero, conta))
                throw new InvalidOperationException("Conta já existe.");
        }

        public Conta ObterPorNumero(string numero)
        {
            _contas.TryGetValue(numero, out var conta);
            return conta;
        }

        public IEnumerable<Conta> ObterTodas()
        {
            return _contas.Values;
        }
    }
}
