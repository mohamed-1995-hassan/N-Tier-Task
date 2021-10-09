using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.EntitiesDBContext
{
   public class IdentityContext :IdentityDbContext<ApplicationUser>
    {
        public IdentityContext() : base("IdentityDBconnection")
        {

        }
        public virtual DbSet<Country>Countries { get; set; }
        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}
