namespace PerfumeFinder.Api.Models
{
    public class PerfumeNote
    {
        public int PerfumeId { get; set; }
        public Perfume Perfume { get; set; } = null!;
        public int NoteId { get; set; }
        public Note Note { get; set; } = null!;
    }
}
