using System.Threading.Tasks;
using AI.Finder.BE.Service.Features.ActivityType;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AI.Finder.BE.Test.Unit.Features.ActivityType;
public class TestActivityTypeController : FinderDBContextTestBase
{
    [Theory]
    [InlineData(1)]
    public async Task GetActivityType_ReturActivityTypeDTOResult_GivenValiId(long Id)
    {
        context.ActivityTypes.AddRange(ActivityTypeData.GetActivityType());
        await context.SaveChangesAsync();
        var controller = new ActivityTypeController(context);
        var result = await controller.GetActivity(Id);
        var sut = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<ActivityTypeResponseDTO>(sut.Value);
    }
    [Theory]
    [InlineData(2)]
    public async Task GGetActivityType_ReturnBadRequestResult_GivenInValiId(long Id)
    {
        context.ActivityTypes.AddRange(ActivityTypeData.GetActivityType());
        var controller = new ActivityTypeController(context);
        var result = await controller.GetActivity(Id);
        var sut = Assert.IsType<BadRequestResult>(result);
    }
    [Theory]
    [InlineData(1)]
    public async Task GetActivityType_CheckFirstId(long Id)
    {
        context.ActivityTypes.AddRange(ActivityTypeData.GetActivityType());
        context.SaveChanges();
        var controller = new ActivityTypeController(context);
        var result = await controller.GetActivity(Id);
        var sut = Assert.IsType<OkObjectResult>(result);
        var final = Assert.IsType<ActivityTypeResponseDTO>(sut.Value);
        Assert.Equal("LOGIN", final.Code);
    }
    [Fact]
    public async Task PostActivityType_ReturnNewlyCreatedActivityType(){
        context.ActivityTypes.AddRange(ActivityTypeData.GetActivityType());
        context.SaveChanges();
        var controller = new ActivityTypeController(context);
        var activityType = await controller.CreateActivity(new ActivityTypeRequestDTO{
            Code = "LOGOUT",
            Type = "LogOut"
        });
        var result = Assert.IsType<OkObjectResult>(activityType);
        var final = Assert.IsType<ActivityTypeResponseDTO>(result.Value);
        Assert.Equal("LOGOUT", final.Code);
    }
    [Fact]
    public async Task PutActivityType_ReturnOkResult_GivenValidId(){
        context.ActivityTypes.AddRange(ActivityTypeData.GetActivityType());
        context.SaveChanges();
        var controller = new ActivityTypeController(context);
        var activityType = await controller.UpdateActivity(1, new ActivityTypeRequestDTO{
            Code = "MSENT",
            Type = "Message Sent"
        });
        var result = Assert.IsType<OkObjectResult>(activityType);
        var final = Assert.IsType<ActivityTypeResponseDTO>(result.Value);
        Assert.Equal("MSENT", final.Code);
    }
}
