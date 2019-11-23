using System;

namespace FileSystemWatcherModule
{
    /// <summary>
    /// Класс поставляет методы для получения данных из файла конфигурации
    /// </summary>
    public class ModelConfig
    {
        private ConfigLoader configLoader = new ConfigLoader();

        public String Directory1 => configLoader.GetByKey("path1");
        public String Directory2 => configLoader.GetByKey("path2");
        public String DefaultDirectory => configLoader.GetByKey("defaultPath");
        public String RuleByNameFile => configLoader.GetByKey("nameFile");
    }
}
