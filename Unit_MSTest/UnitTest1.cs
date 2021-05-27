using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ZTool_Unit_MSTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(7, 7)]
        public void TestIfGunCanFireManyTimes(int numberOfShots, int bullets)
        {
            gun = new Gun(bullets);

            for (int i = 0; i < numberOfShots; i++)
            {
                gun.Fire();
            }

            Assert.IsFalse(gun.Fire());
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void TestAddDynamicDataMethod(int a, int b, int expected)
        {

        }

        public static IEnumerable<int[]> GetData()
        {
            yield return new int[] { 1, 1, 2 };
            yield return new int[] { 12, 30, 42 };
            yield return new int[] { 14, 1, 15 };
        }

        [TestMethod]
        public void TestWhereThereIsABulltetThenFireReturnsTrue()
        {
            gun = new Gun(1);

            Assert.IsTrue(gun.Fire());
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void ShouldThrowNullReferenceExeptionWhenBulletsAreNull()
        {
            gun = new Gun(null);

            Assert.IsTrue(gun.Fire());
        }

        private Gun gun;
        [TestInitialize]
        public void Initialize()
        {
            gun = new Gun(1);
        }

        [TestCleanup]
        public void Cleanup()
        {
            gun.Recharge();
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
