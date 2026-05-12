namespace ContaBancariaGood.Domain.Entities
{
    namespace ContaBancariaGood.Domain.Entities
    {
        public class Transacao
        {
            public string Tipo { get; }
            public decimal Valor { get; }
            public DateTime Data { get; }

            public Transacao(string tipo, decimal valor)
            {
                Tipo = tipo;
                Valor = valor;
                Data = DateTime.Now;
            }
        }
    }
}
