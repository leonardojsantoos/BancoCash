using ContaBancariaGood.Application.Services;
using ContaBancariaGood.Infrastructure.Repositories;

namespace ContaBancariaGood.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repository = new ContaRepository();
            var service = new BancoService(repository);

            var menu = new Menu(service);
            menu.Executar();
        }
    }
}