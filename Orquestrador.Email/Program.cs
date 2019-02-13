using Enterprise.Framework.Collections;
using Microsoft.Extensions.Configuration;
using Orquestrador.Application.EmailAtivacao.Services;
using Orquestrador.Infrastructure.DI;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Orquestrador.Email
{
    public class Program
    {        

        static void Main(string[] args)
        {
            Console.WriteLine("Inicializando configuração.");
            var configuracao = new Configuration();

            Console.WriteLine("Início do processo --> Enviar Código Cliente");
            Task.Run(async () =>
            {
                var service = configuracao.GetEmailAtivacaoService();
                var response = await service.EnviarCodigoCliente(new Application.EmailAtivacao.Messages.EnviarCodigoClienteRequest());

            }).GetAwaiter().GetResult();

            Console.WriteLine("Fim do processo --> Enviar Código Cliente");
        }
    }
}
