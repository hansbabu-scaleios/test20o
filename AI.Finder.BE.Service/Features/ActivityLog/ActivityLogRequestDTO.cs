namespace AI.Finder.BE.Service.Features.ActivityLog;
public class ActivityLogRequestDTO{
    public long UserId { get; set; }
    public long CandidateId { get; set; }
    public long ActivityTypeId { get; set; }
    public DateTime TimeStamp { get; set; }
}