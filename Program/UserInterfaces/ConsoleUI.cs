using Exercise5.UserInterfaces.Interfaces;
using System;

namespace Exercise5.UserInterfaces
{
    public class ConsoleUI : IConsoleUI
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public char ReadKey()
        {
            return Console.ReadKey(intercept: true).KeyChar;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void ForegroundColor(int color)
        {
            Console.ForegroundColor = (ConsoleColor)12;
        }

        public void BackgroundColor(int color)
        {
            Console.BackgroundColor = (ConsoleColor)12;
        }

        public void CursorPosition(int y, int x)
        {
            Console.SetCursorPosition(y, x);
        }

        public void ResetColor()
        {
            Console.ResetColor();
        }
    }
}