using System;
using System.Threading.Tasks;

namespace Orquestrador.IntegradorParceiro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicializando configuração.");
            var configuracao = new Configuration();

            Console.WriteLine("Início do processo --> Integrar Pedidos com Parceiro");
            Task.Run(async () =>
            {
                var service = configuracao.GetIPedidoParceiroService();
                var response = await service.IntegrarPedidoParceiro(new Application.Parceiro.Messages.IntegrarPedidoParceiroRequest());

            }).GetAwaiter().GetResult();

            Console.WriteLine("Fim do processo --> Integrar Pedidos com Parceiro");
        }
    }
}
