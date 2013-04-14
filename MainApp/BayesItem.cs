using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainApp
{
    public class Diameter
    {
        public Diameter()
        {
        }

        public Diameter(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        private int _width;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        
                
    }
}
