using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class AdventOfCode6
    {

        private static Dictionary<char, int>[] _a;

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(
                @"C:\Users\kyon\Documents\GitGood\AdventOfCode2016\AdventOfCode\items.txt");

            _a = new Dictionary<char, int>[lines[0].Length];
            for (int i = 0; i < lines[0].Length; i++)
            {
                _a[i] = new Dictionary<char, int>();
            }

            foreach (string line in lines)
            {
                ProcessItems(line);
            }

            foreach (Dictionary<char, int> dictionary in _a)
            {
                var myList = dictionary.ToList();
                // Lowest first +1 | highest first -1
                myList.Sort((pair1, pair2) => -1 * pair1.Value.CompareTo(pair2.Value));
                Console.Write(myList[0].Key);
            }
            Console.ReadLine();

        }

        private static void ProcessItems(object obj)
        {
            var str = obj as string;
            if (str == null)
            {
                throw new Exception();
            }

            for (var c = 0; c < str.Length; c++)
            {
                if (_a[c].ContainsKey(str[c]))
                {
                    _a[c][str[c]]++;
                }
                else
                {
                    _a[c].Add(str[c], 1);
                }
            }
        }
    }
}
