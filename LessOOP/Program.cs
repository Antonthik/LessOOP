using System;

namespace LessOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounts acc = new Accounts(1, 100, (typeacc) 1);
            Accounts acc1 = new Accounts(1, 50, (typeacc)2);
            Accounts acc2 = new Accounts(1, 400, (typeacc)1);
            Accounts acc3 = new Accounts(1, 70, (typeacc)1);

            var t = acc.TypeAccounts;
            
            //var s=acc.
        }
    }
}
