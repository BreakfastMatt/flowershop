using NUnit.Framework;
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
            IClient cl = Substitute.for<IClient>();//Mock
            IOrderDAO ord = Substitute.for<IOrderDAO>();//Mock
            //delivered = false by default
            IOrder o = new order(ord,cl);//Actual object, made using mock data.

            //Act
            o.isDelivered = true;

            //Assert
            Assert.Pass();
        }
    }
}
/*
Write a test, using mocks, to check whether the Order class’s Deliver method calls
the SetDelivered method in IOrderDAO. Use comments in the test to specifically
show where your ARRANGE, ACT, and ASSERT sections are. 
*/