
using Orquestrador.WebApi.Controllers;
using Enterprise.Framework.DI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Concurrent;
using Orquestrador.Application.Parceiro.Services;

namespace Orquestrador.WebApi.DI
{
    public class ControllerResolver : IControllerActivator
    {
        private readonly static ConcurrentDictionary<Type, Func<object>> cacheTypes =
            new ConcurrentDictionary<Type, Func<object>>();

        public ControllerResolver()
        {
            if (cacheTypes.IsEmpty)
            {
                cacheTypes.TryAdd(typeof(PedidoParceiroController), () => new PedidoParceiroController(Factory.Instance.Create<IPedidoParceiroService>()));
            }
        }

        public object Create(ControllerContext context)
        {
            Func<object> func = null;
            if (cacheTypes.TryGetValue(context.ActionDescriptor.ControllerTypeInfo.AsType(), out func))
            {
                return func();
            }
            return null;
        }

        public void Release(ControllerContext context, object controller)
        {
        }
    }
}
