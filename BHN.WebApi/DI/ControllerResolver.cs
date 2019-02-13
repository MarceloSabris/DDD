using BHN.Application.Catalog.Services;
using BHN.Application.EGift.Services;
using BHN.Application.Produto.Services;
using BHN.WebApi.Controllers;
using Enterprise.Framework.DI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Concurrent;

namespace BHN.WebApi.DI
{
    public class ControllerResolver : IControllerActivator
    {
        private readonly static ConcurrentDictionary<Type, Func<object>> cacheTypes =
            new ConcurrentDictionary<Type, Func<object>>();

        public ControllerResolver()
        {
            if (cacheTypes.IsEmpty)
            {
                cacheTypes.TryAdd(typeof(EGiftController), () => new EGiftController(Factory.Instance.Create<IEGiftService>()));
                cacheTypes.TryAdd(typeof(CatalogController), () => new CatalogController(Factory.Instance.Create<ICatalogService>()));
                cacheTypes.TryAdd(typeof(ProdutoController), ()=>new ProdutoController(Factory.Instance.Create<IProdutoService>(), Factory.Instance.Create<ICatalogService>()));
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
