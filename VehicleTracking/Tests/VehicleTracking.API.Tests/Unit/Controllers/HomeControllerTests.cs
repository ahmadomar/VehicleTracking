using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleTracking.API.Controllers;
using Xunit;

namespace VehicleTracking.API.Tests.Unit.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Home_Controller_Get_Should_return_strint_content()
        {
            // Arrange 
            var controller = new HomeController();

            // Act
            var result = controller.Get();

            // Assertion
            var contentResult = result as ContentResult;
            contentResult.Should().NotBeNull();
            contentResult.Content.Should().BeEquivalentTo("Hello from Gateway API!");
        }
    }
}
