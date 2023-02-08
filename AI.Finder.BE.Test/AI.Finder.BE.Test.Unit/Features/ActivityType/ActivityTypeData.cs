using AI.Finder.BE.Service.Features.ActivityType;

namespace AI.Finder.BE.Test.Unit.Features.ActivityType;
public class ActivityTypeData{
    public static ActivityTypeModel GetActivityType()
    {
        return new ActivityTypeModel
        {
            Id = 1,
            Code = "LOGIN",
            Type = "LogIn"
        };
    }
    public static ActivityTypeModel AddActivityType()
    {
        return new ActivityTypeModel
        {
            Code = "LOGOUT",
            Type = "LogOut"
        };
    }
}