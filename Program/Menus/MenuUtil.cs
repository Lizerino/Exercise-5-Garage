using Exercise5.Menus.Interfaces;
using Exercise5.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5.Menus
{
    public class MenuUtil : IMenuUtil
    {
        private IConsoleUI cui;

        public MenuUtil(IConsoleUI cui)
        {
            this.cui = cui;
        }

        public void MenuOption(string number, string message)
        {
            cui.ForegroundColor(14);
            cui.Write(number+": ");
            cui.ResetColor();
            cui.WriteLine(message);
        }
    }
}
