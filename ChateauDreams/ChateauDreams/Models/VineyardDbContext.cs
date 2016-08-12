using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChateauDreams.Models
{
    public class VineyardDbContext : IdentityDbContext<ApplicationUser>
    {
        public VineyardDbContext()
            : base("Vineyard", throwIfV1Schema: false)
        {
        }

        public IDbSet<ApplicationUser> Guests { get; set; }

        public static VineyardDbContext Create()
        {
            return new VineyardDbContext();
        }
    }
}