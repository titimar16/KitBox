﻿using projectCS.Tools_class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectCS
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CatalogueDB catalogueDB = new CatalogueDB();
            Door cleat1;
            cleat1 = (Door)catalogueDB.createComponents(32, 62, 0, ComponentColor.brown, "Door");
            
            Console.WriteLine(cleat1);
            Console.WriteLine("\n");
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            */
        }        
    }
}
