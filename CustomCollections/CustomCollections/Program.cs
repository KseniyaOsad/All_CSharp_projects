using System;

namespace CustomCollections
{
    class Program
    {
        static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static public void ShowListInfo<T>(GenericCollection<T> list)
        {
            Console.WriteLine($"Count: {list.Count}");
            Console.Write("[");
            foreach (var item in list)
            {
                Console.Write(item + ",");
            }
            Console.Write("]\n\n");
        }
        
        static public void ShowListInfo(IntegerCollection list)
        {
            Console.WriteLine($"Count: {list.Count}");
            Console.Write("[");
            foreach (var item in list)
            {
                Console.Write(item + ",");
            }
            Console.Write("]\n\n");
        }

        static void ShowUsageOfIntegerCollection() {
            #region [ Test Add method. ]
            // Test Add method.
            Random rnd = new Random();
            IntegerCollection list = new IntegerCollection();
            PrintMessage("Test Add method. Values are random. \n");

            for (int i = 1; i <= 14; i++)
            {
                list.Add(i * rnd.Next(-10, 10));
            }
            ShowListInfo(list);
            #endregion

            #region [ Test Remove method. ]
            // Test Remove method.
            PrintMessage("Test Remove method. Values are almost random. \n");

            Console.WriteLine("Try to delete first element");
            list.RemoveByIndex(0);
            ShowListInfo(list);
            Console.WriteLine("Try to delete last element");
            list.RemoveByIndex(list.Count - 1);
            ShowListInfo(list);
            Console.WriteLine("Try to delete 2 element");
            list.RemoveByIndex(1);
            ShowListInfo(list);
            Console.WriteLine("Try to delete non exist element");
            try
            {
                list.RemoveByIndex(100);
            }
            catch (Exception e)
            {
                PrintMessage(e.Message, ConsoleColor.Red);
            }
            ShowListInfo(list);
            #endregion

            #region [ Test RemoveAndReturnValue method. ]
            // Test RemoveAndReturnValue method.
            PrintMessage("Test RemoveAndReturnValue method. Indexes are random. \n");

            for (int i = 0; i <= 8; i++)
            {
                try
                {
                    Console.WriteLine("Deleted value is " + list.RemoveByIndexAndReturnValue(rnd.Next(-2, 12)));
                }
                catch (Exception e)
                {
                    PrintMessage(e.Message, ConsoleColor.Red);
                }
            }

            PrintMessage("\nResult:", ConsoleColor.Yellow);
            ShowListInfo(list);
            #endregion

            #region [ Test RemoveFirstByValue method. ]
            // Test RemoveFirstByValue method.
            PrintMessage("Test RemoveFirstByValue method. \n");

            Console.WriteLine("Add 10 twice and remove first 10.");
            list.Add(10);
            list.Add(10);
            ShowListInfo(list);
            Console.WriteLine("Index of deleted value is " + list.RemoveFirstByValue(10));
            ShowListInfo(list);

            Console.WriteLine("Try to delete non exist element");
            try
            {
                Console.WriteLine("Index of deleted value is " + list.RemoveFirstByValue(100000));
            }
            catch (Exception e)
            {
                PrintMessage(e.Message, ConsoleColor.Red);
            }
            #endregion

            #region [ Test RemoveAllByValue method. ]
            // Test RemoveAllByValue method.
            PrintMessage("\nTest RemoveAllByValue method. List is new \n");

            Console.WriteLine("New List info:");
            IntegerCollection list2 = new IntegerCollection() { 10, 23, 12, 10, 12, 90, 10 };
            ShowListInfo(list2);
            Console.Write("Try to delete 10. Indexes of deleted values: ");
            list2.RemoveAllByValue(10).ForEach(i => Console.Write("{0},", i));
            PrintMessage("\nResult", ConsoleColor.Yellow);
            ShowListInfo(list2);
            Console.Write("Try to delete 12. Indexes of deleted values: ");
            list2.RemoveAllByValue(12).ForEach(i => Console.Write("{0},", i));
            PrintMessage("\nResult", ConsoleColor.Yellow);
            ShowListInfo(list2);
            Console.WriteLine("Try to delete 100.");
            try
            {
                list2.RemoveAllByValue(100).ForEach(i => Console.Write("{0},", i));
            }
            catch (Exception e)
            {
                PrintMessage(e.Message, ConsoleColor.Red);
            }
            #endregion

            #region [ Test RemoveAllByValue method. ]
            // Test Clear method.
            PrintMessage("\nTest Clear method. \n");
            Console.WriteLine("Clear list");
            list.Clear();
            ShowListInfo(list);
            Console.WriteLine("Clear list2");
            list2.Clear();
            ShowListInfo(list2);
            #endregion

            #region [ Test get by index and put by index method. ]
            // Test get by index and put by index method.
            PrintMessage("Test get by index and put by index method. \n");
            PrintMessage("List info:", ConsoleColor.Yellow);
            IntegerCollection list3 = new IntegerCollection() { 1, 2, 3, 4, 5 };
            ShowListInfo(list3);

            PrintMessage("Get values by index", ConsoleColor.Yellow);

            Console.WriteLine($"Index = 0, elem = {list3[0]}");
            Console.WriteLine($"Index = 2, elem = {list3[2]}");
            Console.WriteLine($"Last index, elem = {list3[list3.Count - 1]}");
            Console.WriteLine($"Index = 10");
            try
            {
                int text = list3[10];
            }
            catch (Exception e)
            {
                PrintMessage(e.Message, ConsoleColor.Red);
            }
            Console.WriteLine($"Index = -1");
            try
            {
                int text = list3[-1];
            }
            catch (Exception e)
            {
                PrintMessage(e.Message, ConsoleColor.Red);
            }

            PrintMessage("\nPut new values", ConsoleColor.Yellow);
            for (int i = -1; i <= 5; i++)
            {
                try
                {
                    Console.WriteLine($"Index = {i} , Value to put = {i + 10} ");
                    list3[i] = i + 10;
                }
                catch (Exception e)
                {
                    PrintMessage(e.Message, ConsoleColor.Red);
                }
            }
            PrintMessage("\nResult of putting values", ConsoleColor.Yellow);
            ShowListInfo(list3);
            #endregion

        }

        static void ShowUsageOfGenericCollection() {
            #region [ Test Add method. ]
            // Test Add method. Integers
            Random rnd = new Random();
            GenericCollection<int> list = new GenericCollection<int>();
            PrintMessage("Test Add method. Values are random. \n");

            for (int i = 1; i <= 14; i++)
            {
                list.Add(i * rnd.Next(-10, 10));
            }
            ShowListInfo(list);

            // Test Add method. Chars
            GenericCollection<char> CharsList = new GenericCollection<char>();
            PrintMessage("Test Add method. Values are random. \n");
            string randomString = "scndskjfvdiushfiawpdaowfjc;sdjxhnvudy7";
            for (int i = 1; i <= 14; i++)
            {
                CharsList.Add(randomString[rnd.Next(0, randomString.Length - 1)]);
            }
            ShowListInfo(CharsList);
            #endregion

            #region [ Test Remove method. ]
            // Test Remove method. Integers
            PrintMessage("Test Remove method. Values are almost random. \n");

            Console.WriteLine("Try to delete first element");
            list.RemoveByIndex(0);
            ShowListInfo(list);
            Console.WriteLine("Try to delete last element");
            list.RemoveByIndex(list.Count - 1);
            ShowListInfo(list);
            Console.WriteLine("Try to delete 2 element");
            list.RemoveByIndex(1);
            ShowListInfo(list);
            Console.WriteLine("Try to delete non exist element");
            try
            {
                list.RemoveByIndex(100);
            }
            catch (Exception e)
            {
                PrintMessage(e.Message, ConsoleColor.Red);
            }
            ShowListInfo(list);
            #endregion

            #region [ Test RemoveAndReturnValue method. ]
            // Test RemoveAndReturnValue method.
            PrintMessage("Test RemoveAndReturnValue method. Indexes are random. \n");

            for (int i = 0; i <= 8; i++)
            {
                try
                {
                    Console.WriteLine("Deleted value is " + CharsList.RemoveByIndexAndReturnValue(rnd.Next(-2, 12)));
                }
                catch (Exception e)
                {
                    PrintMessage(e.Message, ConsoleColor.Red);
                }
            }

            PrintMessage("\nResult:", ConsoleColor.Yellow);
            ShowListInfo(CharsList);
            #endregion

            #region [ Test get by index and put by index method. ]
            // Test get by index and put by index method.
            PrintMessage("Test get by index and put by index method. \n");
            PrintMessage("List info:", ConsoleColor.Yellow);
            GenericCollection<string> StringList = new GenericCollection<string>() { "Hello", "I", "am", "Great", "Britain", "!" };

            ShowListInfo(StringList);

            PrintMessage("Get values by index", ConsoleColor.Yellow);

            Console.WriteLine($"Index = 0, elem = {StringList[0]}");
            Console.WriteLine($"Index = 2, elem = {StringList[2]}");
            Console.WriteLine($"Last index, elem = {StringList[StringList.Count - 1]}");
            Console.WriteLine($"Index = 10");
            try
            {
                string text = StringList[10];
            }
            catch (Exception e)
            {
                PrintMessage(e.Message, ConsoleColor.Red);
            }
            Console.WriteLine($"Index = -1");
            try
            {
                string text = StringList[-1];
            }
            catch (Exception e)
            {
                PrintMessage(e.Message, ConsoleColor.Red);
            }

            PrintMessage("\nPut new values", ConsoleColor.Yellow);
            string[] newStrings = new string[] { "Hi", "My", "name", "is", "Georgia", "Priston" };
            for (int i = -1; i <= 5; i++)
            {
                try
                {
                    Console.WriteLine($"Index = {i} , Value to put = {newStrings[i]} ");
                    StringList[i] = newStrings[i];
                }
                catch (Exception e)
                {
                    PrintMessage(e.Message, ConsoleColor.Red);
                }
            }
            PrintMessage("\nResult of putting values", ConsoleColor.Yellow);
            ShowListInfo(StringList);
            #endregion
        }

        static void Main(string[] args)
        {
            PrintMessage("\nInteger Collection. \n\n", ConsoleColor.Blue);
            ShowUsageOfIntegerCollection();
            PrintMessage("\nGeneric Collection. \n\n", ConsoleColor.Blue);
            ShowUsageOfGenericCollection();
        }
    }
}
