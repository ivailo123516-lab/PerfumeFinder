using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PerfumeFinder.Api.Data;

#nullable disable

[DbContext(typeof(AppDbContext))]
partial class PerfumeFinderDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

        modelBuilder.Entity("PerfumeFinder.Api.Models.Note", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd();
            b.Property<string>("Name");
            b.HasKey("Id");
            b.ToTable("Notes");
        });

        modelBuilder.Entity("PerfumeFinder.Api.Models.User", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd();
            b.Property<string>("Username");
            b.Property<string>("Email");
            b.Property<string>("PasswordHash");
            b.HasKey("Id");
            b.ToTable("Users");
        });

        modelBuilder.Entity("PerfumeFinder.Api.Models.Perfume", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd();
            b.Property<string>("Name");
            b.Property<string>("Brand");
            b.Property<string>("Description");
            b.Property<decimal>("Price");
            b.HasKey("Id");
            b.ToTable("Perfumes");
        });

        modelBuilder.Entity("PerfumeFinder.Api.Models.Order", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd();
            b.Property<int>("UserId");
            b.Property<DateTime>("CreatedAt");
            b.HasKey("Id");
            b.ToTable("Orders");
        });

        modelBuilder.Entity("PerfumeFinder.Api.Models.Review", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd();
            b.Property<int>("PerfumeId");
            b.Property<int>("UserId");
            b.Property<int>("Rating");
            b.Property<string>("Comment");
            b.HasKey("Id");
            b.ToTable("Reviews");
        });

        modelBuilder.Entity("PerfumeFinder.Api.Models.PerfumeNote", b =>
        {
            b.Property<int>("PerfumeId");
            b.Property<int>("NoteId");
            b.HasKey("PerfumeId", "NoteId");
            b.ToTable("PerfumeNotes");
        });

        modelBuilder.Entity("PerfumeFinder.Api.Models.Favorite", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd();
            b.Property<int>("UserId");
            b.Property<int>("PerfumeId");
            b.HasKey("Id");
            b.ToTable("Favorites");
        });

        modelBuilder.Entity("PerfumeFinder.Api.Models.OrderDetail", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd();
            b.Property<int>("OrderId");
            b.Property<int>("PerfumeId");
            b.Property<int>("Quantity");
            b.Property<decimal>("UnitPrice");
            b.HasKey("Id");
            b.ToTable("OrderDetails");
        });
    }
}
