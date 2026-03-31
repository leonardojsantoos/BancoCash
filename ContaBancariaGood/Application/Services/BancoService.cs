using ContaBancariaGood.Domain.Entities;
using ContaBancariaGood.Domain.Interfaces;

namespace ContaBancariaGood.Application.Services
{
    public class BancoService
    {
        private readonly IContaRepository _repository;

        public BancoService(IContaRepository repository)
        {
            _repository = repository;
        }

        public void CriarConta(string nome, string numero)
        {
            var conta = new Conta(nome, numero);
            _repository.Adicionar(conta);
        }

        public void Depositar(string numero, decimal valor)
        {
            var conta = ObterConta(numero);
            conta.Depositar(valor);
        }

        public void Sacar(string numero, decimal valor)
        {
            var conta = ObterConta(numero);
            conta.Sacar(valor);
        }

        public void Transferir(string origem, string destino, decimal valor)
        {
            var contaOrigem = ObterConta(origem);
            var contaDestino = ObterConta(destino);

            contaOrigem.Transferir(contaDestino, valor);
        }

        public IEnumerable<Conta> ListarContas()
        {
            return _repository.ObterTodas();
        }

        private Conta ObterConta(string numero)
        {
            return _repository.ObterPorNumero(numero)
                ?? throw new Exception("Conta não encontrada.");
        }
    }
}
