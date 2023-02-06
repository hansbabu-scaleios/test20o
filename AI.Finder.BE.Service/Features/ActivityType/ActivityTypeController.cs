using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AI.Finder.BE.Service.Features.ActivityType;
[ApiController]
[Route("[controller]")]
[Authorize]
public class ActivityTypeController : ControllerBase{
    private readonly FinderDbContext _context;
    public ActivityTypeController(FinderDbContext context){
        _context = context;
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetActivity(long Id){
        try{
            var activity = await _context.ActivityTypes
                .ProjectToType<ActivityTypeResponseDTO>()
                .Where(e => e.Id == Id)
                .FirstOrDefaultAsync();
            if (activity == null){
                return BadRequest();
            }
            else{
                return Ok(activity);
            }
        }
        catch(Exception ex){
            return BadRequest(ex);
        }
        
    }
    [HttpPost]
    public async Task<IActionResult> CreateActivity(ActivityTypeRequestDTO activityTypeRequestDTO){
        try{
            var activity = new ActivityTypeModel{
                Code = activityTypeRequestDTO.Code,
                Type = activityTypeRequestDTO.Type
            };
            await _context.ActivityTypes.AddAsync(activity);
            await _context.SaveChangesAsync();
            return Ok(activity);
        }
        catch (Exception ex){
            return BadRequest(ex);
        }
    }
    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateActivity(long Id, ActivityTypeRequestDTO activityTypeRequestDTO){
        try{
            var activity = await _context.ActivityTypes
                .Where(e => e.Id == Id)
                .FirstOrDefaultAsync();
            if (activity == null){
                return BadRequest();
            }
            activity.Code = activityTypeRequestDTO.Code;
            activity.Type = activityTypeRequestDTO.Type;
            await _context.SaveChangesAsync();
            return Ok(activity);
        }
        catch (Exception ex){
            return BadRequest(ex);
        }
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteActivity(long Id){
        try{
            var activity = await _context.ActivityTypes
                .Where(e => e.Id == Id)
                .FirstOrDefaultAsync();
            if(activity == null){
                return BadRequest();
            }
            _context.ActivityTypes.Remove(activity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch(Exception ex){
            return BadRequest(ex);
        }
    }
}