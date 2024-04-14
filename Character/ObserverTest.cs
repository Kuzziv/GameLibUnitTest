using CharacterFactory.Models;
using GameLib.CharacterFactory.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLibUnitTest.Character
{
    // Create a mock observer class that implements the IObserver interface
    public class MockObserver : IObserver
    {
        // Add a flag to track whether the Update method is called
        public bool UpdateCalled { get; private set; }

        // Implement the Update method to set the flag when called
        public void Update()
        {
            UpdateCalled = true;
        }
    }

    [TestClass]
    public class ObserverTest
    {
        [TestMethod]
        public void TestObserverUpdate()
        {
            // Arrange
            var observerMock = new MockObserver(); // Use the mock observer instead of Moq
            var subject = new Player("Hero", 100, 20, 10, 0, 0);
            subject.Attach(observerMock);

            // Act
            subject.Notify();

            // Assert
            Assert.IsTrue(observerMock.UpdateCalled); // Verify that the Update method was called
        }

        [TestMethod]
        public void TestObserverDetach()
        {
            // Arrange
            var observerMock = new MockObserver();
            var subject = new Player("Hero", 100, 20, 10, 0, 0);
            subject.Attach(observerMock);

            // Act
            subject.Detach(observerMock);
            subject.Notify(); // Notify after detaching

            // Assert
            Assert.IsFalse(observerMock.UpdateCalled); // Verify that the Update method was not called after detaching
        }

        [TestMethod]
        public void TestMultipleObservers()
        {
            // Arrange
            var observer1 = new MockObserver();
            var observer2 = new MockObserver();
            var subject = new Player("Hero", 100, 20, 10, 0, 0);
            subject.Attach(observer1);
            subject.Attach(observer2);

            // Act
            subject.Notify();

            // Assert
            Assert.IsTrue(observer1.UpdateCalled); // Verify that the Update method was called for observer 1
            Assert.IsTrue(observer2.UpdateCalled); // Verify that the Update method was called for observer 2
        }

        // Add more tests as needed for additional scenarios
    }
}
