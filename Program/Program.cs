using Autofac;
using Exercise5.Interfaces;

namespace Exercise5

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var startup = scope.Resolve<IStartup>();
                startup.Run();
            }
        }
    }
}