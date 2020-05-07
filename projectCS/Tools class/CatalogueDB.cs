﻿












using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace projectCS.Tools_class
{
    public class CatalogueDB
    {
        private static string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
        private MySqlConnection conn;

        public CatalogueDB()
        {
            
        }


        public CatalogueComponents createComponents(int height, int width, int depth, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();

            // 0 = code, 1 = in stock, 2 = price
            List<string> infos = DbUtils.BigMoney(conn, typeObj, height.ToString(), depth.ToString(), width.ToString(), "");
            string price = infos[0];
            ComponentSize size = new ComponentSize(height, width, depth);

            return new Cleat(double.Parse(price), typeof(Cleat).ToString().Split('.')[1], "f", size, 5 > 0, 0);
        }

        public CatalogueComponents createComponents(int height, int width, int depth, ComponentColor color, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();

            // 0 = code, 1 = in stock, 2 = price
            List<string> infos = DbUtils.BigMoney(conn, typeObj, height.ToString(), depth.ToString(), width.ToString(), EnumParse.parseColorEnumToStr(color));
            string price = infos[0];
            ComponentSize size = new ComponentSize(height, width, depth);

            return new Door(double.Parse(price), typeof(Door).ToString().Split('.')[1], "f", size, 5 > 0, 0, color);
        }

        public CatalogueComponents createComponents(int height, int width, int depth, ComponentColor color, PanelsType panelsType, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();

            // 0 = code, 1 = in stock, 2 = price
            List<string> infos = DbUtils.BigMoney(conn, typeObj, height.ToString(), depth.ToString(), width.ToString(), EnumParse.parseColorEnumToStr(color));
            string price = infos[2];
            ComponentSize size = new ComponentSize(height, width, depth);

            return new Panels(double.Parse(price), typeof(Panels).ToString().Split('.')[1], "f", size, 5 > 0, 0, color, panelsType);
        }

        public CatalogueComponents createComponents(int height, int width, int depth, CrossBarType crossType, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();

            // 0 = code, 1 = in stock, 2 = price
            List<string> infos = DbUtils.BigMoney(conn, typeObj+" "+EnumParse.parseTypeEnumToStr(crossType), height.ToString(), depth.ToString(), width.ToString(), "");
            string price = infos[2];
            ComponentSize size = new ComponentSize(height, width, depth);

            return new CrossBar(double.Parse(price), typeof(CrossBar).ToString().Split('.')[1], "f", size, 5 > 0, 0, crossType);
        }

    }
}
