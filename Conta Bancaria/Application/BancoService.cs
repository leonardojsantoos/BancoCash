using ContaBancaria.Domain;
using ContaBancaria.Domain.Entities;

namespace ContaBancaria.Application
{
    public class BancoService
    {
        private readonly Banco _banco;
        public BancoService(Banco banco)
        {
            _banco = banco;
        }
        public void CriarConta(string nome, int numero)
        {
            var conta = new Conta(nome, numero);
            _banco.AdicionarConta(conta);
        }
        public void Depositar(int numero, decimal valor)
        {
            var conta = ObterContaOuErro(numero);
            conta.Depositar(valor);
        }
        public void Sacar(int numero, decimal valor)
        {
            var conta = ObterContaOuErro(numero);
            conta.Sacar(valor);
        }
        public void Transferir(int origem, int destino, decimal valor)
        {
            var contaOrigem = ObterContaOuErro(origem);
            var contaDestino = ObterContaOuErro(destino);

            contaOrigem.Transferir(contaDestino, valor);
        }
        public IEnumerable<Conta> ListarContas()
        {
            return _banco.ObterContas();
        }
        private Conta ObterContaOuErro(int numero)
        {
            var conta = _banco.BuscarConta(numero);
            if (conta == null)
                throw new Exception("Conta não encontrada.");

            return conta;
        }
    }
}