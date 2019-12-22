using Autofac;
using ConsoleAppExample.Settings;
using System;
using System.Linq;
using System.Reflection;
using Module = Autofac.Module;

namespace ConsoleAppExample.IocContainer
{
    public class SettingsModuleMorning : Module
    {
        private readonly string _configurationFilePath;
        private readonly string _sectionNameSuffix;

        public SettingsModuleMorning(string configurationFilePath, string sectionNameSuffix = "Settings")
        {
            _configurationFilePath = configurationFilePath;
            _sectionNameSuffix = sectionNameSuffix;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new Settings.SettingsReader(_configurationFilePath, _sectionNameSuffix))
                .As<ISettingsReader>()
                .SingleInstance();

            var settings = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Name.EndsWith(_sectionNameSuffix, StringComparison.InvariantCulture))
                .ToList();

            settings.ForEach(type =>
            {
                builder.Register(c => c.Resolve<ISettingsReader>().LoadSection(type))
                    .As(type)
                    .SingleInstance();
            });
        }
    }
}