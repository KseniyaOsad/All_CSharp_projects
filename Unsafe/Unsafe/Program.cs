using System;

namespace Unsafe
{
    class Program
    {
        int x;
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine($"Program.x = {program.x}");
            unsafe
            {
                fixed (int* test = &program.x)
                {
                    *test = 9;
                }
                Console.WriteLine($"Program.x = {program.x}");
            }
            Console.WriteLine("--------");

            int[] numbers = new int[5] { 10, 20, 30, 40, 50 };
            Console.Write("numbers: [");
            foreach (var i in numbers)
                Console.Write($"{i}, ");
            Console.WriteLine("]");
            unsafe
            {
                fixed (int* linkToFirstElement = &numbers[0])
                {
                    int* index = linkToFirstElement;
                    Console.WriteLine($"*index = {*index}");
                    Console.WriteLine($"*index += 1" );
                    index += 1;
                    Console.WriteLine($"*index = {*index}");
                    Console.WriteLine($"*index += 2" );
                    index += 2;
                    Console.WriteLine($"*index = {*index}");
                    Console.WriteLine("--------");
                    Console.WriteLine($"*linkToFirstElement = {*linkToFirstElement}");
                    Console.WriteLine($"*linkToFirstElement += 1");
                    *linkToFirstElement += 1;
                    Console.WriteLine($"*linkToFirstElement = {*linkToFirstElement}");
                    Console.WriteLine($"*linkToFirstElement += 2");
                    *linkToFirstElement += 2;
                    Console.WriteLine($"*linkToFirstElement = {*linkToFirstElement}");
                }
            }
            Console.WriteLine("--------");
            Console.WriteLine($"numbers[0] = {numbers[0]}");
            Console.WriteLine("--------");

            unsafe
            {
                fixed (char* value = "sam")
                {
                    Console.WriteLine($"char* value = 'sam'");
                    Console.WriteLine($"value: {*value}");
                    Console.WriteLine($"char* linkToValue = value");
                    char* linkToValue = value;
                    while (*linkToValue != '\0')
                    {
                        Console.WriteLine($"linkToValue: {*linkToValue}");
                        Console.WriteLine($"++linkToValue");
                        ++linkToValue;
                    }
                }
            }
        }
    }
}
