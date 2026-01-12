namespace PerfumeFinder.Api.DTOs
{
    public class ReviewDto
    {
        public int PerfumeId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
