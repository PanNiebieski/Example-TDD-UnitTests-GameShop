using AutoFixture;
using AutoFixture.AutoMoq;
using System;
using Xunit;

namespace ZTool_AutoFixtureExampleTest
{
    public class UnitTest1
    {
        [Fact]
        public void CreateRandomTimeSpan()
        {
            Fixture fixture = new Fixture();
            var atimeSpan = fixture.Create<TimeSpan>();
        }


        [Fact]
        public void CreateRandomDateTimeOffset()
        {
            Fixture fixture = new Fixture();
            var anDateTimeOffset = fixture.Create<DateTimeOffset>();
        }

        [Fact]
        public void PrepoluatedData()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var gameModelPopulated = fixture.Create<BuyGameModel>();
        }

        [Fact]
        public void TestingGuard()
        {
            Assert.Throws(typeof(NullReferenceException),
                () => { new Example(null, null); });
        }

        [Fact]
        public void TestingGuard2()
        {
            Assert.Throws(typeof(NullReferenceException),
                () => { new Example(new Dependency(), null); });
        }

        [Fact]
        public void TestingGuar3()
        {
            Assert.Throws(typeof(NullReferenceException),
                () => { new Example(null, new Dependency()); });
        }

        [Theory]
        [InlineData(typeof(Example))]
        [InlineData(typeof(AnotherExample))]
        //testing as many classes as want
        public void EnsureConstructorArgumentsNotNull(Type type)
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var assertion = new AutoFixture.Idioms.
                GuardClauseAssertion(fixture);
            assertion.Verify(type.GetConstructors());
        }
    }

    public class Example
    {
        private IDependency _a, _b;

        public Example(IDependency one, IDependency two)
        {
            _a = one ?? throw new ArgumentNullException(nameof(one));
            _b = two ?? throw new ArgumentNullException(nameof(two));
        }

    }
    public class AnotherExample
    {
        private IDependency _a, _b;

        public AnotherExample(IDependency one, IDependency two)
        {
            _a = one;
            _b = two;

        }
    }

    public class Dependency : IDependency
    {

    }
    public interface IDependency
    {
    }

    public class BuyGameModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public GameModel Game { get; set; }
        public DateTime Date { get; set; }
    }

    public class GameModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
