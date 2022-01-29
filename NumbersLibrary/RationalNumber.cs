using System;

namespace NumbersLibrary
{
    //Дробные числа или Рациональные числа
    public class RationalNumber
    {
        private int _Numerator;//числитель
        private int _Denumerator;//знаменатель

        public int Numerator { get { return _Numerator; }private set { _Numerator = value; } }
        public int Denumerator { get { return _Denumerator; } private set { _Denumerator = value; } }


        public RationalNumber (int Numerator,int Denumerator) 
        {
            if (Denumerator == 0) throw new ArgumentException("Знаменатель должен быть больше нуля");

            _Numerator = Numerator;
            _Denumerator = Denumerator;
            ReduceToOptimal();
        }

        public RationalNumber(double Numerator, double Denumerator)
        {
            if (Denumerator == 0) throw new ArgumentException("Знаменатель должен быть больше нуля");

            _Numerator = Convert.ToInt32( Numerator);
            _Denumerator =Convert.ToInt32(Denumerator);
            ReduceToOptimal();
        }

        /// <summary>
        ///Приведение к оптимальному виду
        ///дроби,к наменьшим значениям чмслстеля и знаменателя
        /// </summary>
        private void ReduceToOptimal()
        {
            int nod = NOD(_Numerator, _Denumerator);
            _Numerator = _Numerator/nod;
            _Denumerator = _Denumerator/nod;
        }

        /// <summary>
        /// Поиск набольшего общего делителя для
        /// числителя и знаменателя
        /// </summary>
        private static int NOD(int term1, int term2)
        {
            if (term2 == 0)
                return term1;
            else
                return NOD(term2, term1 % term2);
        }

        public static RationalNumber operator + (RationalNumber rn1,RationalNumber rn2)
        {
            return new RationalNumber(rn1.Numerator*rn2.Denumerator+rn2.Numerator*rn1.Denumerator, rn1.Denumerator*rn2.Denumerator);
        }

        public static RationalNumber operator - (RationalNumber rn1, RationalNumber rn2)
        {
            return new RationalNumber(rn1.Numerator * rn2.Denumerator - rn2.Numerator * rn1.Denumerator, rn1.Denumerator * rn2.Denumerator);
        }

        public static RationalNumber operator *(RationalNumber rn1, RationalNumber rn2)
        {
            return new RationalNumber(rn1.Numerator *rn2.Numerator, rn1.Denumerator * rn2.Denumerator);
        }

        public static RationalNumber operator /(RationalNumber rn1, RationalNumber rn2)
        {
            var n = rn1.Numerator * rn2.Denumerator;
            var d = rn1.Denumerator * rn2.Numerator;
            return new RationalNumber(rn1.Numerator * rn2.Denumerator, rn1.Denumerator * rn2.Numerator);
        }

        public static bool operator == (RationalNumber left, RationalNumber right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RationalNumber left, RationalNumber right)
        {
            return !(left==right);
        }

        public static bool operator >(RationalNumber left, RationalNumber right)
        {
            return delim(left.Numerator, left.Denumerator) > delim(right.Numerator, right.Denumerator);
        }

        public static bool operator <(RationalNumber left, RationalNumber right)
        {            
            return delim(left.Numerator , left.Denumerator) < delim(right.Numerator , right.Denumerator);
        }

        public static bool operator >=(RationalNumber left, RationalNumber right)
        {
            return delim(left.Numerator, left.Denumerator) >= delim(right.Numerator, right.Denumerator);
        }

        public static bool operator <=(RationalNumber left, RationalNumber right)
        {
            return delim(left.Numerator, left.Denumerator) <= delim(right.Numerator, right.Denumerator);
        }
        /// <summary>
        /// Теперь можно создавать объект дробей из строки 
        /// explicit-предполагает явное указание типа перед строкой
        /// implicit - не явное
        /// </summary>
        /// <param name="str"></param>
        public static explicit operator RationalNumber(string str)
        {
            str = str.Trim(' ','(',')');
            var arr = str.Split('/');

            var num_str = arr[0];
            var denum_str = arr[1];

            var num = int.Parse(num_str);
            var denum = int.Parse(denum_str);

            return new RationalNumber(num,denum);
        }

        static double delim(double num,double del )
        {            
            return num / del;
        }

    }
}