using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta_Bancaria
{
    internal class Banco
    {
        private List<Conta> contas = new List<Conta>();

        public void AddConta(Conta conta)
        {
            contas.Add(conta);
        }
        public void ListarContas()
        {
            foreach (Conta c in contas)
            {
                Console.WriteLine($"Titular: {c.Titular}\n" +
                                  $"Número: {c.Numero}\n");
            }
        }
        public Conta BuscarConta(int numero)
        {
            return contas.FirstOrDefault(c => c.Numero == numero);
        }
    }
}
