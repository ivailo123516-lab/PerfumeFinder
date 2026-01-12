using System.Collections.Generic;

namespace PerfumeFinder.Api.DTOs
{
    public class RecommendRequest
    {
        public List<int> NoteIds { get; set; } = new List<int>();
    }
}
