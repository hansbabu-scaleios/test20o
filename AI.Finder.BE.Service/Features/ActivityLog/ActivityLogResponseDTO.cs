using AI.Finder.BE.Service.Features.User;
using AI.Finder.BE.Service.Features.Candidate;
using AI.Finder.BE.Service.Features.ActivityType;

namespace AI.Finder.BE.Service.Features.ActivityLog;
public class ActivityLogResponseDTO{
    public long Id { get; set; }
    public UserModel User { get; set; }
    public CandidateModel Candidate { get; set; }
    public ActivityTypeModel ActivityType { get; set; }
    public DateTime TimeStamp { get; set; }
}