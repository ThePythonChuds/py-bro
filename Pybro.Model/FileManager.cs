/*
 * Project: PyBro
 * File: FileManager.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the FileManager class, which handles basic file operations
 * such as creating, saving, reading, and removing files.
 */

using System.IO;

namespace PyBro
{
    /// <summary>
    /// Provides file management operations used by the application.
    /// </summary>
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Creates an empty file at the specified path.
        /// </summary>
        /// <param name="path">The path where the file should be created.</param>
        /// <exception cref="FileException">
        /// Thrown when the file cannot be created.
        /// </exception>
        public void CreateFile(string path)
        {
            try
            {
                File.Create(path).Dispose();
            }
            catch
            {
                System.Console.WriteLine("Error: FileManager.CreateFile()");
                throw new FileException("Can not create file " + path);
            }
        }

        /// <summary>
        /// Saves the provided text buffer to a file.
        /// If the file already exists, its previous content is overwritten.
        /// </summary>
        /// <param name="path">The path of the file where the buffer should be saved.</param>
        /// <param name="buffer">The text content that should be written to the file.</param>
        /// <exception cref="FileException">
        /// Thrown when the file cannot be written.
        /// </exception>
        public void SaveBuffer(string path, string buffer)
        {
            try
            {
                var dir = GetDirectoryName(path);

                EnsureDirectoryExists(dir);

                File.WriteAllText(path, buffer);
            }
            catch
            {
                System.Console.WriteLine("Error: FileManager.SaveBuffer()");
                throw new FileException("Can not write to file " + path);
            }
        }

        /// <summary>
        /// Removes the file located at the specified path.
        /// </summary>
        /// <param name="path">The path of the file that should be removed.</param>
        /// <exception cref="FileException">
        /// Thrown when the specified file does not exist.
        /// </exception>
        public void RemoveFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileException("File " + path + " does not exist!");
            }

            File.Delete(path);
        }

        /// <summary>
        /// Reads the content of a file and returns it as a string.
        /// </summary>
        /// <param name="path">The path of the file that should be read.</param>
        /// <returns>The complete text content of the file.</returns>
        /// <exception cref="FileException">
        /// Thrown when the file cannot be read.
        /// </exception>
        public string GetFileContent(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch
            {
                System.Console.WriteLine("Error: FileManager.GetFileContent()");
                throw new FileException("Can not read from file " + path);
            }
        }

        private static void EnsureDirectoryExists(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        private static string GetDirectoryName(string path)
        {
            string? dir = null;

            try
            {
                dir = Path.GetDirectoryName(path);
            }
            catch
            {
                throw new FileException("path " + path + " is invalid!");
            }

            if (dir == null)
            {
                throw new FileException("path " + path + " denotes a root directory or is null!");
            }

            return dir;
        }
    }
}