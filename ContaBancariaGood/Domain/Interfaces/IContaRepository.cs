using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaBancariaGood;
using ContaBancariaGood.Domain.Entities;

namespace ContaBancariaGood.Domain.Interfaces
{
    public interface IContaRepository
    {
        void Adicionar(Conta conta);
        Conta ObterPorNumero(int numero);
        IEnumerable<Conta> ObterTodas();
    }
}
