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
                        Console.WriteLine("> Введите номер счёта: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        int s = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                        if (s == b.Nomchet)
                        {
                            bank = b;
                            bank.Otk();
                            Console.WriteLine("> Меню операций Вашего счёта: 1 - Добавить деньги на счёт; 2 - Снять деньги со счёта; 3 - Закрыть счёт; 4 - Перевод средств; 5 - Меню счетов.");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            string? vybor = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                                switch (vybor)
                                {
                                    case "1":
                                        bank.Out(vybor);
                                        break;
                                    case "2":
                                        bank.Out(vybor);
                                        break;
                                    case "3":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("> Счёт закрыт.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        break;
                                    case "4":
                                                foreach (SchetInBank d in schet)
                                                {
                                                    Console.WriteLine("> Введите номер счёта получателя: ");
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
                                      
                                    case "5":
                                        Console.WriteLine();
                                        break;
                                }
                        }
                        
                    }
                }
            }
        }
    }
}



