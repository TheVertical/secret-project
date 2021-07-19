using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecretProject.WebApi.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using SecretProject.BusinessProject.Models.Good;

namespace SecretProject.WebApi.Infrastructure
{
    [Serializable]
    public class SessionCart : Cart
    {

        #region Model
        [NonSerialized]
        public SessionHelper SessionHelper;
        #endregion

        #region Realization
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionHelper helper = new SessionHelper((services.GetService(typeof(ILogger<SessionHelper>)) as ILogger), services);
            SessionCart cart = helper.Get<Cart>() as SessionCart ?? new SessionCart();
            cart.SessionHelper = helper;
            return cart;
        }
        #endregion

        #region Class Methods
        public override void AddLine(Nomenclature nom, int amount)
        {
            base.AddLine(nom, amount);
            SessionHelper.Save<Cart>(this);
        }
        public override void RemoveLine(Nomenclature nom)
        {
            base.RemoveLine(nom);
            SessionHelper.Save<Cart>(this);
        }
        public override void Clear()
        {
            base.Clear();
            SessionHelper.Remove<Cart>();
        }
        #endregion

    }
}
