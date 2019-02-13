using System;
using System.Threading.Tasks;

namespace Orquestrador.PedidoLoja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicializando configuração.");
            var configuracao = new Configuration();

            Console.WriteLine("Início do processo --> Enfileirar pedido loja (compras elegíveis)");
            Task.Run(async () =>
            {
                var service = configuracao.GetIPedidoLojaService();
                var response = await service.EnfileirarPedidos(new Application.PedidoLoja.Messages.EnfileirarPedidosRequest());

            }).GetAwaiter().GetResult();

            Console.WriteLine("Fim do processo --> Enfileirar pedido loja (compras elegíveis)");
        }
    }
}
