using FluentAssertions;
using Moq;
using System.Collections.Generic;
using VehicleTracking.API.Controllers;
using VehicleTracking.API.Helpers;
using VehicleTracking.Models;
using Xunit;

namespace VehicleTracking.API.Tests.Unit.Controllers
{
    public class FilterControllerTests
    {
        [Fact]
        public void Filter_controller_get_should_return_vehicles_list()
        {
            // Arrange 
            var externalRequestMock = new Mock<IExternalRequest>();
            
            string filter = "123456";
            string status = "Connected";

            var lstExpectedVehiclesList = new List<VehicleViewModel>
            {
                new VehicleViewModel{VehicleNumber = "123456",RegNr = "ABC123", Status = "Connected"}
            };


            externalRequestMock.Setup(x => x.ReadAllVehicles(filter, status))
                .Returns(lstExpectedVehiclesList);

            var controller = new FilterController(externalRequestMock.Object);
            
            // Act
            var vehiclesList = controller.Get(filter, status);

            // Assertion
            var contentResult = vehiclesList as List<VehicleViewModel>;
            contentResult.Should().BeEquivalentTo(lstExpectedVehiclesList);
        }


        [Fact]
        public void Filter_controller_get_should_return_empty_vehicles_list()
        {
            // Arrange 
            var externalRequestMock = new Mock<IExternalRequest>();

            string filter = "";
            string status = "Disconnected";

            var lstExpectedVehiclesList = new List<VehicleViewModel>
            {
            };
            
            externalRequestMock.Setup(x => x.ReadAllVehicles(filter, status))
                .Returns(lstExpectedVehiclesList);

            var controller = new FilterController(externalRequestMock.Object);

            // Act
            var vehiclesList = controller.Get(filter, status);

            // Assertion
            var contentResult = vehiclesList as List<VehicleViewModel>;
            contentResult.Should().BeEquivalentTo(lstExpectedVehiclesList);
        }
    }
}
