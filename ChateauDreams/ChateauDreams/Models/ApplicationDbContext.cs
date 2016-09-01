using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChateauDreams.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Review> Reviews { get; set; }
    
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create() 
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ChateauDreams.Models.Enotourism.WineHistory> WineHistories { get; set; }

        public System.Data.Entity.DbSet<ChateauDreams.Models.Enotourism.EnotourismHistory> EnotourismHistories { get; set; }

        public System.Data.Entity.DbSet<ChateauDreams.Models.Enotourism.TastingRoom> TastingRooms { get; set; }

        public System.Data.Entity.DbSet<ChateauDreams.Models.Reservations> Reservations { get; set; }

        public System.Data.Entity.DbSet<ChateauDreams.Models.Hotel.Rooms> Rooms { get; set; }

        public System.Data.Entity.DbSet<ChateauDreams.Models.Hotel.Restaurant> Restaurants { get; set; }

        public System.Data.Entity.DbSet<ChateauDreams.Models.Hotel.AboutUs> AboutUs { get; set; }



        // public System.Data.Entity.DbSet<ChateauDreams.Models.Review> Reviews { get; set; }
    }
}