using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ZTool_Unit_NUnit
{
    public class Tests
    {
        [Test]
        public void TestWhereThereIsABulltetThenFireReturnsTrue()
        {
            gun = new Gun(1);

            Assert.IsTrue(gun.Fire());
        }

        [Test]
        public void ShouldThrowNullReferenceExeptionWhenBulletsAreNull()
        {

            Assert.Throws(typeof(InvalidOperationException),
                   () =>
                   {
                       gun = new Gun(null);
                   });
        }

        private Gun gun;
        [SetUp]
        public void Initialize()
        {
            gun = new Gun(1);
        }

        [TearDown]
        public void Cleanup()
        {
            gun.Recharge();
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        public void TestIfGunCanFireAsManyTimes(int numberOfShots, int bullets)
        {
            gun = new Gun(bullets);

            for (int i = 0; i < numberOfShots; i++)
            {
                Assert.IsTrue(gun.Fire());
            }

            Assert.IsFalse(gun.Fire());
        }

        public static IEnumerable<int[]> GetData()
        {
            yield return new int[] { 1, 1, 2 };
            yield return new int[] { 12, 30, 42 };
            yield return new int[] { 14, 1, 15 };
        }

        [TestCaseSource("GetData")]
        public void TestAddDynamicDataMethod(int a, int b, int expected)
        {

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
}