using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class Point:Figure
    {
        private double _X;
        private double _Y;

        public double X { get; set; }
        public double Y { get; set; }

        public Point(double X, double Y)
        {
            _X = X;
            _Y = Y;
        }

        /// <summary>
        /// Новое положение базовой точки по горизонтали
        /// </summary>
        /// <param name="newX"></param>
        public void MoveHorisontal(double newX)
        {
            X = newX;
            Draw();
        }
        /// <summary>
        /// 
        /// Новое положение  базовой точки по вертикали
        /// </summary>
        /// <param name="newY"></param>
        public void MoveVertical(double newY)
        {
            Y = newY;
            Draw();
        }

        /// <summary>
        /// Отрисовка 
        /// </summary>
        public void Draw()
        {

        }

    }
}
