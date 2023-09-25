using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Shape:IShape
    {
        public decimal Length { get; set; }
        public Shape()
        {

        }
        public Shape(decimal length)
        {
            this.Length = length;
        }
        public decimal Perimeter()
        {
            return 4 * Length;
        }
    }
}
