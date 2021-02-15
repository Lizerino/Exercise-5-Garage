using Exercise5.Menus;

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