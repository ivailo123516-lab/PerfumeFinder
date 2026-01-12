using System.Linq;
using PerfumeFinder.Api.Models;

namespace PerfumeFinder.Api.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Perfumes.Any()) return;

            var notes = new[] {
                new Note { Name = "Rose" },
                new Note { Name = "Jasmine" },
                new Note { Name = "Citrus" },
                new Note { Name = "Vanilla" },
                new Note { Name = "Musk" }
            };
            context.Notes.AddRange(notes);

            var p1 = new Perfume { Name = "Rose Breeze", Brand = "AromaCo", Description = "Fresh rose fragrance", Price = 49.99m };
            var p2 = new Perfume { Name = "Citrus Splash", Brand = "FreshScents", Description = "Energetic citrus", Price = 39.99m };
            var p3 = new Perfume { Name = "Vanilla Night", Brand = "EveningPerfumes", Description = "Warm vanilla and musk", Price = 59.99m };

            context.Perfumes.AddRange(p1, p2, p3);
            context.SaveChanges();

            context.PerfumeNotes.AddRange(
                new PerfumeNote { PerfumeId = p1.Id, NoteId = notes.First(n => n.Name=="Rose").Id },
                new PerfumeNote { PerfumeId = p1.Id, NoteId = notes.First(n => n.Name=="Jasmine").Id },
                new PerfumeNote { PerfumeId = p2.Id, NoteId = notes.First(n => n.Name=="Citrus").Id },
                new PerfumeNote { PerfumeId = p3.Id, NoteId = notes.First(n => n.Name=="Vanilla").Id },
                new PerfumeNote { PerfumeId = p3.Id, NoteId = notes.First(n => n.Name=="Musk").Id }
            );

            // Add a default user
            var user = new User { Username = "test", PasswordHash = AuthService.HashPassword("password"), Email = "test@example.com" };
            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
