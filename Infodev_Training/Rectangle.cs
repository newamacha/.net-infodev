using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Rectangle:Shape,IShape
    {
        public decimal Breadth { get; set; }
        public Rectangle() :base() //base adds body description of parent class 
        {

        }
        public Rectangle(decimal length,decimal breadth) : base(length)
        {
           // this.Length = length; not needed as base is used;
            this.Breadth = breadth;
        }
        public decimal Perimeter()
        {
            decimal result = base.Perimeter(); //got perimeter of square i.e 4l
            result = ((result / 4) * Breadth) * 2;//to get perimeter of rectangle
            return 2*(Length + Breadth);
        }
    }
}
