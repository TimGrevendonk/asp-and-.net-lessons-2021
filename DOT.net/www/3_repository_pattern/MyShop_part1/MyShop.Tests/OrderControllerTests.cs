using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Controllers;
using MyShop.Web.Models;
using System.Collections.Generic;

namespace MyShop.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void CanCreateOrderWithCorrectModel()
        {

            // ARRANGE
            // Mock the context.
            var contextMock = new Mock<ShoppingContext>();

            // Create an OrderModel filled with a customerModel and 2 LineItemModels
            var order = new CreateOrderModel
            {
                Customer = new CustomerModel { Name = "steven", ShippingAddress = "1", City = "geel", PostalCode = "1234", Country = "belgie" },

                LineItems = new List<LineItemModel> { 
                    new LineItemModel { ProductID = 1, Quantity = 3 },
                    new LineItemModel { ProductID = 2, Quantity = 4 } }
            };

            // Mock the needed Repositories, .Object is very important to make it an object instead of Mock.object (for data types)
            var productRepositoryMock = new Mock<GenericRepository<Product>>(contextMock.Object);
            var orderRepositoryMock = new Mock<GenericRepository<Order>>(contextMock.Object);

            // ACT
            // Initialize the controller with the Mocked Repositories, remember the .Object notation.
            var controller = new OrderController(
                productRepositoryMock.Object,
                orderRepositoryMock.Object
                ); 
            // Create the order with the controller method.
            controller.Create(order);

            // ASSERT
            // verify that the Add() has been called at least once in the mocked Repository.
            orderRepositoryMock.Verify(r => r.Add(It.IsAny<Order>()), Times.AtLeastOnce());

        }
    }
}
