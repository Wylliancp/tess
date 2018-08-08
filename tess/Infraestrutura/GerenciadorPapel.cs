using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using tess.Areas.Seguranca.Models;
using tess.DAL;

namespace tess.Infraestrutura
{
    public class GerenciadorPapel : RoleManager<Papel>, IDisposable
    {
        public GerenciadorPapel(RoleStore<Papel> store) : base(store)
        {
        }

        public static GerenciadorPapel Create(IdentityFactoryOptions<GerenciadorPapel> options, IOwinContext context)
        {
            return new GerenciadorPapel(new RoleStore<Papel>(context.Get<IdentityDbContextAplicacao>()));
        }
    }
}