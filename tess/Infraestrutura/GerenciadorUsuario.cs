﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tess.Areas.Seguranca.Models;
using tess.DAL;

namespace tess.Infraestrutura
{
    public class GerenciadorUsuario : UserManager<Usuario>
    {
        public GerenciadorUsuario(IUserStore<Usuario> store) : base(store)
        {

        }

        public static GerenciadorUsuario Create(IdentityFactoryOptions<GerenciadorUsuario> options, IOwinContext context)
        {
            IdentityDbContextAplicacao db = context.Get<IdentityDbContextAplicacao>();
            GerenciadorUsuario manager = new GerenciadorUsuario(new UserStore<Usuario>(db));
            return manager;
        }
        
    }
}