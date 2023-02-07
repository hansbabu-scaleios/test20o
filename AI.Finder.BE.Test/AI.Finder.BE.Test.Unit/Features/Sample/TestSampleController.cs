using System.Collections.Generic;
using System.Threading.Tasks;
using AI.Finder.BE.Service.Features.Samples;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AI.Finder.BE.Test.Unit.Features.Sample;

    public class TestSampleController:FinderDBContextTestBase {
        [Fact]
        public async Task GetSample_ReturnOkObjectResult(){
            context.Sample.AddRange((SampleData.GetSampleData()));
            context.SaveChanges();

            var controller = new SampleController(context);
            //Act
            var result = await controller.GetSamples();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
         [Fact]
        public async Task GetSample_ReturnAllSammples(){
            //seeding
             context.Sample.AddRange((SampleData.GetSampleData()));
            context.SaveChanges();
            //Arrange
            var controller = new SampleController(context);
            //Act
            var samples = await controller.GetSamples();
            var sut = Assert.IsType<OkObjectResult>(samples);
            var value = Assert.IsType<List<SampleResponseDTO>>(sut.Value);
            //Assert
            Assert.Equal(4, value.Count);
        }

    }
