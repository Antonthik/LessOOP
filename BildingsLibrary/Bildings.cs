using System;

namespace BildingsLibrary
{
    public class Bildings
    {
        private long _NumbBild;//уникальный номер здания
        private double _Highest;//Высота здания
        private long _CountFloors;//Этажность
        private long _CountApartments;//Количество квартир
        private long _ContEntrances;//Количество подъездов
        static long _count;

        public long NumbBild { get { return _NumbBild; } set { _NumbBild = value; } }
        public double Highest { get { return _Highest; } set { _Highest = value; } }
        public long CountFloors { get { return _CountFloors; } set { _CountFloors = value; } }
        public long CountApartments { get { return _CountApartments; } set { _CountApartments = value; } }
        public long ContEntrances { get { return _ContEntrances; } set { _ContEntrances = value; } }


        public Bildings(double Highest, long CountFloors, long CountApartments, long ContEntrances) 
        {
            _count = Nnum(_count);
            _NumbBild = _count;
            _Highest = Highest;
            _CountFloors = CountFloors;
            _CountApartments = CountApartments;
            _ContEntrances = ContEntrances;
        }

       private static long Nnum(long count) => count += 1;

        /// <summary>
        /// Высотность этажа
        /// </summary>
        /// <returns></returns>
       public double HighestFloor(){return Highest/CountFloors;}

        /// <summary>
        /// Количество квартир на этаже
        /// Если ноль - значит заданы не верные параметры
        /// </summary>
        /// <returns></returns>
       public long CountApartmentsOnFloor() 
       {
            double countOnFloor = ((double)CountApartments / (double)ContEntrances )/ (double)CountFloors;

            if ((countOnFloor-(int)countOnFloor)==0)
            {
                return CountApartments / ContEntrances / CountFloors;
            }
            else
            {
                return 0;
            }
            
        }

        /// <summary>
        /// Количество квартир в подъезде
        /// Если ноль - значит заданы не верные параметры дома
        /// <returns></returns>
        public long CountApartmentsInEntrances()
        {
           long countApartmentsOnFloor = CountApartmentsOnFloor();

            return countApartmentsOnFloor * CountFloors;
        }
    }
}
