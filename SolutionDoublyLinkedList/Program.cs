using System;
using System.Collections.Generic;

namespace SolutionDoublyLinkedList
{
    class Program
    {
        private static Dictionary<string, int> RomeSynbols = new Dictionary<string, int>
        {
            ["I"] = 1,
            ["V"] = 5,
            ["X"] = 10,
            ["L"] = 50,
            ["C"] = 100,
            ["D"] = 500,
            ["M"] = 1000
        };

        static void Main(string[] args)
        {

            string Value;

            Console.WriteLine("\nВведите римское число: ");

            Value = Console.ReadLine().ToUpper();

            while (!isRoman(Value) || !isCorrect(Value))
            {
                Console.WriteLine("Одно из чисел не является римским или последовательность чисел неверная! \n Введите число заново: ");
                Value = Console.ReadLine().ToUpper();
            }

            Console.WriteLine($"{Value} = {RomanToInt(Value)}");
            
            Console.WriteLine("Если хотите ввести еще одно число, нажмите Y: ");
            
            if(Console.ReadKey().Key == ConsoleKey.Y) Main(null);

        }


        private static int RomanToInt(string s)
        {
            int res = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (i != s.Length - 1)
                {
                    if (RomeSynbols[s[i].ToString()] < RomeSynbols[s[i + 1].ToString()])
                    {
                        res -= RomeSynbols[s[i].ToString()];
                        continue;
                    }
                }
                res += RomeSynbols[s[i].ToString()];
                
            }

            return res;
        }

        private static bool isRoman(string s)
        {
            string rep = s[0].ToString();
            foreach (char symbol in s)
            {
                foreach (KeyValuePair<string, int> value in RomeSynbols)
                {
                    if (symbol.ToString() == value.Key) return true;
                }
            }
            return false;
        }

        private static bool isCorrect(string s)
        {
            string rep = s[0].ToString();
            int count = 0;
            foreach (char symbol in s)
            {
                if (symbol.ToString() == rep) count++;
                else
                {
                    count = 0;
                    rep = symbol.ToString();
                }
                if (count == 3) return false;
            }
            return true;
        }
    }
}
