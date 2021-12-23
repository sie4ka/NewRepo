using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample2
{
    class Program
    {
        public struct Record
        {
            public int ClientID; // идентификационный номер клиента
            public int Year;     // год
            public int Month;    // номер месяца
            public int Duration; // продолжительность занятий в данном месяце данного года (в часах)
        }

        static void Main(string[] args)
        {
            Record[] Visits = new Record[16];

            // Клиент 1 
            Visits[0].ClientID = 101;
            Visits[0].Year = 2021;
            Visits[0].Month = 4;
            Visits[0].Duration = 29;

            Visits[1].ClientID = 101;
            Visits[1].Year = 2020;
            Visits[1].Month = 2;
            Visits[1].Duration = 6;

            Visits[2].ClientID = 101;
            Visits[2].Year = 2020;
            Visits[2].Month = 5;
            Visits[2].Duration = 17;

            Visits[3].ClientID = 101;
            Visits[3].Year = 2019;
            Visits[3].Month = 8;
            Visits[3].Duration = 26;

            Visits[4].ClientID = 101;
            Visits[4].Year = 2021;
            Visits[4].Month = 9;
            Visits[4].Duration = 9;


            // Клиент 2 
            Visits[5].ClientID = 22;
            Visits[5].Year = 2021;
            Visits[5].Month = 2;
            Visits[5].Duration = 19;

            Visits[6].ClientID = 22;
            Visits[6].Year = 2020;
            Visits[6].Month = 11;
            Visits[6].Duration = 7;

            Visits[7].ClientID = 22;
            Visits[7].Year = 2021;
            Visits[7].Month = 12;
            Visits[7].Duration = 1;

            Visits[8].ClientID = 22;
            Visits[8].Year = 2021;
            Visits[8].Month = 2;
            Visits[8].Duration = 6;

            Visits[9].ClientID = 22;
            Visits[9].Year = 2021;
            Visits[9].Month = 5;
            Visits[9].Duration = 18;

            // Клиент 3
            Visits[10].ClientID = 1000;
            Visits[10].Year = 2020;
            Visits[10].Month = 6;
            Visits[10].Duration = 23;

            Visits[11].ClientID = 1000;
            Visits[11].Year = 2021;
            Visits[11].Month = 3;
            Visits[11].Duration = 12;

            Visits[12].ClientID = 1000;
            Visits[12].Year = 2021;
            Visits[12].Month = 6;
            Visits[12].Duration = 17;

            Visits[13].ClientID = 1000;
            Visits[13].Year = 2020;
            Visits[13].Month = 12;
            Visits[13].Duration = 31;

            Visits[14].ClientID = 1000;
            Visits[14].Year = 2020;
            Visits[14].Month = 10;
            Visits[14].Duration = 3;

            // Клиент 4
            Visits[15].ClientID = 16578;
            Visits[15].Year = 2019;
            Visits[15].Month = 5;
            Visits[15].Duration = 22;


            PrintNumberOfClientsPerMonth(Visits);

        }
        static void PrintNumberOfClientsPerMonth(Record[] visits)
        {

            var lines = visits
                .GroupBy(r => new { Year = r.Year, ClientID = r.ClientID })
                .Select(g => (g.Key, g.GroupBy(r => r.Month).Count()))
                .OrderByDescending(y => y.Key.Year)
                .ThenByDescending(x => x.Key.ClientID);
                if (lines.Count() > 0)
                {
                    Console.WriteLine("Количество посещений фитнес-центра (в месяцах), клиент-год");
                    foreach (var line in lines)
                        Console.WriteLine($" ID Клиента: {line.Key.ClientID}. Год: {line.Key.Year}. Количество месяцев: {line.Item2}.");
                }
                else
                    Console.WriteLine($"Нет данных.");

                Console.ReadKey();
            }
        }
    }
