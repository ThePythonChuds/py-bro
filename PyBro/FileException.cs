using System;

namespace PyBro
{
    public class FileException : Exception
    {
        public FileException() { }
        public FileException(string message) : base(message) { }

    }
}