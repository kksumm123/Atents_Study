using System;

namespace ToggleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ToggleA = false;
            while (true)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'a':
                        ToggleA = !ToggleA;
                        if (ToggleA)
                        {
                            Console.WriteLine("A 활성화");
                        }
                        else
                        {
                            Console.WriteLine("A 비활성화");
                        }
                        break;
                }
            }
        }
    }
}
