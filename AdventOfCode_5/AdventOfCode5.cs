using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode_5
{
    class AdventOfCode5
    {
        static void Main(string[] args)
        {
            var count = 0;
            string hash;
            var doorId = "cxdnnyjw";
            var key = new char[8];
            var fin = 0;

            while (fin != 8)
            {
                hash = "Kappapa";
                while (hash.Substring(0, 5) != "00000")
                {
                    hash = CalculateMd5Hash(doorId + count);
                    count++;
                }

                try
                {
                    int a = (int)char.GetNumericValue(hash[5]);
                    if (a <= 7 && key[a] == '\0')
                    {
                        fin++;
                        key[a] += hash[6];
                        Console.WriteLine("found key " + fin + " for pos " + a + " at " + count);
                    }
                    else
                    {
                        Console.WriteLine("key ~ at " + count);
                    }
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("key ~ at " + count);
                }

            }
            
            Console.WriteLine(new string(key) + " | " + count);
            Console.ReadLine();
        }

        private static string CalculateMd5Hash(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);
            return ByteArrayToString(hash);
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

    }
}
