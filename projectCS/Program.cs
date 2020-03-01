﻿using projectCS.physic_components;
using System;
using System.Collections.Generic;

namespace projectCS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            printPerso.newCompoTest();
            printPerso.test2();
            printPerso.test3();
            printPerso.isActive();
            */
            printPerso.autreTest();

            Console.WriteLine("\n");
        }

        internal static class printPerso
        {
            public static void newCompoTest()
            {
                CrossBar t = new CrossBar(1000, "referenceTest", "codeTest", 0, false, 0, "orientationTest");
                Console.WriteLine(t.price);
            }

            public static void test2()
            {
                Locker t = new Locker();

                CrossBar t1 = new CrossBar(10, "referenceTest", "1", 0, false, 0, "orientationTest");
                CrossBar t2 = new CrossBar(100, "referenceTest", "2", 0, false, 0, "orientationTest");
                CrossBar t3 = new CrossBar(1000, "referenceTest", "3", 0, false, 0, "orientationTest");
                CrossBar t4 = new CrossBar(1000, "referenceTest", "4", 0, false, 0, "orientationTest");
                CrossBar t5 = new CrossBar(1000, "referenceTest", "5", 0, false, 0, "orientationTest");

                t.addComponent(t1);
                t.addComponent(t2);
                t.addComponent(t3);
                t.addComponent(t4);
                t.addComponent(t5);

                foreach (Components c in t.componentsList)
                {
                    Console.WriteLine(c.code);
                }

                Console.WriteLine("\n");
                t.removeComponent(t2);
                t.removeComponent(t4);

                foreach (Components c in t.componentsList)
                {
                    Console.WriteLine(c.code);
                }
            }

            public static void test3()
            {
                Locker l2 = new Locker();

                CrossBar t1 = new CrossBar(10, "referenceTest", "1", 0, false, 0, "orientationTest");
                Cleat nul = new Cleat();


                l2.addComponent(t1);
                l2.addComponent(nul);

                foreach (Components c in l2.componentsList)
                {
                    Console.WriteLine(c.code);
                }

            }

            public static void isActive()
            {
                Locker locker = new Locker();

                CrossBar c1 = new CrossBar();
                CrossBar c2 = new CrossBar();
                CrossBar c3 = new CrossBar();
                CrossBar c4 = new CrossBar();
                CrossBar c5 = new CrossBar();
                CrossBar c6 = new CrossBar();
                CrossBar c7 = new CrossBar();
                CrossBar c8 = new CrossBar();
                Pannel p1 = new Pannel();
                Pannel p2 = new Pannel();
                Pannel p3 = new Pannel();
                Pannel p4 = new Pannel();
                Pannel p5 = new Pannel();
                Cleat cl1 = new Cleat();
                Cleat cl2 = new Cleat();
                Cleat cl3 = new Cleat();
                Cleat cl4 = new Cleat();




                locker.addComponent(new List<LockerComponents>() { c1, c2, c3, c3, c4, c5, c6 ,c7, c8,
                                                                cl1, cl2, cl3, cl4,
                                                                p1, p2, p3, p4, p5});

                foreach (LockerComponents lc in locker.componentsList)
                {
                    Console.WriteLine(lc);
                }
                locker.isComplete();
            }

            public static void autreTest()
            {
                OrderForm o = new OrderForm();

                Console.WriteLine(o.OrderID);
            }
        }
    }    
}
