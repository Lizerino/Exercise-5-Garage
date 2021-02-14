using Autofac;

namespace Exercise5

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            // TODO: User input validation
            // TODO: Try catch file handling
            using (var scope = container.BeginLifetimeScope())
            {
                var startup = scope.Resolve<IStartup>();
                startup.Run();
            }
        }
    }
}