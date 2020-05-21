﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class CupboardTest
    {
        private Cupboard cupboard1;
        private Cupboard cupboard2;

        private AngleBracket angleBracketParam1;
        private AngleBracket angleBracketParam2;

        private Locker locker1;
        private Locker locker2;
        private Locker locker3;
        private Locker locker4;

        private CrossBar crossBar1;
        private CrossBar crossBar2;
        private CrossBar crossBar3;
        private CrossBar crossBar4;
        private CrossBar crossBar5;
        private CrossBar crossBar6;
        private CrossBar crossBar7;
        private CrossBar crossBar8;
        private CrossBar crossBarWithParam1;
        private CrossBar crossBarWithParam2;
        private CrossBar crossBarWithParam3;

        private Panels pannel1;
        private Panels pannel2;
        private Panels pannel3;
        private Panels pannel4;
        private Panels pannel5;
        private Panels pannelWithPara1;

        private Cleat cleat1;
        private Cleat cleat2;
        private Cleat cleat3;
        private Cleat cleat4;
        private Cleat cleatWithPara1;

        private List<CatalogueComponents> catalogueComponentsListFull;
        private List<CatalogueComponents> catalogueComponentsListWith13;
        private List<CatalogueComponents> catalogueComponentsListWith5WithParam;
        private List<CatalogueComponents> catalogueComponentsListWith2WithParam;

        private List<ICupboardComponents> cupboardComponentsListWith3;


        [TestInitialize()]
        public void testsInitialize()
        {
            cupboard1 = new Cupboard();
            cupboard2 = new Cupboard();

            angleBracketParam1 = new AngleBracket(100, "null", "0000", new ComponentSize(45, 0, 0), false, ComponentColor.white);
            angleBracketParam2 = new AngleBracket(25, "null", "0000", new ComponentSize(0, 0, 0), false, ComponentColor.white);

            locker1 = new Locker();
            locker2 = new Locker();
            locker3 = new Locker();
            locker4 = new Locker();

            crossBar1 = new CrossBar();
            crossBar2 = new CrossBar();
            crossBar3 = new CrossBar();
            crossBar4 = new CrossBar();
            crossBar5 = new CrossBar();
            crossBar6 = new CrossBar();
            crossBar7 = new CrossBar();
            crossBar8 = new CrossBar();
            crossBarWithParam1 = new CrossBar(10, "referenceTest", "1", new ComponentSize(21, 0, 0), false, CrossBarType.F);
            crossBarWithParam2 = new CrossBar(20, "referenceTest", "2", new ComponentSize(11, 0, 0), false, CrossBarType.F);
            crossBarWithParam3 = new CrossBar(20, "referenceTest", "3", new ComponentSize(8, 0, 0), false, CrossBarType.F);

            pannel1 = new Panels();
            pannel2 = new Panels();
            pannel3 = new Panels();
            pannel4 = new Panels();
            pannel5 = new Panels();
            pannelWithPara1 = new Panels(10, "referenceTest", "1", new ComponentSize(23, 0, 0), false, ComponentColor.white, PanelsType.B);

            cleat1 = new Cleat();
            cleat2 = new Cleat();
            cleat3 = new Cleat();
            cleat4 = new Cleat();
            cleatWithPara1 = new Cleat(10, "referenceTest", "1", new ComponentSize(10, 0, 0), false);

            catalogueComponentsListFull = new List<CatalogueComponents>(){ crossBar1, crossBar2, crossBar3, crossBar4, crossBar5, crossBar6 ,crossBar7, crossBar8,
                                                                            cleat1, cleat2, cleat3, cleat4,
                                                                            pannel1, pannel2, pannel3, pannel4, pannel5};

            catalogueComponentsListWith13 = new List<CatalogueComponents>(){ crossBar1, crossBar2, crossBar3, crossBar4, crossBar5, crossBar6 ,crossBar7, crossBar8,
                                                                            cleat1, cleat2, cleat3, cleat4,
                                                                            pannel1};

            catalogueComponentsListWith5WithParam = new List<CatalogueComponents>(){ crossBarWithParam1, crossBarWithParam2, crossBarWithParam3,
                                                                            cleatWithPara1,
                                                                            pannelWithPara1};

            catalogueComponentsListWith2WithParam = new List<CatalogueComponents>() { cleatWithPara1, pannelWithPara1 };

            cupboardComponentsListWith3 = new List<ICupboardComponents>() { locker1, locker2, locker3 };
        }

        /// <summary>
        ///     check if the function which search an angle in list work fine
        /// </summary>
        [TestMethod]
        public void findAnglesTest()
        {
            var privateCupboard = new PrivateObject(cupboard1);

            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker2);
            cupboard1.addCupboardComponent(locker3);
            cupboard1.addCupboardComponent(locker4);
            Assert.AreEqual(-1, privateCupboard.Invoke("locationOfAngleInList"));

            cupboard1.addCupboardComponent(angleBracketParam1);

            privateCupboard = new PrivateObject(cupboard1);

            Assert.AreEqual(4, privateCupboard.Invoke("locationOfAngleInList"));

            cupboard1 = new Cupboard();
            cupboard1.addCupboardComponent(locker3);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker2);
            cupboard1.addCupboardComponent(angleBracketParam1);
            cupboard1.addCupboardComponent(locker4);

            privateCupboard = new PrivateObject(cupboard1);

            Assert.AreEqual(3, privateCupboard.Invoke("locationOfAngleInList"));

            cupboard1 = new Cupboard();
            cupboard1.addCupboardComponent(locker2);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(angleBracketParam1);
            cupboard1.addCupboardComponent(locker3);
            cupboard1.addCupboardComponent(locker4);

            privateCupboard = new PrivateObject(cupboard1);

            Assert.AreEqual(2, privateCupboard.Invoke("locationOfAngleInList"));
        }

        [TestMethod]
        public void getAngleBracket()
        {
            Assert.AreEqual("null", cupboard1.getAngleBracket().reference);
        }

        [TestMethod]
        public void getPriceTest()
        {
            cupboard1.addCupboardComponent(angleBracketParam2);

            locker1.addComponent(crossBarWithParam1);
            locker1.addComponent(crossBarWithParam2);
            locker1.addComponent(crossBarWithParam3);

            cupboard1.addCupboardComponent(locker1);

            Assert.AreEqual(75, cupboard1.getPrice());
        }

        [TestMethod]
        public void isCompleteTest()
        {
            cupboard1.addCupboardComponent(angleBracketParam2);
            cupboard2.addCupboardComponent(angleBracketParam2);

            locker1.addComponent(catalogueComponentsListFull);

            locker2.addComponent(catalogueComponentsListWith13);

            cupboard1.addCupboardComponent(locker1);
            cupboard2.addCupboardComponent(locker2);

            Assert.AreEqual(true, cupboard1.isComplete());
            Assert.AreEqual(false, cupboard2.isComplete());
        }

        /// <summary>
        ///     check if the function which 
        /// </summary>
        [TestMethod]
        public void allLockerIsCompleteTest()
        {
            locker1.addComponent(catalogueComponentsListFull);

            cupboard1.addCupboardComponent(locker1);
            cupboard2.addCupboardComponent(locker2);

            var privateCupboard = new PrivateObject(cupboard1);
            var privateCupboard2 = new PrivateObject(cupboard2);

            Assert.AreEqual(true, privateCupboard.Invoke("allLockerIsComplete"));
            Assert.AreEqual(false, privateCupboard2.Invoke("allLockerIsComplete"));
        }

        [TestMethod]
        public void lockerAvailableTest()
        {
            Assert.AreEqual(7, cupboard1.lockerAvailable);

            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker2);
            Assert.AreEqual(5, cupboard1.lockerAvailable);

            cupboard1.removeCupboardComponent(locker1);
            Assert.AreEqual(6, cupboard1.lockerAvailable);

            cupboard1.removeCupboardComponent(locker2);
            Assert.AreEqual(7, cupboard1.lockerAvailable);

            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker1);
            Assert.AreEqual(7, cupboard1.lockerAvailable);
        }

        [TestMethod]
        public void addLockerTest()
        {
            Assert.AreEqual(0, cupboard1.cupboardComponentsList.Count);

            cupboard1.addCupboardComponent(locker1);
            Assert.AreEqual(1, cupboard1.cupboardComponentsList.Count);

            cupboard1.addCupboardComponent(locker2);
            Assert.AreEqual(2, cupboard1.cupboardComponentsList.Count);

            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker2);
            cupboard1.addCupboardComponent(locker2);
            cupboard1.addCupboardComponent(locker3);
            cupboard1.addCupboardComponent(locker3);
            cupboard1.addCupboardComponent(locker3);
            Assert.AreEqual(7, cupboard1.cupboardComponentsList.Count);

            Assert.AreEqual(0, cupboard2.cupboardComponentsList.Count);

            cupboard2.addCupboardComponent(cupboardComponentsListWith3);
            Assert.AreEqual(3, cupboard2.cupboardComponentsList.Count);

            cupboard2.addCupboardComponent(cupboardComponentsListWith3);
            cupboard2.addCupboardComponent(cupboardComponentsListWith3);
            cupboard2.addCupboardComponent(cupboardComponentsListWith3);
            cupboard2.addCupboardComponent(cupboardComponentsListWith3);
            Assert.AreEqual(7, cupboard2.cupboardComponentsList.Count);
        }

        [TestMethod]
        public void removeLockerTest()
        {
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker2);
            cupboard1.addCupboardComponent(locker3);

            cupboard1.removeCupboardComponent(locker2);
            Assert.AreEqual(4, cupboard1.cupboardComponentsList.Count);

            cupboard1.removeCupboardComponent(locker1);
            Assert.AreEqual(3, cupboard1.cupboardComponentsList.Count);

            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker3);
            Assert.AreEqual(0, cupboard1.cupboardComponentsList.Count);
        }

        [TestMethod]
        public void addAngleBracketTest()
        {
            Assert.AreEqual(0, cupboard1.cupboardComponentsList.Count);

            cupboard1.addCupboardComponent(angleBracketParam1);
            Assert.AreEqual(1, cupboard1.cupboardComponentsList.Count);

            cupboard1.addCupboardComponent(angleBracketParam1);
            cupboard1.addCupboardComponent(angleBracketParam2);
            Assert.AreEqual(1, cupboard1.cupboardComponentsList.Count);
        }

        [TestMethod]
        public void removeAngleBracketTest()
        {
            Assert.AreEqual(0, cupboard1.cupboardComponentsList.Count);

            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker1);
            cupboard1.addCupboardComponent(locker2);
            cupboard1.addCupboardComponent(locker3);
            Assert.AreEqual(5, cupboard1.cupboardComponentsList.Count);

            cupboard1.removeCupboardComponent(locker2);
            Assert.AreEqual(4, cupboard1.cupboardComponentsList.Count);

            cupboard1.removeCupboardComponent(locker1);
            Assert.AreEqual(3, cupboard1.cupboardComponentsList.Count);

            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker1);
            cupboard1.removeCupboardComponent(locker3);
            Assert.AreEqual(0, cupboard1.cupboardComponentsList.Count);
        }
    }
}
