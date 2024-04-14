using Microsoft.EntityFrameworkCore;

namespace APIMarioKart.Models
{
    public class MarioKartContext : DbContext
    {

        public MarioKartContext(DbContextOptions<MarioKartContext> options) : base(options)
        {

        }


        public DbSet<Personaggi> Personaggi { get; set; }
        public DbSet<Squadra> Squadra { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)


        {

            modelBuilder.Entity<Squadra>()
           .HasKey(s => new { s.squadraID});
            modelBuilder.Entity<Personaggi>()
            .HasKey(p => new { p.personaggiId });

            modelBuilder.Entity<Squadra>().HasMany(sq => sq.PersonaggiRIf).WithOne(sq => sq.SquadraRifNavigation).HasForeignKey(sq => sq.squadraRif);


            modelBuilder.Entity<Personaggi>().HasOne(e => e.SquadraRifNavigation).WithMany(e => e.PersonaggiRIf).HasForeignKey(e => e.squadraRif);


        }
    }
}
