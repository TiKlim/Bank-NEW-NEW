using Bank;
using System;
using System.Runtime.CompilerServices;

namespace Bank
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
                Console.WriteLine("> Меню счетов: 1 - Создать счёт; 2 - Открыть счёт.");
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
                            Console.WriteLine("Вы всегда можете переводить деньги на иные счета! Хотите осуществить такую операцию? (Да, Нет) ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            string? f = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            if (f == "Да")
                            {
                                foreach (SchetInBank c in schet)
                                {
                                    Console.WriteLine("Введите номер счёта отправителя: ");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    int g = Convert.ToInt32(Console.ReadLine());
                                    Console.ForegroundColor = ConsoleColor.White;
                                    if (g == c.Nomchet)
                                    {
                                        bank = c;
                                        bank.Otk();


                                        foreach (SchetInBank d in schet)
                                        {
                                            Console.WriteLine("Введите номер счёта получателя: ");
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            int v = Convert.ToInt32(Console.ReadLine());
                                            Console.ForegroundColor = ConsoleColor.White;
                                            if (v == d.Nomchet)
                                            {
                                                recipient = d;
                                                bank.Perenos(recipient);
                                            }

                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                            if (f == "Нет")
                            {
                                bank.Otk();
                                bank.Out();
                            }
                        }
                    }
                }
            }
        }
    }
}

