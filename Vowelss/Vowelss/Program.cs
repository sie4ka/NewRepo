using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace vowels
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полное имя файла");
            var fileName = Console.ReadLine();
            string[] text;

            Console.WriteLine();

            if (File.Exists(fileName))
                text = File.ReadAllLines(fileName);
            else
            {
                Console.WriteLine("Такого файла не существует");
                Console.ReadKey();
                return;
            }


            Console.WriteLine(CountWordsByVowel(text));

            Console.ReadKey();

        }

        static int CountWordsByVowel(string[] lines)
        {
            string[] vowels = { "а", "е", "ё", "и", "о", "у", "э", "ю", "я", "ы" };
            return lines
                .SelectMany(line => line.Split(' ', '.', ',', ';', ':', '!', '?', '*', '—', '"', '«', '»'))
                .Where(w => w.Length > 0 && char.IsLetter(w[0])
                && vowels.Any(v => w.EndsWith(v, StringComparison.OrdinalIgnoreCase)))
                .Select(w => w.ToLower())
                .Distinct()
                .ToList()
                .Count();
        }
    }
}