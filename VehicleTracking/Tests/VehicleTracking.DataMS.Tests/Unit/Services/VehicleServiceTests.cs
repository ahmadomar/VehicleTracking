using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VehicleTracking.DataMS.Infrastructure;
using VehicleTracking.DataMS.Repositories;
using VehicleTracking.DataMS.Services;
using VehicleTracking.Models;
using Xunit;

namespace VehicleTracking.DataMS.Tests.Unit.Services
{
    public class VehicleServiceTests
    {
        
        public VehicleServiceTests()
        {
        }

        [Fact]
        public async Task Vehicle_service_UpdateStatus_should_return_1()
        {
            // Arrange

            var _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            var _unitOfWorkMock = new Mock<IUnitOfWork>();
            
            _unitOfWorkMock.Setup(uof => uof.CommitAsync())
                            .ReturnsAsync(1);

            _vehicleRepositoryMock.Setup(vr => vr.Get(It.IsAny<Expression<Func<VehicleModel, bool>>>()))
                                               .Returns(new VehicleModel
                                               {
                                                   VehicleNumber = "123456",
                                                   RegNr = "ABC123",
                                                   Status = "Disconnected"
                                               });
            
            var vehicleService = new VehicleService(_unitOfWorkMock.Object, _vehicleRepositoryMock.Object);

            // Act

            var updateResult = await vehicleService.UpdateStatus("123456", "ABC123", "Connected");
            int expectedResult = 1;

            // Assert
            _vehicleRepositoryMock.Verify(x => x.Get(It.IsAny<Expression<Func<VehicleModel, bool>>>()), Times.Once);
            _unitOfWorkMock.Verify(uof => uof.CommitAsync(), Times.Once);
            updateResult.Should().Be(expectedResult);
        }

        [Fact]
        public async Task Vehicle_service_UpdateStatus_should_return_minus_1()
        {
            // Arrange

            var _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            var _unitOfWorkMock = new Mock<IUnitOfWork>();
            
            _vehicleRepositoryMock.Setup(vr => vr.Get(It.IsAny<Expression<Func<VehicleModel, bool>>>()));

            var vehicleService = new VehicleService(_unitOfWorkMock.Object, _vehicleRepositoryMock.Object);

            // Act

            var updateResult = await vehicleService.UpdateStatus("123456", "ABC123", "Connected");
            int expectedResult = -1;

            // Assert
            _vehicleRepositoryMock.Verify(x => x.Get(It.IsAny<Expression<Func<VehicleModel, bool>>>()), Times.Once);

            updateResult.Should().Be(expectedResult);
        }

        [Fact]
        public void Vehicle_service_GetAll_should_return_list_of_vehicles()
        {
            // Arrange
            var expectedVehiclesList = new List<VehicleModel>
                {
                    new VehicleModel{VehicleNumber = "123456", RegNr = "ABC123", Status = "Connected"}
                };
            var _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            var _unitOfWorkMock = new Mock<IUnitOfWork>();

            _vehicleRepositoryMock.Setup(vr => vr.GetAll())
                .Returns(expectedVehiclesList);

            var vehicleService = new VehicleService(_unitOfWorkMock.Object, _vehicleRepositoryMock.Object);

            // Act

            var vehiclesList = vehicleService.GetAll();
            
            // Assert
            vehiclesList.Should().BeEquivalentTo(expectedVehiclesList);
        }

        [Fact]
        public void Vehicle_service_GetAll_should_return_null()
        {
            // Arrange
            var _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            var _unitOfWorkMock = new Mock<IUnitOfWork>();

            List<VehicleModel> expectedVehiclesList = null;

            _vehicleRepositoryMock.Setup(vr => vr.GetAll())
                .Returns(expectedVehiclesList);
            
            var vehicleService = new VehicleService(_unitOfWorkMock.Object, _vehicleRepositoryMock.Object);

            // Act

            var vehiclesList = vehicleService.GetAll();

            // Assert
            vehiclesList.Should().BeEquivalentTo(expectedVehiclesList);
        }
    }
}
