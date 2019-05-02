using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RawRabbit;
using System.Threading.Tasks;
using VehicleTracking.API.Controllers;
using Xunit;

namespace VehicleTracking.API.Tests.Unit.Controllers
{
    public class StatusControllerTests
    {
        [Fact]
        public async Task Status_controller_post_should_return_accepted()
        {
            // Arrange 
            var busClientMock = new Mock<IBusClient>();
            var controller = new StatusController(busClientMock.Object);

            var command = new Common.MQ.Commands.StatusChangeCommand
            {
                VehicleNumber = "123456",
                RegNr = "ABC123",
                Status = "Connected"
            };

            // Act
            var result = await controller.Post(command);

            // Assertion
            var contentResult = result as AcceptedResult;
            contentResult.Should().NotBeNull();
            contentResult.Location.Should().BeEquivalentTo($"status/{command.VehicleNumber + command.RegNr}");
        }
    }
}
