using System;
using BildingsLibrary;
using System.Collections;

namespace BildCreatorLibrary
{

    //Фабрика объектов
    public class Creator
    {
        //Вариант с указанием высоты 
        public static Bildings CreateBild(double Highest)
        {
            if (Highest < 4) throw new Exception("Для двухэтажного здания не может быть высота менее 4 метров") ;
            return new Bildings(Highest, 2, 6, 3);
        }

        //Вариант по умолчанию
        public static Bildings CreateBild()
        {

            return new Bildings(10, 2, 6, 3);
        }
    }
}
