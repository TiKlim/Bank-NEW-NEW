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
            SchetInBank recipient;
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
                        Console.WriteLine("Введите номер счёта: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        int s = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
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
                    foreach (SchetInBank b in schet)
                    {
                        Console.WriteLine("Введите номер счёта отправителя: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        int s = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                        if (s == b.Nomchet)
                        {
                            bank = b;
                            bank.Otk();


                            foreach (SchetInBank c in schet)
                            {
                                Console.WriteLine("Введите номер счёта получателя: ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                int v = Convert.ToInt32(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                                if (v == c.Nomchet)
                                {
                                    recipient = c;
                                    bank.Perenos(recipient);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

