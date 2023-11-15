using Bank;
using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
         
            List<SchetInBank> schet = new List<SchetInBank>();
            SchetInBank bank;
            SchetInBank nach; //Текущий счёт (для перевода)
            SchetInBank recipient; //Получатель (для перевода)
            while (true)
            {
                Console.WriteLine("> Меню счетов: 1 - Создать счёт; 2 - Открыть счёт; 3 - Осуществить перевод средств между существующими счетами.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                int scheta = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                    if (scheta == 1)
                    {
                    schet.Add(new SchetInBank());
                    }
                    else if (scheta == 2)
                    {
                        foreach (SchetInBank b in schet)
                        {
                            Console.WriteLine("Введите номер счёта");
                            int s = Convert.ToInt32(Console.ReadLine());
                            if (s == b.Nomchet)
                            {
                                bank = b;
                            bank.Otk();
                            bank.Out();                               
                            }
                        }
                    
                    }
                else if (scheta == 3)
                {
                    Console.WriteLine("Введите номер счёта получателя.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int schets = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nВведите сумму которую желаете перевести на другой счет?");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    bank.Perenos(Convert.ToSingle(Console.ReadLine()));
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
        }
    }
}

