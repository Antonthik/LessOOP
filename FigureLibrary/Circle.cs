using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class Circle : Point
    {
        public double Radius { get; set; }
        public Circle(double X, double Y,double Radius) : base(X, Y)
        {
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
        }

        /// <summary>
        /// Площадь фигуры
        /// </summary>
        /// <returns></returns>
        public double Square()
        {
            return Radius* Radius*3.14;
        }

        /// <summary>
        /// Вывод на консоль всех параметров объекта
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Color:{Color} Visibility:{Visibility} X:{X} Y:{Y} Square:{Square()}");
        }
    }
}
