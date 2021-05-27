using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace ZTool_Unit_XUnit
{
    public class IndexOfData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { 1, 1, 2 },
            new object[] { 12, 30, 42 },
            new object[] { 14, 1, 15 }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }


    public class UnitTest
    {
        private Gun gun;
        public UnitTest()
        {
            gun = new Gun(1);
        }


        [Fact]
        public void TestWhereThereIsABulltetThenFireReturnsTrue()
        {
            gun = new Gun(1);

            Assert.True(gun.Fire());
        }

        [Fact]
        public void ShouldThrowNullReferenceExeptionWhenBulletsAreNull()
        {

            Assert.Throws(typeof(InvalidOperationException),
                   () =>
                   {
                       gun = new Gun(null);
                   });
        }


        [Theory, MemberData(nameof(DynamicDataAsProperty))]
        public void TestAddDynamicDataMethod(int a, int b, int expected)
        {

        }

        [Theory, ClassData(typeof(IndexOfData))]
        public void TestAddDynamicDataMethod2(int a, int b, int expected)
        {

        }

        public static IEnumerable<object[]> DynamicDataAsProperty
        {
            get
            {
                return new[]
                {
                     new object[] { 1, 1, 2 },
                     new object[] { 12, 30, 42 },
                     new object[] { 14, 1, 15 }
                };
            }
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void TestIfGunCanFireAsManyTimes(int numberOfShots, int bullets)
        {
            gun = new Gun(bullets);

            for (int i = 0; i < numberOfShots; i++)
            {
                Assert.True(gun.Fire());
            }

            Assert.False(gun.Fire());
        }

    }

    public class Gun
    {
        private int _bullets;
        private int _howmanyBulletsCanGunHave;

        public Gun(int? bullets)
        {
            _howmanyBulletsCanGunHave = bullets.Value;
            _bullets = bullets.Value;
        }

        public bool Fire()
        {
            if (_bullets > 0)
            {
                _bullets = _bullets - 1;
                return true;
            }
            return false;
        }

        public bool HasAmmo()
        {
            return _bullets > 0;
        }

        public void Recharge()
        {
            _bullets = _howmanyBulletsCanGunHave;
        }
    }
}
