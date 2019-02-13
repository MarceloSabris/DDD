using System;
using System.Threading.Tasks;

namespace Orquestrador.IntegradorErp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicializando configuração.");
            var configuracao = new Configuration();

            Console.WriteLine("Início do processo --> Integrar ERP");
            Task.Run(async () =>
            {
                var service = configuracao.GetIPedidoERPService();
                var response = await service.IntegrarPedidosERP(new Application.IntegracaoERP.Messages.IntegrarPedidoERPRequest());

            }).GetAwaiter().GetResult();

            Console.WriteLine("Fim do processo --> Integrar ERP");
        }
    }
}
