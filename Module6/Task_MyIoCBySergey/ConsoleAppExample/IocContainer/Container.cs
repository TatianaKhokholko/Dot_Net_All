using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleAppExample.IocContainer
{
    public class Container
    {
        private Type _typeForClass;
        private Type _typeForInterface;
        public Dictionary<Type, Type> _dependencies = new Dictionary<Type, Type>();

        public Container(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    var json = JsonConvert.DeserializeObject <List<ConfigLoader>> (streamReader.ReadToEnd());
                    
                    foreach (var item in json)
                    {
                        _typeForClass = Type.GetType(Assembly.GetEntryAssembly().GetName().Name + ".SettingClasses." + item.Class);
                        _typeForInterface = Type.GetType(Assembly.GetEntryAssembly().GetName().Name + "." + item.Interface);
                        Console.WriteLine(_typeForClass);
                        Console.WriteLine(_typeForInterface);

                        if (_typeForClass != null
                            && _typeForInterface.IsInterface
                            && _typeForClass.IsClass
                            && _typeForClass.GetInterfaces().Contains(_typeForInterface))
                        {
                            RegistreDependency(_typeForInterface, _typeForClass);
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RegistreDependency(Type key, Type value)
        {
            _dependencies.Add(key, value);            
        }

        public I CreateInstance<I>()
            where I : class
        {
            Type key = typeof(I);
            if (_dependencies.ContainsKey(key))
            {
                return (I)Activator.CreateInstance(_dependencies[key]);
            }
            throw new InvalidOperationException("Зависимость не найдена.");
        }
    }
}

      