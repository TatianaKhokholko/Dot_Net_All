using ConsoleAppExample.SettingClasses;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleAppExample.IocContainer
{
    public class Container
    {
        private string nameClass;

        public Container(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    var json = JsonConvert.DeserializeObject<ConfigLoader>(streamReader.ReadToEnd());
                    nameClass = json.Class;
                          
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public I CreateInstance<I>()
             where I : class
        {
            if (nameClass.Contains("ForDebugVersion"))
            {
                return (I)Activator.CreateInstance(typeof(ForDebugVersion));
            }
            else
            {
                return (I)Activator.CreateInstance(typeof(ForReleaseVersion));
            }
            throw new InvalidOperationException("Зависимость не найдена.");
        }
    }
}

      