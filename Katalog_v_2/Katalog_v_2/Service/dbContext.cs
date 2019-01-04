using Katalog_v_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Katalog_v_2.Service
{
    public class dbContext : DbContext
    {
        public dbContext() : base("KatalogReliz_v3")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public static dbContext Create()
        {
            return new dbContext();
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Rezept> Rezepts { get; set; }

        public virtual DbSet<Bludo> Bludoes { get; set; }

    }
}