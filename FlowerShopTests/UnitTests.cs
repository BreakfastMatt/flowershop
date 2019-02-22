using NUnit.Framework;
using FlowerShop;
using NSubstitute;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Arrange
            IClient cl = Substitute.For<IClient> ();//Mock
            IOrderDAO dao = Substitute.For<IOrderDAO>();//Mock
            IOrder order = new Order(dao,cl);//Actual object, made using mock data.

            //Act
            order.Deliver();

            //Assert
            dao.Received().SetDelivered(Arg.Any<IOrder>());
        }

        [Test]
        public void Test2()
        {
            //Arrange
            IClient cl = Substitute.For<IClient>();//Mock
            IOrderDAO dao = Substitute.For<IOrderDAO>();//Mock
            IOrder order = new Order(dao, cl);//Actual object, made using mock data.

            List<Flower> d = new List<Flower>();//empty list therefore is a mock
            Flower obj1 = Substitute.For<Flower>();//mock object
            Flower obj2 = Substitute.For<Flower>();//Mock object

            //Act
            obj1.Cost = 100;
            d.Add(obj1);
            d.Add(obj2);
            obj2.Cost = 150;

            //Assert
            Assert.AreEqual(order.Price, 300);
        }
    }
}