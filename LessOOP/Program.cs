using System;

namespace LessOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounts acc = new Accounts(1, 100, (typeacc) 1);

            var t = acc.TypeAccounts;
        }
    }
}
