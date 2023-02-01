using AI.Finder.BE.Service.Features.District;
namespace AI.Finder.BE.Service.Features.Town;
    public class TownModel{
        public long Id { get; set; }
        public DistrictModel District { get; set; }
        public string Name { get; set; }
        public Boolean IsVerified { get; set; }
    }
