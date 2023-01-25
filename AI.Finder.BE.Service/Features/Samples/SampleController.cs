using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AI.Finder.BE.Service.Features.Samples;
[ApiController]
[Route("[controller]/[action]")]
public class SampleController : ControllerBase {
    private readonly FinderDbContext _context;
    public SampleController(FinderDbContext context) {
        _context = context;
    }
    //TODO:Sample Table CRUD Operation
    [HttpGet]
    public async Task<IActionResult> GetSamples() {
        try{
            var Samples = await _context.Sample
            .ProjectToType<SampleResponseDTO>()
            .ToListAsync();
            if (Samples == null) {
                return BadRequest();
            }
            return Ok(Samples);
        }
        catch (Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSamples(long id){
        try{
            var Sample = await _context.Sample.
            Where(e => e.Id == id)
            .ProjectToType<SampleResponseDTO>()
            .FirstOrDefaultAsync();
            if (Sample == null){
                return BadRequest();
            }
            return Ok(Sample);
        }
        catch (Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddSample(SampleRequestDTO sampleRequestDTO){
        try{
            var sample = new SampleModel{
                Code = sampleRequestDTO.Code,
                AuditProp = sampleRequestDTO.AuditProp
            };
            _context.Sample.Add(sample);
            await _context.SaveChangesAsync();
            return Ok(sample);
        }
        catch (Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSample(long id, SampleRequestDTO sampleRequestDTO){
        var GetSample = await _context.Sample.FirstOrDefaultAsync(m => m.Id == id);
        if (GetSample == null) {
            return BadRequest();
        }
        GetSample.Code = sampleRequestDTO.Code;
        GetSample.AuditProp = sampleRequestDTO.AuditProp;
        try{
            await _context.SaveChangesAsync();
        }
        catch (Exception ex){
            return BadRequest(ex.Message);
        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSample(long id){
        try{
            var Sample = await _context.Sample.FindAsync(id);
            if (Sample == null){
                return BadRequest();
            }
            _context.Sample.Remove(Sample);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex){
            return BadRequest(ex.Message);
        }
    }
      // TODO:Error handling example
     // Please enter invalid id for getting exception
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSamplesForEXceptionHandling(int? id){
        try{
             id=null;
            var Sample = await _context.Sample.
            Where(e => e.Id == id)
            .ProjectToType<SampleResponseDTO>()
            .FirstOrDefaultAsync();
            if (Sample == null){
               throw new NullReferenceException();
            }
            return Ok(Sample);
        }
        catch (Exception ex){
            return BadRequest(ex);
        }
    }
}
