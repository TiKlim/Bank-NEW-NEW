using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class SchetInBank
    {
        private int nomchet; //Номер счёта
        private string? fio; //ФИО владельца счёта
        private float sum; //Сумма на счету
        private float perenos;
        private int nom;
        public int Nomchet { get { return nomchet; } }
        public float Sum { get { return sum; } set { sum = value; } }
        public SchetInBank() { Info(); Out(); }

        public void Info()
        {
            Console.WriteLine("Здравствуйте. Пожалуйста введите информацию по текущему счёту. \n(Номер счёта, Фамилия, Сумма на текщем счёте):");
            Console.WriteLine("Номер счёта: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            nomchet = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ваша фамилия: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            fio = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Сумма на текущем счёте: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sum = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            if (nomchet < 0) //Проверка ввода номера счёта
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Read();
            }
            if (sum < 0) //Проверка ввода суммы 
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Read();
            }
            Otk();
        }
        public void Out()
        {
            Console.WriteLine("> Меню операций Вашего счёта: 1 - Добавить деньги на счёт; 2 - Снять деньги со счёта; 3 - Закрыть счёт; 4 - Меню счетов.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? vybor = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            switch (vybor)
            {
                case "1":
                    Dob();
                    break;
                case "2":
                    Umen();
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> Счёт закрыт.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "4":
                    Console.WriteLine();
                    break;
            }
        }
        public void Otk()
        {
            Console.WriteLine("x-----------------------------");
            Console.WriteLine($"|Информация по текущему счёту: \n|Номер счёта: {nomchet}; \n|Фамилия: {fio}; \n|Сумма на счету: {sum}.");
            Console.WriteLine("x-----------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("> Счёт открыт.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void Dob() //Положить на счёт
        {
            Console.WriteLine("> Сколько Вы хотите положить на счёт?");
            Console.ForegroundColor = ConsoleColor.Cyan;
            float dob = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            if (dob < 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Read();
            }
            sum += dob;
            Otk();
            Out();
        }
        private void Umen() //Снять со счёта
        {
            Console.WriteLine("> Сколько Вы хотите снять со счёта?");
            Console.ForegroundColor = ConsoleColor.Cyan;
            float umen = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            if (umen < 0) //Проверки далее
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Read();
            }
            if (umen < sum)
            {
                sum -= umen;
            }
            else if (umen > sum)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Otk();
            }
            else if (umen == sum)
            {
                Obnul();
            }
            Otk();
            Out();
        }
        private void Obnul() //Взять всю сумму
        {
            sum = 0;
            Otk();
            Out();
        }
        public void Perenos(SchetInBank recipient) // Совершаем перевод денег между двумя счетами
        {
            Console.WriteLine($"\nВведите сумму, которую желаете перевести на другой счет: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            float perenos = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            if (perenos <= sum) //Деньги для перевода
                {
                    sum -= perenos; //Отнимаем от общего
                    recipient.sum += perenos;
                    Console.WriteLine($"На счет: {recipient.nomchet} было переведено: {perenos} рублей");
                    Out();
                }
                else
                {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Недостаточно средств на счёте.");
                Console.BackgroundColor = ConsoleColor.Black;
                Perenos(recipient);
                }
            
            }
        }
    }

