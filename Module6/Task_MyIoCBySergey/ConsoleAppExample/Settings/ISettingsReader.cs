using System;

namespace ConsoleAppExample.Settings
{
    public interface ISettingsReader
    {
        T Load<T>() where T : class, new();
        T LoadSection<T>() where T : class, new();
        object Load(Type type);
        object LoadSection(Type type);
    }
}
