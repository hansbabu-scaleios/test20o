using AI.Finder.BE.Service.Features.State;

namespace AI.Finder.BE.Service.Features.District;
    public class DistrictModel{
        public long Id { get; set; }
        public StateModel State { get; set; }
        public string Name { get; set; }
    }
