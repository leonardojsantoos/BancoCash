using ContaBancariaGood.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaBancariaGood.Domain.Entities;

namespace ContaBancariaGood.Infrastructure.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly Dictionary<int, Conta> _contas = new();

        public void Adicionar(Conta conta)
        {
            if (_contas.ContainsKey(conta.Numero))
                throw new InvalidOperationException("Conta já existe.");

            _contas.Add(conta.Numero, conta);
        }

        public Conta ObterPorNumero(int numero)
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
