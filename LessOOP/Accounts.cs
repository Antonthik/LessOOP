using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessOOP
{
    /// <summary>
    /// Класс счета
    /// </summary>
    /// 
    public enum typeacc
    {
        Расчетный_счет=1,
        Накопительный_счет=2
    }
    class Accounts
    {
        private long _NumberAccounts;//номер счета
        private decimal _BalansAccounts;//баланс счета
        private typeacc _TypeAccounts;//тип счета

       static long numNew;

        public long NumberAccounts
        { 
            get 
            {
                return _NumberAccounts; 
               // return NumNew;
            } 
            set
            { 
                if (_NumberAccounts > 0)
                {
                    _NumberAccounts = value;
                    //_NumberAccounts = NumNew;
                }
                
            }
        }
        public decimal BalansAccounts { get { return _BalansAccounts; } set { _BalansAccounts = value; } }
        public typeacc TypeAccounts
        {
            get
            {
                return  _TypeAccounts;
            }
            set
            {
                _TypeAccounts = value;
            }
        }



        public Accounts(long NumberAccounts, decimal BalansAccounts, typeacc TypeAccounts)
        {
            numNew = Nnum(numNew);//генерим уникальный номер счета
            NumberAccounts = numNew;

            _NumberAccounts = NumberAccounts;
            _BalansAccounts = BalansAccounts;
            _TypeAccounts = TypeAccounts;
            
        }


        /// <summary>
        /// Генератор номера счета
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private static long Nnum(long count) => count +=1;

        /// <summary>
        /// Метод снятия со счета
        /// </summary>
        /// <param name="outsum"></param>
        /// <returns></returns>
        public Boolean OutAcc(decimal outsum) 
        {            
            if (outsum > BalansAccounts)
            {
                return false;
            }
            else
            {
                BalansAccounts = BalansAccounts - outsum;
                return true;
            }           
        }

        /// <summary>
        /// Метод пополнения счета
        /// </summary>
        /// <param name="outsum"></param>
        public void InAcc(decimal insum)
        {
            if (insum > 0)
            {
                BalansAccounts = BalansAccounts + insum;
            }           
        }

        /// <summary>
        /// Списание с счета донора на текущий счет
        /// </summary>
        /// <param name="donor"></param>
        /// <param name="sum"></param>
        public bool FromAccToAcc(Accounts donor,decimal sum) 
        {
            if (donor.BalansAccounts >= sum ) 
            {
                BalansAccounts = BalansAccounts + sum;
                donor.BalansAccounts = donor.BalansAccounts - sum;
                return true;
            }
            else
            {
                return false;
            }
                
        }

        public static bool operator ==(Accounts left, Accounts right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Accounts left, Accounts right)
        {
            return !(left == right);
        }
        /// <summary>
        /// Переопределили метод Equals
        /// override - переопределяет Equals в базовом классе
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;            

            var other_acc = (Accounts)obj;

            if (other_acc.TypeAccounts!=TypeAccounts) return false;

            return other_acc.NumberAccounts == NumberAccounts;
        } 

        /// <summary>
        /// Переопределяем метод генерации хэш-кода объекта
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() 
        {
            return HashCode.Combine(NumberAccounts, BalansAccounts,TypeAccounts);
        }

        public override string ToString()
        {
            //return base.ToString();
            return ($"Номер счета:{NumberAccounts} Баланс счета:{BalansAccounts} Тип счета:{TypeAccounts}");
        }
    }
}
