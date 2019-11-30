using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyIoC
{
	public class Container
	{
        private readonly IDictionary<Type, Type> _typesClassDictionary;

        public Container()
        {
            _typesClassDictionary = new Dictionary<Type, Type>();
        }

        public void AddAssembly(Assembly assembly)
		{
            var types = assembly.ExportedTypes;
            foreach (var type in types)
            {
                var constructorImportAttribute = type.GetCustomAttribute<ImportConstructorAttribute>();
                if (constructorImportAttribute != null || IsImportProperties(type))
                {
                    _typesClassDictionary.Add(type, type);
                }

                var exportAttributes = type.GetCustomAttributes<ExportAttribute>();
                foreach (var exportAttribute in exportAttributes)
                {
                    _typesClassDictionary.Add(exportAttribute.Contract ?? type, type); //если первый null берем второй
                }
            }
        }

        public void AddType(Type type)
		{
            _typesClassDictionary.Add(type, type);
        }

		public void AddType(Type type, Type baseType)
		{
            _typesClassDictionary.Add(baseType, type);
        }

		public object CreateInstance(Type type)
		{
            if (!_typesClassDictionary.ContainsKey(type))
            {
                Console.WriteLine($"Can not create instance of {type.FullName}. Dependency is not provided.");
            }
            return type;
		}

		public void Sample()
		{
			var container = new Container();
			container.AddAssembly(Assembly.GetExecutingAssembly());

			var customerBLL1 = (CustomerBLL)container.CreateInstance(typeof(CustomerBLL));
			var customerBLL2 = (CustomerBLL)container.CreateInstance(typeof(CustomerBLL));

            container.AddType(typeof(CustomerBLL));
			container.AddType(typeof(Logger));
			container.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));
		}

        private bool IsImportProperties(Type type)
        {
            var propertiesToImport = GetPropertiesToImport(type);
            return propertiesToImport.Any();
        }

        private IEnumerable<PropertyInfo> GetPropertiesToImport(Type type)
        {
            return type.GetProperties()
                .Where(p => p.GetCustomAttribute<ImportAttribute>() != null);
        }
    }
}
