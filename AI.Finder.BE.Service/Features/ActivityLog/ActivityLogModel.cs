using AI.Finder.BE.Service.Features.ActivityType;
using AI.Finder.BE.Service.Features.Candidate;
using AI.Finder.BE.Service.Features.User;

namespace AI.Finder.BE.Service.Features.ActivityLog;
    public class ActivityLogModel
    {
        public long Id { get; set; }
        public UserModel User { get; set; }
        public CandidateModel Candidate { get; set; }
        public ActivityTypeModel ActivityType { get; set; }
        public DateTime TimeStamp { get; set; }
    }
