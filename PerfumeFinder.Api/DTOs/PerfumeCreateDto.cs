using System.Collections.Generic;

namespace PerfumeFinder.Api.DTOs
{
    public class PerfumeCreateDto
    {
        public string Name { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public List<int>? NoteIds { get; set; }
    }
}
