using Exercise5.Interfaces;
using Exercise5.Menus;
using Exercise5.Menus.Interfaces;

namespace Exercise5
{
    public class Startup : IStartup
    {
        private IMainMenu mainMenu;

        public Startup(IMainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public void Run()
        {
            mainMenu.Show();
        }
    }
}