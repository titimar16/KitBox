﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class ShoppingCartTest
    {
        private ShoppingCart shopcart1;
        private ShoppingCart shopcart2;

        private Cupboard cupboard1;

        private Locker locker1;
        private Locker locker2;

        private CrossBar crossBarWithParam1;
        private CrossBar crossBarWithParam2;

        private Cleat cleatWithParam1;
        private Cleat cleatWithParam2;

        private Door doorWithParam1;

        [TestInitialize()]
        public void testsInitialize()
        {
            shopcart1 = new ShoppingCart();
            shopcart2 = new ShoppingCart();

            cupboard1 = new Cupboard();

            crossBarWithParam1 = new CrossBar(10, "referenceTest", "1", new Size(0, 0, 0), false, 0, Color.white);
            crossBarWithParam2 = new CrossBar(10, "referenceTest", "1", new Size(0, 0, 0), false, 0, Color.white);

            cleatWithParam1 = new Cleat(50, "referenceTest", "1", new Size(0, 0, 0), false, 0, Color.white);
            cleatWithParam2 = new Cleat(50, "referenceTest", "1", new Size(0, 0, 0), false, 0, Color.white);

            doorWithParam1 = new Door(40, "referenceTest", "1", new Size(0, 0, 0), false, 0, Color.white);
        }

        [TestMethod]
        public void buildLockerTest()
        {
            shopcart1.addCatalogueComponent(crossBarWithParam1);
            shopcart1.addCatalogueComponent(crossBarWithParam2);
            shopcart1.addCatalogueComponent(cleatWithParam1);
            shopcart1.addCatalogueComponent(cleatWithParam2);
            shopcart1.addCatalogueComponent(doorWithParam1);

            locker1 = shopcart1.buildLocker();

            Assert.AreEqual(160, locker1.price);
            Assert.AreEqual(5, locker1.componentsList.Count);

            locker1.removeComponent(crossBarWithParam1);

            Assert.AreEqual(150, locker1.price);
            Assert.AreEqual(4, locker1.componentsList.Count);
        }

        // test if when you add catalogue components in excess, the building of locker remove correctly the components added to the locker from catalogue components list
        [TestMethod]
        public void buildLockerWithExcessComponentTest()
        {
            shopcart1.addCatalogueComponent(crossBarWithParam1);
            shopcart1.addCatalogueComponent(crossBarWithParam2);
            shopcart1.addCatalogueComponent(cleatWithParam1);
            shopcart1.addCatalogueComponent(cleatWithParam2);
            shopcart1.addCatalogueComponent(doorWithParam1);

            locker1 = shopcart1.buildLocker();

            Assert.AreEqual(160, locker1.price);
            Assert.AreEqual(5, locker1.componentsList.Count);
            Assert.AreEqual(0, shopcart1.catalogueComponentsList.Count);

            shopcart1.addCatalogueComponent(cleatWithParam2);
            shopcart1.addCatalogueComponent(cleatWithParam2);
            shopcart1.addCatalogueComponent(cleatWithParam2);
            shopcart1.addCatalogueComponent(cleatWithParam2);
            shopcart1.addCatalogueComponent(cleatWithParam2);
            shopcart1.addCatalogueComponent(cleatWithParam2);

            locker1 = shopcart1.buildLocker();

            Assert.AreEqual(2, shopcart1.catalogueComponentsList.Count);
        }

        [TestMethod]
        public void buildCupboardTest()
        {
            shopcart1.addCatalogueComponent(crossBarWithParam1);
            shopcart1.addCatalogueComponent(crossBarWithParam2);
            shopcart1.addCatalogueComponent(cleatWithParam1);
            shopcart1.addCatalogueComponent(cleatWithParam2);
            shopcart1.addCatalogueComponent(doorWithParam1);

            // price of locker1 is 160
            locker1 = shopcart1.buildLocker();

            shopcart1.addCatalogueComponent(crossBarWithParam2);
            shopcart1.addCatalogueComponent(cleatWithParam1);
            shopcart1.addCatalogueComponent(cleatWithParam2);

            // price of locker2 110
            locker2 = shopcart1.buildLocker();

            shopcart1.addCupboardComponent(locker1);
            shopcart1.addCupboardComponent(locker2);

            shopcart1.buildCupboard();
            cupboard1 = shopcart1.cupboard;

            Assert.AreEqual(270, cupboard1.getPrice());
        }
    }
}
