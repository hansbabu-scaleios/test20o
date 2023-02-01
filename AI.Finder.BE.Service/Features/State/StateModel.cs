using AI.Finder.BE.Service.Features.Country;

namespace AI.Finder.BE.Service.Features.State;
    public class StateModel{
        public long Id { get; set; }
        public CountryModel Country { get; set; }
        public string Name { get; set; }
    }
