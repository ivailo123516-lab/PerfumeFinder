using System.Collections.Generic;

namespace PerfumeFinder.Api.Models
{
    public class Perfume
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public IList<PerfumeNote> PerfumeNotes { get; set; } = new List<PerfumeNote>();
        public IList<Review> Reviews { get; set; } = new List<Review>();
    }
}
