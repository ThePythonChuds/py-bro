using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PyBro.Commands;
using PyBro.Core;
using PyBro.Contracts;
using PyBro.IDE;
using PyBro.MVC;
using PyBro.UI;

namespace PyBro.Core
{
    public class DependencyInjector
    {
        private static readonly Dictionary<Type, Object> _dependenciesRefs = new Dictionary<Type, Object>();
        private static string _basePath =  AppDomain.CurrentDomain.BaseDirectory;

        // Numele dllurilor
        private static string _dllCommands  = _basePath + "PyBro.Commands.dll";
        private static string _dllContracts = _basePath + "PyBro.Contracts.dll";
        private static string _dllIDE       = _basePath + "PyBro.IDE.dll";
        private static string _dllMVC       = _basePath + "PyBro.MVC.dll";
        private static string _dllUI        = _basePath + "PyBro.UI.dll";

        static DependencyInjector()
        {
            LoadAssemblies();
        }

        private static void LoadAssemblies()
        {
            // Loading each assembly, with care.
            LoadCommands();
            LoadCore();
            LoadMVC();
            LoadUI();
        }

        

        private static void LoadCommands()
        {
            var modelCommandLoadFileClass = DynamicLoader.Load<ModelCommandLoadFile>(_dllCommands, "ModelCommandLoadFileClass");
            RegisterDependency(ModelCommandLoadFile.GetType(), modelCommandLoadFileClass);
        }

        private static void LoadCore()
        {
            throw new NotImplementedException();
        }

        private static void LoadMVC()
        {
            throw new NotImplementedException();
        }

        private static void LoadUI()
        {
            throw new NotImplementedException();
        }

        private static void RegisterDependency(Type key, Object value)
        {
            if (_dependenciesRefs.ContainsKey(key))
            {
                throw new InvalidOperationException("Class " + key.AssemblyQualifiedName + " is already registered by the DependencyInjector!");
            }

            if (!value.GetType().Equals(key))
            {
                throw new InvalidOperationException("Can not register " + key.AssemblyQualifiedName + ". Dependency is required to be of type " + key.AssemblyQualifiedName + " but type " + value.GetType().AssemblyQualifiedName + " was found!");
            }
            _dependenciesRefs[key] = value;
        }
    }
}
