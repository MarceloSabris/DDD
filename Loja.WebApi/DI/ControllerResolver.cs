using Enterprise.Framework.DI;
using Loja.Application.Ativacao.Services;
using Loja.Application.Compras.Services;
using Loja.Application.ComprasERP.Services;
using Loja.Application.ComprasParceiro.Services;
using Loja.Application.TermoAceite.Services.Contracts;
using Loja.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Concurrent;

namespace Loja.WebApi.DI
{
    public class ControllerResolver : IControllerActivator
    {
        private readonly static ConcurrentDictionary<Type, Func<object>> cacheTypes =
            new ConcurrentDictionary<Type, Func<object>>();

        public ControllerResolver()
        {
            if (cacheTypes.IsEmpty)
            {                
                cacheTypes.TryAdd(typeof(CompraController), () => new CompraController(Factory.Instance.Create<ICompraService>()));
                cacheTypes.TryAdd(typeof(CompraParceiroController), () => new CompraParceiroController(Factory.Instance.Create<ICompraParceiroService>()));
                cacheTypes.TryAdd(typeof(CompraTermoAceiteController), () => new CompraTermoAceiteController(Factory.Instance.Create<IAceiteService>()));
                cacheTypes.TryAdd(typeof(CompraAtivacaoController), () => new CompraAtivacaoController(Factory.Instance.Create<IAtivacaoService>()));
				cacheTypes.TryAdd(typeof(CompraERPController), () => new CompraERPController(Factory.Instance.Create<ICompraERPService>()));

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
