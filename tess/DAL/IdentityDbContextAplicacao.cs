﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web;
using tess.Areas.Seguranca.Models;

namespace tess.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>
    {
        public IdentityDbContextAplicacao() : base("IdentityDb")
        {

        }

        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>
            (new IdentityDbInit());
        }

        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }

        public class IdentityDbInit: DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao>
        {
        }
    }
}