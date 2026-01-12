using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeFinder.Api.Data;
using PerfumeFinder.Api.DTOs;
using PerfumeFinder.Api.Models;

namespace PerfumeFinder.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfumesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public PerfumesController(AppDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _db.Perfumes.Include(p=>p.PerfumeNotes).ThenInclude(pn=>pn.Note).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _db.Perfumes.Include(p=>p.PerfumeNotes).ThenInclude(pn=>pn.Note).FirstOrDefaultAsync(p=>p.Id==id));

        [HttpPost]
        public async Task<IActionResult> Create(PerfumeCreateDto dto)
        {
            var p = new Perfume { Name = dto.Name, Brand = dto.Brand, Description = dto.Description, Price = dto.Price };
            _db.Perfumes.Add(p);
            await _db.SaveChangesAsync();
            if (dto.NoteIds != null)
            {
                foreach (var nid in dto.NoteIds) _db.PerfumeNotes.Add(new PerfumeNote { PerfumeId = p.Id, NoteId = nid });
                await _db.SaveChangesAsync();
            }
            return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
        }

        [HttpPost("recommend")]
        public async Task<IActionResult> Recommend(RecommendRequest req)
        {
            var perfumes = await _db.Perfumes.Include(p=>p.PerfumeNotes).ThenInclude(pn=>pn.Note).ToListAsync();
            var matches = perfumes.Select(p => new { Perfume = p, Score = p.PerfumeNotes.Count(pn => req.NoteIds.Contains(pn.NoteId)) })
                .OrderByDescending(x => x.Score).ThenBy(p=>p.Perfume.Name).Take(10).Where(x=>x.Score>0).Select(x=>x.Perfume);
            return Ok(matches);
        }
    }
}
