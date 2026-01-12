using Microsoft.AspNetCore.Mvc;
using PerfumeFinder.Api.Data;

namespace PerfumeFinder.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public NotesController(AppDbContext db) { _db = db; }

        [HttpGet]
        public IActionResult Get() => Ok(_db.Notes.ToList());
    }
}
