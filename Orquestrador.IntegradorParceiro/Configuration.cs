
using Enterprise.Framework.Collections;
using Enterprise.Framework.DI;
using Microsoft.Extensions.Configuration;
using Orquestrador.Application.Parceiro.Services;
using Orquestrador.Infrastructure.DI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Orquestrador.IntegradorParceiro
{
    public class Configuration
    {
        public Configuration()
        {
            Initialize();
        }

        public IPedidoParceiroService GetIPedidoParceiroService()
        {
            return Factory.Instance.Create<IPedidoParceiroService>();
        }

        private void Initialize()
        {
            var builder = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var appSettings = new ParsableNameValueCollection(configuration.GetSection("AppSettings"));
            new Bootstrap(appSettings).Initialize();

        }
    }
}
