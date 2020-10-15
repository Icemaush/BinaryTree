using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            FillTree(ref bt);
            bt.Display();
            Console.WriteLine();

            int input = DisplayMenu();
            Console.WriteLine();

            do
            {
                switch (input)
                {
                    case 1: 
                        bt.Add(NewItem());
                        break;
                    case 2:
                        bt.Delete(DeleteItem());
                        break;
                    case 3:
                        bt.Find(FindItem());
                        break;
                    default:
                        break;
                }

                if (input != 4)
                {
                    bt.Display();
                    Console.WriteLine();
                    input = DisplayMenu();
                    Console.WriteLine();
                }
            } while (input != 4);
        }

        // Populate binary tree
        private static void FillTree(ref BinaryTree bt)
        {
            string[] names = new string[]
            {
                "Anna",
                "Emily",
                "Melanie",
                "Sarah",
                "Zoe",
                "Chris",
                "Harry",
                "Liam",
                "Robert",
                "William"
            };

            foreach (string name in names) {
                bt.Add(name);
            }
        }

        // Prompt user for name to search for
        private static string FindItem()
        {
            Console.Write("Enter name to search for: ");
            return Console.ReadLine();
        }

        // Prompt user for name to delete
        private static string DeleteItem()
        {
            Console.Write("Enter name to delete: ");
            return Console.ReadLine();
        }

        // Prompt user for name to add
        private static string NewItem()
        {
            Console.Write("Enter name to add: ");
            return Console.ReadLine();
        }

        // Display menu to user
        private static int DisplayMenu()
        {
            int num;
            Console.WriteLine("Please select from the following options:");
            Console.WriteLine("1. Add Name");
            Console.WriteLine("2. Delete Name");
            Console.WriteLine("3. Find Name");
            Console.WriteLine("4. Quit");
            if (!int.TryParse(Console.ReadLine(), out num))
            {
                DisplayMenu();
                return 0;
            } else
            {
                return num;
            }
            
        }
    }
}
