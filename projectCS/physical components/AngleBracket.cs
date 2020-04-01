﻿using projectCS.Tools_class;
using System;

namespace projectCS
{
    public class AngleBracket : CatalogueComponents, ICupboardComponents
    {
        public override ComponentColor color
        {
            //toto : demander prof pq si je le rajoute pas, il n'appelle pas dynamiquement
            get => _color;
            set
            {
                if (value == ComponentColor.transparent)
                {
                    ErrorWindow window = new ErrorWindow(ErrorMessages.invalidColorMsg, ErrorMessages.invalidColorTitle);
                    window.displayWindow();
                }
                else
                    _color = value;
            }
        }

        public int height
        {
            get => _size.height;
        }

        public AngleBracket() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white)
        {
        }
        public AngleBracket(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension,
                        ComponentColor color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }

        /// <summary>
        ///     resize the angle bracket
        /// </summary>
        /// <param name="size">
        ///     size to cut of the height from angle bracket
        /// </param>
        public void cutHeight(int size)
        {
            _size.height -= size;
        }

        public override string ToString()
        {
            return base.ToString() + ", height : " + height;
        }
    }
}