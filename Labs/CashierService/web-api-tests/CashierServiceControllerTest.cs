using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using CashierServices.Controllers;
using CashierServices.Models;
using CashierServices.Contracts;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.Json;
using System.IO;


namespace CashierServicesTests
{
    public class CashierServiceControllerTest
    {
        CashierServiceController _controller;
        ICashierService _service;
        IOptions<ApplicationSettings> _settings;
        IMessageQueueService _messageQueue;

        public CashierServiceControllerTest()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            _settings = Options.Create(configuration.GetSection("ApplicationSettings").Get<ApplicationSettings>());
            
            _service = new CashierServiceFake(_settings);
            _messageQueue = new MessageQueueServiceFake();

            _controller = new CashierServiceController(_service, _messageQueue, _settings);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Order>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = _controller.Get(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = _controller.Get(testGuid).Result as OkObjectResult;

            // Assert
            Assert.IsType<Order>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as Order).orderid);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Order()
            {
                phone = "617-000-4343"
            };
            
            _controller.ModelState.AddModelError("name", "Required");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Order testItem = new Order()
            {
                name = "Henry Jones",
                phone = "617-000-9876"
            };

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Order()
            {
                name = "Jeff Jones",
                phone = "617-000-4543"
            };

            // Act
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Order;

            // Assert
            Assert.IsType<Order>(item);
            Assert.Equal("Jeff Jones", item.name);
        }

        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();

            // Act
            var badResponse = _controller.Remove(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResponse = _controller.Remove(existingGuid);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResponse = _controller.Remove(existingGuid);

            // Assert
            Assert.Equal(2, _service.GetAllItems().Count());
        }
    }
}