using System;
using System.IO;
using System.Collections.Generic;
using BildingsLibrary;
using BildCreatorLibrary;
using System.Collections;

namespace LessOOP
{
    class Program
    {
        static void Main(string[] args)
        {


            // Demo1();//Работа с объектом счет
            // Demo2();//Работа с инверцией текста
            // Demo3();//Чтение файла и применение переменные по ссылке
            Demo4();//Чтение файла и применение переменные по ссылке
        }

        static void Demo1()
        {
            Accounts[] Arr = new Accounts[4];//массив счетов
            //Создаем четыре счета
            Arr[0] = new Accounts(1, 100, (typeacc)1);
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
            long num = Convert.ToInt64(intextNum);

            if (FindeAcc(num, Arr, out acc) == true)
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
                if (FindeAcc(numdonor, Arr, out accdonor) == true)
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
        static bool FindeAcc(long num, Accounts[] arr, out Accounts acc)
        {
            bool flag = false;
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

        

        /// <summary>
        /// Применение метода Bildings
        /// </summary>
        static void Demo4()
        {
            //Создаем объект из класса
            var bild1 = new Bildings(10, 2, 6, 3);

            var d = bild1.HighestFloor();
            var f = bild1.CountApartmentsOnFloor();
            var g = bild1.CountApartmentsInEntrances();

            //Создаем объект из фабрики
            var bild2 = Creator.CreateBild(4);//вариант с указанием высоты
            //Создаем объект из фабрики
            var bild3 = Creator.CreateBild(4);//вариант по умолчанию
        }
        static void Demo2()
        {
            Console.WriteLine($"Введите текст, который надо написать наоборот");
            string str = Console.ReadLine();
            string strNew = TextInvert(str);
            Console.WriteLine($"Было {str}");
            Console.WriteLine($"Стало {strNew}");
        }
        /// <summary>
        /// Текст в обратном направлении
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string TextInvert(string str)
        {
            //string str = "olleH";
            string strNew = "";
            char[] chr = new char[str.Length];//создаем массив символов
            int j = 0;
            for (int i = str.Length - 1; i >= 0; i--)//Используем обратное чтение массива
            {
                chr[j] = str[i];//заполняем массив символов
                                // Console.WriteLine($"{str[i]}");
                j++;
            }

            strNew = new string(chr);//собираем массив символов в строку
            return strNew;
        }

        //Работа с файлом и текстовыми строками
        static void Demo3()
        {
            string NameFile = "FIOEMAIL.txt";
            string SourceFilePuth = NameFile;
            GetFIOMAIL(SourceFilePuth, out var fio,out var email);

            for (int i = 0; i < fio.Length; i++)
            {
                Console.WriteLine($"ФИО: {fio[i]} Почта: {email[i]}");
            }
        }

        static void GetFIOMAIL(string SourceFilePuth, out string[] Fio, out string[] Email)
        {
            if (!File.Exists(SourceFilePuth)) throw new FileNotFoundException("", SourceFilePuth);

            var list_fio = new List<string>();
            var list_email = new List<string>();
            using (var file = File.OpenText(SourceFilePuth))
                while (!file.EndOfStream) 
                {
                    var line = file.ReadLine();
                    if (line.Length == 0) continue;

                    SearchMail(ref line, out var fio);

                   // var arr = line.Split("&");
                    list_fio.Add(line);
                    list_email.Add(fio);
                }

            Fio = list_fio.ToArray();
            Email = list_email.ToArray();
        }
        /// <summary>
        /// Извлекаем почту и фио из строки
        /// используем переменную по ссылке
        /// </summary>
        /// <param name="s"></param>
        /// <param name="fio"></param>
        static void SearchMail(ref string s, out string fio)
        {
            var arr = s.Split("&");
            s= (arr[0]);
           fio=(arr[1]);
        }
            
    }
}
