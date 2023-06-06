using Fantasia.Shared;
using Microsoft.EntityFrameworkCore;

namespace Fantasia.Server.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=fantasia;Trusted_Connection=true;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FyzUtoky>().HasData(
                    new FyzUtoky { Id = 1, FyzImageUrl = "/Client/wwwroot/images/FlyingKick60.png", NazovFyzUtoku = "FlyingKick", NazovFunkcie = "flyingkick(this.src)" },
                    new FyzUtoky { Id = 2, FyzImageUrl = "/Client/wwwroot/images/BodySlam60.png", NazovFyzUtoku = "BodySlam", NazovFunkcie = "bodyslam(this.src)" },
                    new FyzUtoky { Id = 3, FyzImageUrl = "/Client/wwwroot/images/PunchGataling60.png", NazovFyzUtoku = "PunchGataling", NazovFunkcie = "punchgataling(this.src)" }
                );

            modelBuilder.Entity<MagUtoky>().HasData(
                   new MagUtoky { Id = 1, MagImageUrl = "/Client/wwwroot/images/fireBall60.png", NazovMagUtoku = "FireBall", NazovFunkcie = "fireball(this.src)" },
                   new MagUtoky { Id = 2, MagImageUrl = "/Client/wwwroot/images/frostNova60.png", NazovMagUtoku = "FrostNova", NazovFunkcie = "frostnova(this.src)" },
                   new MagUtoky { Id = 3, MagImageUrl = "/Client/wwwroot/images/windSlash60.png", NazovMagUtoku = "WindSlash", NazovFunkcie = "windslash(this.src)" }
               );
            modelBuilder.Entity<VieUtoky>().HasData(
                   new VieUtoky { Id = 1, VieImageUrl = "/Client/wwwroot/images/heal60.png", NazovVieUtoku = "Heal", NazovFunkcie = "heal(this.src)" },
                   new VieUtoky { Id = 2, VieImageUrl = "/Client/wwwroot/images/defBonus60.png", NazovVieUtoku = "DefBonus", NazovFunkcie = "bonusDef(this.src)" },
                   new VieUtoky { Id = 3, VieImageUrl = "/Client/wwwroot/images/AttakeBonus60.png", NazovVieUtoku = "AttakeBonus", NazovFunkcie = "bonusUtok(this.src)" }
               );

        }

        public DbSet<Hrac> Hrac { get; set; }

        public DbSet<Postava> Postava { get; set; }

        public DbSet<FyzUtoky> FyzUtoky { get; set; }

        public DbSet<MagUtoky> MagUtoky { get; set; }

        public DbSet<VieUtoky> VieUtoky { get; set; }

        public DbSet<Image> Image { get; set; }

        public DbSet<Boj> Boj { get; set; }
    }
}
