namespace AI.Finder.BE.Service.Features.User;
    public class UserRequestDTO{
        public string  UserId { get; set; }
        public string EmailId { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }

        //public string PasswordHash { get; set; }
        //public string PassowrdSalt { get; set; }
        //public string EmailConfirmationToken { get; set; }
        //public DateTime EmailTokenGeneratedTimestamp { get; set; }
        //public string PhoneConfirmationToken { get; set; }
        //public DateTime PhoneTokenGeneratedTimestamp { get; set; }
        //TODO: CandidateId & RelationId to be added after creation of candidate and addresstype models
        /*
        public long CandidateId { get; set; }
        public int RelationId { get; set; }
        */
    }
