namespace Exercise5.UserInterfaces.Interfaces

{
    public interface IConsoleUI
    {
        void Write(string message);

        void WriteLine(string message);

        string ReadLine();

        char ReadKey();

        void Clear();

        void CursorPosition(int y, int x);

        void ForegroundColor(int color);

        void BackgroundColor(int color);

        void ResetColor();
    }
}