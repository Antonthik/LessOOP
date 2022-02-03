using System;

namespace FigureLibrary
{
    public abstract class Figure
    {
        private int _Color;
        private bool _Visibility;

        public int Color {get;  set;}
        public int Visibility { get; set; }

        public Figure(int Color=1,bool Visibility = false)
        {
            _Color = Color;
            _Visibility = Visibility;
        }

        
    }
}
