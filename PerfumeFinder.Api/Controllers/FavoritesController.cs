using Microsoft.AspNetCore.Mvc;
using PerfumeFinder.Api.Data;
using PerfumeFinder.Api.DTOs;
using PerfumeFinder.Api.Models;

namespace PerfumeFinder.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public FavoritesController(AppDbContext db) { _db = db; }

        [HttpPost]
        public IActionResult Add(FavoriteDto dto)
        {
            var fav = new Favorite { UserId = dto.UserId, PerfumeId = dto.PerfumeId };
            _db.Favorites.Add(fav);
            _db.SaveChanges();
            return Ok(fav);
        }
    }
}
