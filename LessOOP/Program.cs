﻿using System;

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

            //Accounts acc = Arr[0];//текущий счет
            Accounts acc;//текущий счет

            Console.WriteLine($"Доступные счета");
            foreach (Accounts accoun in Arr) 
            {
                Console.WriteLine($"Номер счета:{accoun.NumberAccounts}  На балансе сумма: {accoun.BalansAccounts} Тип счета:{accoun.TypeAccounts}");
            }

            Console.WriteLine($"Введите номер счета");
            var intextNum = Console.ReadLine();
            long  num = Convert.ToInt64(intextNum);
            //boolean flag = false;
           
            ////ищем выбранный счет
            //foreach (accounts accnt in arr)
            //{
            //    if (num == accnt.numberaccounts) 
            //    {
            //        acc = accnt;
            //        flag = true;
            //    }  
            //    if (flag == true) break;
            //}
            
            //if (flag == true)
            if (FindeAcc(num,Arr,out acc)==true)
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

                // Списание со счета на счет
                Console.WriteLine($"Введите номер счета для списания:");
                var intextNum0 = Console.ReadLine();
                long numdonor = Convert.ToInt64(intextNum0);
                Accounts accdonor = Arr[0];//счет донор
                if (FindeAcc(numdonor, Arr,out accdonor) == true)
                {
                    Console.WriteLine($"Введите сумму для снятия:");
                    intext = Console.ReadLine();
                    if (intext == "") intext = "0";
                    decimal sumd = Convert.ToDecimal(intext);
                    Console.WriteLine($"На балансе счета донора: {accdonor.BalansAccounts}");

                   if (acc.FromAccToAcc(accdonor, sumd) == true)
                    {
                        Console.WriteLine($"На балансе счета донора (после): {accdonor.BalansAccounts}");
                        Console.WriteLine($"На балансе текущуго счета(после): {acc.BalansAccounts}");
                    }
                    else 
                    {
                        Console.WriteLine($"Недостаточно средств для перевода со счета");
                    }
                }



            }
            else 
            {
                Console.WriteLine($"Счет не найден.");
            }  
        }

        static bool FindeAcc(long num,Accounts[] arr,out Accounts acc) 
        {
            bool flag=false;
            acc = arr[0];//текущий счет
            //Ищем выбранный счет
            foreach (Accounts accnt in arr)
            {
                if (num == accnt.NumberAccounts)
                {
                    acc = accnt;
                    flag = true;
                }
                if (flag == true) break;
            }

            return flag;

        }
    }
}
