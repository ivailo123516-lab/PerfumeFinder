using System.Collections.Generic;

namespace PerfumeFinder.Api.DTOs
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
    public class OrderItemDto { public int PerfumeId { get; set; } public int Quantity { get; set; } }
}
