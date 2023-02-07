using System;
using System.Threading.Tasks;
using AI.Finder.BE.Service.Features.ActivityLog;
using AI.Finder.BE.Test.Unit.Features.Candidate;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AI.Finder.BE.Test.Unit.Features.ActivityLog;
[Route("[controller]")]
    public class TestActivityLogController : FinderDBContextTestBase
    {
       [Theory]
       [InlineData(1)]
        public async Task GetActivityLog_ReturActivityLogResponseDTOResult_GivenValiId(long id){
            context.ActivityLogs.AddRange(ActivityLogData.GetActivityLog());
            context.SaveChanges();
            var controller = new ActivityLogController(context);
            var result = await controller.GetActivityLog(id);
            var sut = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ActivityLogResponseDTO>(sut.Value);
        }
        [Theory]
        [InlineData(2)]
        public async Task GetActivityLog_ReturBadRequestResult_GivenInValiId(long id){
            context.ActivityLogs.AddRange(ActivityLogData.GetActivityLog());
            context.SaveChanges();
            var controller = new ActivityLogController(context);
            var result = await controller.GetActivityLog(id);
            Assert.IsType<BadRequestResult>(result);   
        }
        [Theory]
        [InlineData(1)]
        public async Task GetActivityLog_CheckFirst(long id){
            context.ActivityLogs.AddRange(ActivityLogData.GetActivityLog());
            context.SaveChanges();
            var controller = new ActivityLogController(context);
            var result = await controller.GetActivityLog(id);
            var sut = Assert.IsType<OkObjectResult>(result);
            var final = Assert.IsType<ActivityLogResponseDTO>(sut.Value);
            Assert.Equal("Abijith001", final.User.UserId);
        }
    }
