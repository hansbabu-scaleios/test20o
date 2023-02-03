using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AI.Finder.BE.Service.Features.Samples.SampleAutherization;
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="Admin")]
    public class SampleAutherizationController : ControllerBase
    {
        private readonly FinderDbContext _context;
        public SampleAutherizationController(FinderDbContext context)
        {
            _context = context;
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> getData(int Id){
            var data = await _context.SampleAutherization.Where(e => e.Id == Id).FirstOrDefaultAsync();
            if(data == null){
                return BadRequest();
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> createData(string name, string address){
            var data =  new SampleAutherizationModel{
                Name = name,
                Address = address
            };
            await _context.SampleAutherization.AddAsync(data);
            await _context.SaveChangesAsync();
            return Ok(data);
        }
    }