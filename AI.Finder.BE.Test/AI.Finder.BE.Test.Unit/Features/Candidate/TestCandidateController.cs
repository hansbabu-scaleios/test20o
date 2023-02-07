using System.Threading.Tasks;
using AI.Finder.BE.Service.Features.Candidate;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AI.Finder.BE.Test.Unit.Features.Candidate;

public class TestCandidateController : FinderDBContextTestBase{
    [Theory]
    [InlineData(1)]
    public async Task GetCandidate_ReturOCandidateDTOResult_GivenValiId(long id){
        //Add data to inmemory database
        context.Religions.AddRange((CandidateData.GetReligion()));
        context.SaveChanges();
        context.Candidates.AddRange((CandidateData.GetCandidate()));
        context.SaveChanges();
        //Arrange
        var controller = new CandidateController(context);
         //Act
        var result = await controller.GetCandidate(id);
        //Assert
        var sut = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<CandidateResponseDTO>(sut.Value);
    }
    [Theory]
    [InlineData(2)]
    public async Task GetCandidate_ReturnBadRequest_GivenInvalidId(long id){
        //Add data to inmemory database
        context.Religions.AddRange((CandidateData.GetReligion()));
        context.SaveChanges();
        context.Candidates.AddRange((CandidateData.GetCandidate()));
        context.SaveChanges();
        //Arrange
        var controller = new CandidateController(context);
        //Act
        var result = await controller.GetCandidate(id);
        //Assert
        Assert.IsType<BadRequestResult>(result);
    }
    [Theory]
    [InlineData(1)]
    public async Task GetCandidate_ReturnOkObjectResult_GivenValidId(long id){
        //Add data to inmemory database
        context.Religions.AddRange((CandidateData.GetReligion()));
        context.SaveChanges();
        context.Candidates.AddRange((CandidateData.GetCandidate()));
        context.SaveChanges();
        //Arrange
        var controller = new CandidateController(context);
         //Act
        var result = await controller.GetCandidate(id);
        //Assert
        Assert.IsType<OkObjectResult>(result);
    }
    [Theory]
    [InlineData(1)]
    public async Task GetCandidate_CheckFirstId(long id){
        //Add data to inmemory database
        context.Religions.AddRange((CandidateData.GetReligion()));
        context.SaveChanges();
        context.Candidates.AddRange((CandidateData.GetCandidate()));
        context.SaveChanges();
        //Arrange
        var controller = new CandidateController(context);
         //Act
        var result = await controller.GetCandidate(id);
        //Assert
        var sut = Assert.IsType<OkObjectResult>(result);
        var final=Assert.IsType<CandidateResponseDTO>(sut.Value);
        Assert.Equal("Akshay NR",final.Name);
    }
}

