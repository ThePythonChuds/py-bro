/*
 * Project: PyBro
 * File: DynamicLoader.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the DynamicLoader class, which loads components from DLL files
 * at runtime using reflection.
 */

namespace PyBro
{
    public interface IDynamicLoader<T>
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
        T Load<T>(string dllPath, string className);
    }
}