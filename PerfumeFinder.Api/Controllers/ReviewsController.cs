using Microsoft.AspNetCore.Mvc;
using PerfumeFinder.Api.Data;
using PerfumeFinder.Api.DTOs;
using PerfumeFinder.Api.Models;

namespace PerfumeFinder.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ReviewsController(AppDbContext db) { _db = db; }

        [HttpPost]
        public IActionResult Create(ReviewDto dto)
        {
            var r = new Review { PerfumeId = dto.PerfumeId, UserId = dto.UserId, Rating = dto.Rating, Comment = dto.Comment };
            _db.Reviews.Add(r);
            _db.SaveChanges();
            return Ok(r);
        }
    }
}
