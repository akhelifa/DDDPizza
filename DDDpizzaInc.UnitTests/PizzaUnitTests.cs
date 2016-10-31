using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Events;
using DDDPizzaInc.DomainModels;
using DDDPizzaInc.DomainModels.Events;
using DDDPizzaInc.DomainModels.Handlers;
using DDDPizzaInc.DomainModels.Interfaces;
using DDDPizzaInc.Mocks;
using Moq;
using NUnit.Framework;

namespace DDDpizzaInc.UnitTests
{
    [TestFixture, Category("UnitTests")]
    public class PizzaUnitTests
    {
        private Mock<IEventPublisher> _mockEventPublisher;
        private Mock<IMessageService> _mockMessageService;

        [SetUp]
        public void Setup()
        {
            _mockEventPublisher = new Mock<IEventPublisher>(MockBehavior.Strict);
            _mockMessageService = new Mock<IMessageService>(MockBehavior.Strict);
        }

        #region " INVENTORY TESTS "

        [Test]
        public void Should_Create_Instance_Of_Bread()
        {
            // Arrange
            const string name = "Double Crust";

            //Act
            var sut = new Bread(name);
            var serialize = sut.ShouldSerializePrice();

            //Assert
            Assert.IsInstanceOf<Bread>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Bread_With_Guid()
        {
            // Arrange
            const string name = "Double Crust";
            var id = Guid.NewGuid();
 
            // Act
            var sut = new Bread(id, name);
            var serialize = sut.ShouldSerializePrice();

            // Assert
            Assert.IsInstanceOf<Bread>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Cheese()
        {
            const string name = "Mozzarella";
            var sut = new Cheese(name);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Cheese>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Cheese_With_Guid()
        {
            const string name = "Mozzarella";
            var id = Guid.NewGuid();
            var sut = new Cheese(id, name);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Cheese>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Sauce()
        {
            const string name = "Pesto";
            var sut = new Sauce(name);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Sauce>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Sauce_With_Guid()
        {
            var id = Guid.NewGuid();
            const string name = "Pesto";
            var sut = new Sauce(id, name);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Sauce>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Size()
        {
            // Arrange
            const decimal price = 23.11m;
            
            // Act
            var sut = new Size("reallyBig!", price);
            var serialize = sut.ShouldSerializePrice();
            
            // 
            Assert.IsInstanceOf<Size>(sut);
            Assert.NotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(price, sut.Price);
            Assert.AreEqual(true, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Size_With_Guid()
        {
            // Arrange
            var id = Guid.NewGuid();
            const decimal price = 23.11m;

            // Act
            var sut = new Size(id, "reallyBig!", price);
            var serialize = sut.ShouldSerializePrice();

            // Assert
            Assert.IsInstanceOf<Size>(sut);
            Assert.NotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(price, sut.Price);
            Assert.AreEqual(true, serialize);
        }

        #endregion

        [Test]
        public void Should_Create_Instance_Of_Pizza_Calculate_Total()
        {
            // Arrange

            var toppingsCost = PizzaMocks.ToppingMocks().Sum(x => x.Price);
            var sizeCost = PizzaMocks.SizeMocks().First().Price;
            var expectedCost = toppingsCost + sizeCost;

            // Act
            var sut = new Pizza(
                                PizzaMocks.ToppingMocks().ToList(), 
                                PizzaMocks.SizeMocks().First(), 
                                PizzaMocks.BreadMocks().ElementAt(1), 
                                PizzaMocks.GetSauces().ElementAt(1), 
                                PizzaMocks.GetCheese().ElementAt(2));

            // Assert
            Assert.IsInstanceOf<Pizza>(sut);
            Assert.Less( 0, sut.Total);
            Assert.AreEqual(expectedCost, sut.Total);
        }

        [Test]
        public void Should_Create_Instance_Of_Order_With_Delivery()
        {
            // Arrange
            _mockEventPublisher.Setup(x => x.Publish(It.IsAny<IDomainEvent>())).Callback(() =>
            {
                new OrderNeedsDelivery(It.IsAny<Order>());
            });

            // Act
            var pizza = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            var pizzas = new List<Pizza>() { pizza };
            var sut = new Order(ServiceType.Delivery, pizzas, "Jose");
            sut.ProcessOrder(sut, _mockEventPublisher.Object);

            // Assert
            _mockEventPublisher.VerifyAll();
            _mockEventPublisher.Verify(x => x.Publish(It.IsAny<IDomainEvent>()), Times.Once);
            Assert.IsInstanceOf<Order>(sut);
            Assert.Greater(sut.ServiceCharge, 0);
            Assert.Greater(sut.SubTotal, 0);
            Assert.AreEqual(sut.ServiceCharge + sut.SubTotal, sut.TotalAmount);
        }

        [Test]
        public void Should_Create_Instance_Of_Order_With_InRestaurant()
        {
            // Arrange
            var pizza = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            var pizzas = new List<Pizza>() { pizza };
            
            // Act
            var sut = new Order(ServiceType.InRestaurant, pizzas, "Jose");
            sut.ProcessOrder(sut, _mockEventPublisher.Object);

            // Assert
            _mockEventPublisher.VerifyAll();
            _mockEventPublisher.Verify(x => x.Publish(It.IsAny<IDomainEvent>()), Times.Never);
            Assert.IsInstanceOf<Order>(sut);
            Assert.AreEqual(sut.ServiceCharge, 0);
            Assert.Greater(sut.SubTotal, 0);
            Assert.AreEqual(sut.ServiceCharge + sut.SubTotal, sut.TotalAmount);
        }


        [Test]
        public void Should_Create_Instance_Of_Order_With_TakeOut()
        {
            // Arrange
            var pizza = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            var pizzas = new List<Pizza>() { pizza };

            // Act
            var sut = new Order(ServiceType.TakeOut, pizzas, "Jose");
            sut.ProcessOrder(sut, _mockEventPublisher.Object);

            // Assert
            _mockEventPublisher.VerifyAll();
            _mockEventPublisher.Verify(x => x.Publish(It.IsAny<IDomainEvent>()), Times.Never);
            Assert.IsInstanceOf<Order>(sut);
            Assert.AreEqual(sut.ServiceCharge, 0);
            Assert.Greater(sut.SubTotal, 0);
            Assert.AreEqual(sut.ServiceCharge + sut.SubTotal, sut.TotalAmount);
        }

        [Test]
        public void Should_Create_Instance_Of_NotifyOrderNeedsDelivery()
        {
            //Arrange
            _mockMessageService.Setup(x => x.NotifyDelivery(It.IsAny<Order>())).Verifiable();
            var pizza = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            var pizzas = new List<Pizza>() { pizza };
            var order = new Order(ServiceType.TakeOut, pizzas, "Jose");

            //Act
            var sut = new NotifyOrderNeedsDelivery(_mockMessageService.Object);
            sut.Handle(new OrderNeedsDelivery(order));

            //Assert
            _mockMessageService.VerifyAll();
            _mockMessageService.Verify(x => x.NotifyDelivery(It.IsAny<Order>()), Times.Once);
            Assert.Pass();

        }

    }
}
