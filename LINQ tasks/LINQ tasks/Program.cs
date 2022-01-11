using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // TASK 1: 
            // You will be given an array of numbers. You have to sort the odd numbers in ascending order while leaving the even numbers at their original positions.
            Console.WriteLine("Task 1");

            List<int> task1List = new List<int>(){ 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0};
            Queue<int> sortedOdds = new Queue<int>(task1List.Where(i => i % 2 == 1).OrderBy(i => i));

            List<int> task1Result = new List<int>(); 
            task1List.ForEach(i=> {
                if (i % 2 == 1)
                {
                    i= sortedOdds.Dequeue(); 
                }
                task1Result.Add(i);
            });

            task1Result.ForEach(i=> Console.Write($"{i}, "));

            // TASK 2:
            // Write a function named that takes a string input, and returns the first character that is not repeated anywhere in the string.
            // As an added challenge, upper- and lowercase letters are considered the same character, but the function should return the correct case for the initial letter. For example, the input 'sTreSS' should return 'T'
            
            Console.WriteLine("\n\nTask 2");
            string task2String = "sTtReSS";
            char answer = task2String.Where((s, idx) => !task2String.ToLower().Where((s2, idx2) => idx != idx2).Contains(Char.ToLower(s))).FirstOrDefault();
            Console.WriteLine(answer);

            // TASK 3:
            // You are given two arrays arr1 and arr2, where arr2 always contains integers.
            // Write the function find_array(arr1, arr2) such that:
            // For arr1 = ['a', 'a', 'a', 'a', 'a'], arr2 = [2, 4, 90] find_array returns['a', 'a']
            // For arr1 =["a", "b", "c", "d"], arr2 =[2, 2, 2], find_array returns["c", "c", "c"]
            Console.WriteLine("\nTask 3");
            List<int> task3List = new List<int>() { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            List<int> tryToFind = new List<int>() { 8, 2, 2, 90 };
            
            List<int> task3Result = new List<int>();
            tryToFind.ForEach(index =>
                    {
                        var number = task3List.Where((num, idx) => idx == index).DefaultIfEmpty(-1).First();
                        if (number != -1) task3Result.Add(number);
                    }
                );
            task3Result.ForEach(i => Console.Write($"{i}, "));


            // TASK 4:
            // Take an array and remove every second element from the array. Always keep the first element and start removing with the next element.
            // Example: ["Keep", "Remove", "Keep", "Remove", "Keep", ...] --> ["Keep", "Keep", "Keep", ...]
            Console.WriteLine("\n\nTask 4");
            List<string> task4List = new List<string>() { "Keep", "Remove", "Keep", "Remove", "Keep" };
            List<string> task4Result = task4List.Where((num, idx) => idx % 2 == 0).ToList();
            task4Result.ForEach(i => Console.Write($"{i}, "));


            // TASK 5:
            // Write a function that takes an array and counts the number of each unique element present.
            Console.WriteLine("\n\nTask 5");
            List<string> task5List = new List<string>() { "Keep", "Remove", "Keep", "Remove", "Keep", "Hello" };
            Dictionary<string, int> task5Result = task5List.GroupBy(i=>i).Select(group => new KeyValuePair<string, int>(group.Key, group.Count())).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in task5Result)
            {
                Console.Write($"{item.Key} - {item.Value}, ");
            }

            // TASK 6:
            // The main idea is to count all the occurring characters in a string. If you have a string like aba, then the result should be {'a': 2, 'b': 1}.
            Console.WriteLine("\n\nTask 6");
            string task6String = "stReSS";
            Dictionary<char, int> task6Result = task6String.ToLower().GroupBy(i=>i).Select(group=>new KeyValuePair<char, int> (group.Key, group.Count())).ToDictionary(x=>x.Key, x=>x.Value);
            foreach (var item in task6Result)
            {
                Console.Write($"{item.Key} - {item.Value}, ");
            }

            // TASK 7:
            // You'll be given a string, and have to return the sum of all characters as an int. The function should be able to handle all ASCII characters.
            Console.WriteLine("\n\nTask 7");
            string task7String = "stReSS";
            int task7Result = task7String.Select(x=>(int) x).Aggregate((x, agr) => x + agr);
            Console.WriteLine(task7Result);

            // TASK 8:
            // calculate the sum of fibonacci numbers up to a certain limit
            Console.WriteLine("\nTask 8");
            int end = 55;
            List<int> Fibonacci = new List<int>() { 0, 1 };
            int prev = 0;
            int curr = 1;
            while (curr < end)
            {
                int sum = curr + prev;
                Fibonacci.Add(sum);
                prev = curr;
                curr = sum;
            }
            int task8Result = Fibonacci.Aggregate((x, agr) => x + agr);
            Fibonacci.ForEach(i => Console.Write($"{i}, "));
            Console.WriteLine("\n"+task8Result);
        }
    }
}
