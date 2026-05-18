/*
 * Project: PyBro
 * File: FileException.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the FileException class, which represents errors related
 * to file operations in the application.
 */

using System;

namespace PyBro
{
    /// <summary>
    /// Represents an exception that occurs during file operations.
    /// </summary>
    public class FileException : Exception
    {
        /// <summary>
        /// Creates a new file exception without a custom message.
        /// </summary>
        public FileException() { }

        /// <summary>
        /// Creates a new file exception with a custom error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public FileException(string message) : base(message) { }
    }
}