using System;

namespace LessOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Accounts[] Arr = new Accounts[4];//массив счетов
           

            //Создаем четыре счета
            Arr[0] = new Accounts(1, 100, (typeacc) 1);
            Arr[1] = new Accounts(1, 50, (typeacc)2);
            Arr[2] = new Accounts(1, 400, (typeacc)1);
            Arr[3] = new Accounts(1, 70, (typeacc)1);

            Accounts acc = Arr[0];//текущий счет

            Console.WriteLine($"Доступные счета");
            foreach (Accounts accoun in Arr) 
            {
                Console.WriteLine($"Номер счета:{accoun.NumberAccounts}  На балансе сумма: {accoun.BalansAccounts} Тип счета:{accoun.TypeAccounts}");
            }

            Console.WriteLine($"Введите номер счета");
            var intextNum = Console.ReadLine();
            long  num = Convert.ToInt64(intextNum);
            Boolean flag = false;
           
            //Ищем выбранный счет
            foreach (Accounts accnt in Arr)
            {
                if (num == accnt.NumberAccounts) 
                {
                    acc = accnt;
                    flag = true;
                }  
                if (flag == true) break;
            }

            if (flag == true)
            {
               
                //Пополнение текущего счета
                Console.WriteLine($"На балансе сумма: {acc.BalansAccounts}");
                Console.WriteLine($"Введите сумму для пополнения:");
                var intext = Console.ReadLine();
                if (intext == "") intext = "0";
                decimal sum1 = Convert.ToDecimal(intext);
                acc.InAcc(sum1);
                Console.WriteLine($"Вы внесли сумму {sum1} и остаток на балансе { acc.BalansAccounts}");

                //Списывем с текущего счета сумму 10, на счете 100
                Console.WriteLine($"На балансе сумма: {acc.BalansAccounts}");
                Console.WriteLine($"Введите сумму для снятия:");
                intext = Console.ReadLine();
                if (intext == "") intext = "0";
                decimal sum2 = Convert.ToDecimal(intext);

                if (acc.OutAcc(sum2) == false)
                {
                    Console.WriteLine($"Данную сумму Вы не можете снять");
                }
                else
                {
                    Console.WriteLine($"Вы сняли сумму {sum2} и остаток на балансе { acc.BalansAccounts}");
                }

            }
            else 
            {
                Console.WriteLine($"Счет не найден.");
            }

            

  
        }
    }
}
