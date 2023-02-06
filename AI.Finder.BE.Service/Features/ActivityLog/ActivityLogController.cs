using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AI.Finder.BE.Service.Features.ActivityLog;
[ApiController]
[Route("[controller]")]
[Authorize]
public class ActivityLogController : ControllerBase{
    private readonly FinderDbContext _context;
    public ActivityLogController(FinderDbContext context){
        _context = context;
    }
    [HttpGet("{UserId}")]
    public async Task<IActionResult> GetActivityLog(long UserId){
        var log = await _context.ActivityLogs
            .ProjectToType<ActivityLogResponseDTO>()
            .Where(e => e.User.Id == UserId)
            .FirstOrDefaultAsync();
        if(log == null){
            return BadRequest();
        }
        return Ok(log);
    }
    [HttpPost]
    public async Task<IActionResult> CreateActivityLog(ActivityLogRequestDTO activityLogRequestDTO)
    {
        try{
            var User = await _context.Users
                .Where(e => e.Id == activityLogRequestDTO.UserId)
                .FirstOrDefaultAsync();
            var Candidate = await _context.Candidates
                .Where(e => e.Id == activityLogRequestDTO.CandidateId)
                .FirstOrDefaultAsync();
            var ActivityType = await _context.ActivityTypes
                .Where(e => e.Id == activityLogRequestDTO.ActivityTypeId)
                .FirstOrDefaultAsync();
            if(User == null || Candidate == null || ActivityType == null){
                return BadRequest();
            }
            var log = new ActivityLogModel{
                User = User,
                Candidate = Candidate,
                ActivityType = ActivityType,
                TimeStamp = activityLogRequestDTO.TimeStamp
            };
            if(log == null){
                return BadRequest();
            }
            await _context.ActivityLogs.AddAsync(log);
            await _context.SaveChangesAsync();
            return Ok(log);
        }
        catch(Exception ex){
            return BadRequest(ex);
        }
    }
    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateActivityLog(long Id, ActivityLogRequestDTO activityLogRequestDTO){
        try{
            var User = await _context.Users
                .Where(e => e.Id == activityLogRequestDTO.UserId)
                .FirstOrDefaultAsync();
            var Candidate = await _context.Candidates
                .Where(e => e.Id == activityLogRequestDTO.CandidateId)
                .FirstOrDefaultAsync();
            var ActivityType = await _context.ActivityTypes
                .Where(e => e.Id == activityLogRequestDTO.ActivityTypeId)
                .FirstOrDefaultAsync();
            if(User == null || Candidate == null || ActivityType == null){
                return BadRequest();
            }
            var log = await _context.ActivityLogs.Where(e => e.Id == Id).FirstOrDefaultAsync();
            if(log == null){
                return BadRequest();
            }
            log.User = User;
            log.Candidate = Candidate;
            log.ActivityType = ActivityType;
            log.TimeStamp = activityLogRequestDTO.TimeStamp;
            await _context.SaveChangesAsync();
            return Ok(log);
        }
        catch(Exception ex){
            return BadRequest(ex);
        }
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteActivityLog(long Id){
        try{
            var log = await _context.ActivityLogs.Where(e => e.Id == Id).FirstOrDefaultAsync();
            if(log == null){
                return BadRequest();
            }
            _context.ActivityLogs.Remove(log);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch(Exception ex){
            return BadRequest(ex);
        }
    }
}
