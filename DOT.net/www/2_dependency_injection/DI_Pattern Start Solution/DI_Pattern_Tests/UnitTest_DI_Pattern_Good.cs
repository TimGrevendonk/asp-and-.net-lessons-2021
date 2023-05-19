using DI_Pattern_Good;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DI_Pattern_Tests
{
    [TestClass]
    public class UnitTest_DI_Pattern_Good
    {
        [TestMethod]
        public void Test_OrderHandler_HandleOrder()
        {
            //order retrieves its dependency via the constructor
            //we can mock it and change its behavior for this test
            var mediumsender = new Mock<IContact>();
        //the following code simulates the execution of the contact() method and returns a value that we choose
        mediumsender.Setup(e => e.Contact(It.IsAny<int>(), It.IsAny<string>()))
                .Returns("a test message for this wonderful test");

        Order order = new Order(mediumsender.Object);

        OrderHandler orderhandler = new OrderHandler(order);

        //the handleorder() doesn't execute the contact method anymore, just the simulation which returns a string
        var response = orderhandler.HandleOrder();

        //test the price
        Assert.AreEqual(50.99, response.TotalPrice);
            //test the response (contact message) we setup using the mock
            Assert.AreEqual("a test message for this wonderful test", response.ContactMessage);
        }
}
}
