/*
 * Project: PyBro
 * File: PythonException.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the PythonException class, which represents errors that
 * occur during Python script execution.
 */

namespace PyBro
{
    /// <summary>
    /// Represents an exception that occurs while executing Python code.
    /// </summary>
    public class PythonException : System.Exception
    {
        /// <summary>
        /// Creates a new Python exception without a custom message.
        /// </summary>
        public PythonException()
        {

        }

        /// <summary>
        /// Creates a new Python exception with a custom error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PythonException(string message) : base(message)
        {

        }

        /// <summary>
        /// Creates a new Python exception with a custom error message and an inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that caused the current error.</param>
        public PythonException(string message, System.Exception innerException) : base(message, innerException)
        {

        }
    }
}