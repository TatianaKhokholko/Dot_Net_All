using System;
using System.Collections.Specialized;
using System.Configuration;

/// <summary>
/// Класс для чтения данных из app.config файла проекта
/// </summary>
namespace FileSystemWatcherModule
{
    class ConfigLoader : ConfigurationSection
    {
        private static NameValueCollection appSettings;

        public ConfigLoader()
        {
            if (appSettings == null)
            {
                try
                {
                    appSettings = ConfigurationManager.AppSettings;
                    if (appSettings.Count == 0)
                    {
                        Console.WriteLine("Конфигурационный файл, текущего приложения пуст.");
                    }
                }
                catch (ConfigurationErrorsException)
                {
                    Console.WriteLine("Ошибка чтения конфигурационного файла.");
                }
            }
        }

        /// <summary>
        /// Метод позволяет получать настройки по ключу
        /// </summary>
        public String GetByKey(String key)
        {
            return appSettings[key];
        }
    }
}
