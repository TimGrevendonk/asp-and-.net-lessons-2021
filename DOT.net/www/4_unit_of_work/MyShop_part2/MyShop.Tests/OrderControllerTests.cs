using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Controllers;
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
            var contextMock = new Mock<ShoppingContext>();

            var orderRepositoryMock = new Mock<OrderRepository>(contextMock.Object);

            orderRepositoryMock
                .Setup(o => o.All())
                .Returns(new List<Order>()
                {
                    new Order() {OrderID = 1, CustomerID = 2, }
                });
            var controller = new OrderController((IUnitOfWork)orderRepositoryMock);
                //new OrderController(
                //orderRepositoryMock.Object);

            // ACT
            var order = controller.Add(orderRepositoryMock);
            // ASSERT
            orderRepositoryMock.Verify(r => r.Add(It.IsAny<Order>()), Times.AtLeastOnce());
            Assert.Equals(orderRepositoryMock, order);

        }
    }
}
