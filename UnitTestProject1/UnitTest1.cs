using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateSmallFloor()
        {

            var floor = FloorFactory.CreateFloor(0, 0, FloorType.Small);

            Assert.AreEqual(200, floor.Transform.ScaleX);
            Assert.AreEqual(50, floor.Transform.ScaleY);
        }
    }
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void CheckPortalSize()
        {
            Portal portal = new Portal(0, 0, PortalType.Orange, 1);

            Assert.AreEqual(25, portal.Transform.ScaleX);
            Assert.AreEqual(50, portal.Transform.ScaleY);

        }
    }
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void IsFireballNull()
        {
            var pool = new DynamicPoolFB();
            var boluDragon = new DragonHead(0, 0, 1);

            Fireball fireball = pool.GetFireball(boluDragon);

            Assert.IsNotNull(fireball);
        }
    }
}