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
}
