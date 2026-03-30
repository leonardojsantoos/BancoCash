using ContaBancariaGood.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaBancariaGood.Domain.Entities;

namespace ContaBancariaGood.Application.Services
{
    public class BancoService
    {
        private readonly IContaRepository _repository;

        public BancoService(IContaRepository repository)
        {
            _repository = repository;
        }

        public void CriarConta(string nome, int numero)
        {
            var conta = new Conta(nome, numero);
            _repository.Adicionar(conta);
        }

        public void Depositar(int numero, decimal valor)
        {
            var conta = ObterConta(numero);
            conta.Depositar(valor);
        }

        public void Sacar(int numero, decimal valor)
        {
            var conta = ObterConta(numero);
            conta.Sacar(valor);
        }

        public void Transferir(int origem, int destino, decimal valor)
        {
            var contaOrigem = ObterConta(origem);
            var contaDestino = ObterConta(destino);

            contaOrigem.Transferir(contaDestino, valor);
        }

        public IEnumerable<Conta> ListarContas()
        {
            return _repository.ObterTodas();
        }

        private Conta ObterConta(int numero)
        {
            return _repository.ObterPorNumero(numero)
                ?? throw new Exception("Conta não encontrada.");
        }
    }
}
