using Microsoft.AspNetCore.Mvc;
using PerfumeFinder.Api.Data;
using PerfumeFinder.Api.DTOs;
using PerfumeFinder.Api.Models;

namespace PerfumeFinder.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _db;
        public OrdersController(AppDbContext db) { _db = db; }

        [HttpPost]
        public IActionResult Create(OrderCreateDto dto)
        {
            var order = new Order { UserId = dto.UserId, CreatedAt = DateTime.UtcNow };
            _db.Orders.Add(order);
            _db.SaveChanges();
            foreach (var item in dto.Items)
            {
                var p = _db.Perfumes.Find(item.PerfumeId);
                _db.OrderDetails.Add(new OrderDetail { OrderId = order.Id, PerfumeId = item.PerfumeId, Quantity = item.Quantity, UnitPrice = p?.Price ?? 0 });
            }
            _db.SaveChanges();
            return Ok(order);
        }
    }
}
