using System.Collections.Generic;
using System.Threading.Tasks;
using AI.Finder.BE.Service.Features.Samples;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AI.Finder.BE.Test.Unit.Features.Sample;

    public class TestSampleController:FinderDBContextTestBase {
        [Fact]
        public async Task GetSample_ReturnOkObjectResult(){
            _context.Sample.AddRange((SampleData.GetSampleData()));
            _context.SaveChanges();

            var controller = new SampleController(_context);
            //Act
            var result = await controller.GetSamples();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
         [Fact]
        public async Task GetSample_ReturnAllAddressType(){
            //seeding
             _context.Sample.AddRange((SampleData.GetSampleData()));
            _context.SaveChanges();
            //Arrange
            var controller = new SampleController(_context);
            //Act
            var samples = await controller.GetSamples();
            var sut = Assert.IsType<OkObjectResult>(samples);
            var value = Assert.IsType<List<SampleResponseDTO>>(sut.Value);
            //Assert
            Assert.Equal(4, value.Count);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(8)]
        public async Task GetAddressType_ReturnBadRequest_GivenInvalidId(long id)
        {
            //seeding
            _context.Sample.AddRange((SampleData.GetSampleData()));
            _context.SaveChanges();
            //Arrange
            var controller = new SampleController(_context);
            var sample = await controller.GetSample(id);
            // Assert
            Assert.IsType<BadRequestResult>(sample);
        }
    }
