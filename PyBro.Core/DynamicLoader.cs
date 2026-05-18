/*
 * Project: PyBro
 * File: DynamicLoader.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the DynamicLoader class, which loads components from DLL files
 * at runtime using reflection.
 */

using System;
using System.IO;
using System.Reflection;

namespace PyBro
{
    /// <summary>
    /// Provides functionality for dynamically loading objects from external DLL files.
    /// </summary>
    public static class DynamicLoader : IDynamicLoader
    {
        /// <summary>
        /// Loads an object from a DLL and casts it to the requested interface type.
        /// </summary>
        /// <typeparam name="T">The interface type expected from the loaded object.</typeparam>
        /// <param name="dllPath">The path to the DLL file.</param>
        /// <param name="className">The full name of the class that should be created.</param>
        /// <returns>An instance of the requested class, cast to the specified interface.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the DLL, class, or object instance cannot be loaded correctly.
        /// </exception>
        public static T Load<T>(string dllPath, string className)
        {
            if (!File.Exists(dllPath))
            {
                throw new InvalidOperationException("DLL file not found: " + dllPath);
            }

            Assembly assembly = Assembly.LoadFrom(dllPath);

            Type? type = assembly.GetType(className);

            if (type == null)
            {
                throw new InvalidOperationException("Class not found in DLL: " + className);
            }

            object? instance = Activator.CreateInstance(type);

            if (instance == null)
            {
                throw new InvalidOperationException("Could not create instance of: " + className);
            }

            if (instance is not T result)
            {
                throw new InvalidOperationException(className + " does not implement the required interface.");
            }

            return result;
        }
    }
}