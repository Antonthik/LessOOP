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
        
        private int _NumberAccounts;
        private decimal _BalansAccounts;
        private typeacc _TypeAccounts;

        public int NumberAccounts { get { return _NumberAccounts; } set { _NumberAccounts = value; } }
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



        public Accounts(int NumberAccounts, decimal BalansAccounts, typeacc TypeAccounts)
        {
            _NumberAccounts = NumberAccounts;
            _BalansAccounts = BalansAccounts;
            _TypeAccounts = TypeAccounts;
        }
    }
}
