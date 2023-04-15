using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Utilities
{
    public class Basics
    {
        const string appName = "RSGym Administration";

        public static void SetUniCodeConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        public static void Title01(string title)
        {
            Console.WriteLine(new string('_', Console.WindowWidth));
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title.ToUpper());
            Console.WriteLine(new string('_', Console.WindowWidth));
        }

        public static void Title02(string title)
        {
            Console.WriteLine(new string('_', title.Length));
            Console.WriteLine($"\n{title}");
            Console.WriteLine(new string('_', title.Length));
            Console.WriteLine();
        }

        public static void FinalMessage(string message)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
            Console.WriteLine(message);
        }

        public static void Voltar()
        {
            Console.WriteLine("\n\nPrime qualquer tecla para voltar ao menu anterior.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Voltar(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Console.Clear();
        }

        public static void ListMenu(Dictionary<string, string> menu, string menuTitle)
        {
            Utilities.Basics.Title01($"{appName} :: {menuTitle}");

            foreach (KeyValuePair<string, string> item in menu)
            {
                Console.WriteLine($"{item.Key}. > {item.Value}");
            }
        }

        public static void ListMenuSimple(Dictionary<string, string> menu)
        {
            foreach (KeyValuePair<string, string> item in menu)
            {
                Console.WriteLine($"{item.Key}. > {item.Value}");
            }
        }

        public static void BlockSeparator(int breaks)
        {
            Console.WriteLine(new string('\n', breaks));
        }

        public static string AskData(string ask)
        {
            Console.Write($"{ask}: ");
            return Console.ReadLine();
        }

        public static void Message(string message)
        {
            Console.WriteLine(message);
        }

    }
}
