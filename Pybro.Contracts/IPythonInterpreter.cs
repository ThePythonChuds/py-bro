/*
 * Project: PyBro
 * File: IPythonInterpreter.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the IPythonInterpreter interface, which defines the operation
 * required for executing Python scripts.
 */

namespace PyBro.Contracts
{
    /// <summary>
    /// Defines the behavior required for a Python interpreter component.
    /// </summary>
    public interface IPythonInterpreter
    {
        /// <summary>
        /// Executes a Python script and returns the execution output.
        /// </summary>
        /// <param name="script">The Python script that should be executed.</param>
        /// <returns>
        /// A tuple containing the standard output and the error output produced by the script.
        /// </returns>
        /// <exception cref="PythonException">
        /// Thrown when an error occurs during Python script execution.
        /// </exception>
        (string, string) RunScript(string script);
    }
}