namespace AI.Finder.BE.Service.Features.Religion;
    public class ReligionModel{
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string TreePath { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Boolean IsVerified { get; set; }

    }
