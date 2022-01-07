using System;
using System.Text;

namespace Donut
{
    class Program
    {
        static void Main(string[] args)
        {
            var recievedBytes = new byte[256];

            for (int i = 0; i < recievedBytes.Length; i++)
            {
                recievedBytes[i] = (byte)i;
            }

            var str = Encoding.GetEncoding(866).GetString(recievedBytes);

            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[i] + " ");
                if (i % 16 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
