using Autofac;
using ConsoleAppExample.Services;

namespace ConsoleAppExample.IocContainer
{
    public static class Container
    {
        public static IContainer Initialize(string path)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new SettingsModuleMorning(path));
            builder.RegisterType<MorningHandler>().As<IMorningShit>();            
      
            return builder.Build();
        }
    }
}

      