using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
   public class Rectangle : Point
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double X, double Y, double Width, double Height) : base(X, Y)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }

        /// <summary>
        /// Площадь фигуры
        /// </summary>
        /// <returns></returns>
        public double Square()
        {
            return Width * Height;
        }

        public void Print()
        {
            Console.WriteLine($"Color:{Color} Visibility:{Visibility} X:{X} Y:{Y} Square:{Square()}");
        }

    }
}
