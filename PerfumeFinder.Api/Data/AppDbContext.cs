using Microsoft.EntityFrameworkCore;
using PerfumeFinder.Api.Models;

namespace PerfumeFinder.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Perfume> Perfumes { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<PerfumeNote> PerfumeNotes { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Favorite> Favorites { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfumeNote>()
                .HasKey(pn => new { pn.PerfumeId, pn.NoteId });

            modelBuilder.Entity<PerfumeNote>()
                .HasOne(pn => pn.Perfume)
                .WithMany(p => p.PerfumeNotes)
                .HasForeignKey(pn => pn.PerfumeId);

            modelBuilder.Entity<PerfumeNote>()
                .HasOne(pn => pn.Note)
                .WithMany(n => n.PerfumeNotes)
                .HasForeignKey(pn => pn.NoteId);
        }
    }
}
