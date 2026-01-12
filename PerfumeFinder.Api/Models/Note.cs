using System.Collections.Generic;

namespace PerfumeFinder.Api.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public IList<PerfumeNote> PerfumeNotes { get; set; } = new List<PerfumeNote>();
    }
}
