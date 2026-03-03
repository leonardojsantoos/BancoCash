using ContaBancaria.Domain.Entities;

namespace ContaBancaria.Domain
{
    public class Banco
    {
        private readonly Dictionary<int, Conta> _contas = new();

        public void AdicionarConta(Conta conta)
        {
            if (_contas.ContainsKey(conta.Numero))
                throw new InvalidOperationException("Conta já existe.");

            _contas.Add(conta.Numero, conta);
        }

        public Conta BuscarConta(int numero)
        {
            _contas.TryGetValue(numero, out var conta);
            return conta;
        }

        public IEnumerable<Conta> ObterContas()
        {
            return _contas.Values;
        }
    }
}