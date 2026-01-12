namespace PerfumeFinder.Api.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int PerfumeId { get; set; }
        public Perfume Perfume { get; set; } = null!;
    }
}
