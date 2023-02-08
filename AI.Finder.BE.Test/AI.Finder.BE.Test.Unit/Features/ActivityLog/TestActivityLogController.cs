using System;
using System.Threading.Tasks;
using AI.Finder.BE.Service.Features.ActivityLog;
using AI.Finder.BE.Test.Unit.Features.ActivityType;
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
        [Fact]
        public async Task PostActivityLog_ReturnNewlyCreatedActivityLog(){
            context.Users.AddRange(ActivityLogData.GetUser2());
            context.SaveChanges();
            context.Religions.AddRange(CandidateData.GetReligion());
            context.SaveChanges();
            context.Candidates.AddRange(CandidateData.GetCandidate2());
            context.SaveChanges();
            context.ActivityTypes.AddRange(ActivityTypeData.GetActivityType());
            context.SaveChanges();
            var controller = new ActivityLogController(context);
            var activityLog = await controller.CreateActivityLog(new ActivityLogRequestDTO{
            UserId = 2,
            CandidateId = 2,
            ActivityTypeId = 1,
            TimeStamp = Convert.ToDateTime("02-02-2023")
            });
            var result = Assert.IsType<OkObjectResult>(activityLog);
            var final = Assert.IsType<ActivityLogResponseDTO>(result.Value);
            Assert.Equal("Abijith002", final.User.UserId);
        }
        public async Task PutActivityLog_ReturnOkResult_GivenValidId(){
            context.Users.AddRange(ActivityLogData.GetUser2());
            context.SaveChanges();
            context.ActivityLogs.AddRange(ActivityLogData.GetActivityLog());
            context.SaveChanges();
            var controller = new ActivityLogController(context);
            var activityLog = await controller.UpdateActivityLog(1, new ActivityLogRequestDTO{
                UserId = 2,
                CandidateId = 1,
                ActivityTypeId = 1,
                TimeStamp = Convert.ToDateTime("02-02-2023")
            });
            var result = Assert.IsType<OkObjectResult>(activityLog);
            var final = Assert.IsType<ActivityLogResponseDTO>(result.Value);
            Assert.Equal("Abijith002", final.User.UserId);

        }
    }
