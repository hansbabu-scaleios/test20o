using AI.Finder.BE.Service.Features.ActivityLog;
using AI.Finder.BE.Service.Features.User;
using AI.Finder.BE.Test.Unit.Features.ActivityType;
using AI.Finder.BE.Test.Unit.Features.Candidate;
using System;
namespace AI.Finder.BE.Test.Unit.Features.ActivityLog;

public class ActivityLogData{
    public static ActivityLogModel GetActivityLog(){
        return new ActivityLogModel{
            Id = 1,
            User = GetUser(),
            Candidate = CandidateData.GetCandidate(),
            ActivityType = ActivityTypeData.GetActivityType(),
            TimeStamp = Convert.ToDateTime("01-02-2023")
        };
    }
    public static UserModel GetUser(){
        return new UserModel{
        Id = 1,
        UserId = "Abijith001",
        EmailId = "abijith@mail.com",
        PhoneNumber = 1234567890,
        PasswordHash ="fgdfgdfgdgdgfgdfvdfgdf",
        PassowrdSalt = "dsfigrjkbruirhuitbreb",
        EmailConfirmationToken = "sdfuyfdsytfjkgdys",
        EmailTokenGeneratedTimestamp = Convert.ToDateTime("01-01-2023"),
        PhoneConfirmationToken = "dsfdsfsieriehgjhvghf",
        PhoneTokenGeneratedTimestamp = Convert.ToDateTime("01-01-2023")
        };
       
    }
    public static UserModel GetUser2(){
        return new UserModel{
        Id = 2,
        UserId = "Abijith002",
        EmailId = "abijith002@mail.com",
        PhoneNumber = 1234567891,
        PasswordHash ="fgdfgdfgdgdgfghghgdfvdfgdf",
        PassowrdSalt = "dsfigrjdsgskbruirhuitbreb",
        EmailConfirmationToken = "sdfuyfddssytfjkgdys",
        EmailTokenGeneratedTimestamp = Convert.ToDateTime("01-02-2023"),
        PhoneConfirmationToken = "dsfdsfsieriehgjhsdsvghf",
        PhoneTokenGeneratedTimestamp = Convert.ToDateTime("01-02-2023")
        };
       
    }
}
