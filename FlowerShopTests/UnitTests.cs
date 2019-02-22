using NUnit.Framework;
using FlowerShop;
using NSubstitute;
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
            IOrderDAO ord = Substitute.For<IOrderDAO>();//Mock
            IOrder o = new Order(ord,cl);//Actual object, made using mock data.

            //Act
            o.Deliver();

            //Assert
            ord.Received().SetDelivered(Arg.Any<IOrder>());
        }
    }
}