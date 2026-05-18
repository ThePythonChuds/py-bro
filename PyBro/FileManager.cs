using System.IO;

namespace PyBro
{
    public class FileManager : IFileManager
    {

        /// <summary>
        /// Creates an empty file. The method is blocking.
        /// </summary>
        /// <param name="path">Path of the file to be created</param>
        /// <exception cref="FileException">
        /// Thrown when name is null.
        /// </exception>
        public void CreateFile(string path)
        {
            try
            {
                File.Create(path).Dispose();
            } catch
            {
                System.Console.WriteLine("Error: FileManager.CreateFile()");
                throw new FileException("Can not create file " + path);
            }
        }

        /// <summary>
        /// This method creates the file if a file does not exist at that path, and tries to overwrite the buffer to the file if it exists already. 
        /// The previous content of the file before method call is lost.
        /// The method is blocking.
        /// </summary>
        /// <param name="path">Path of the file to be created</param>
        /// <param name="buffer">Content of the file</param>
        /// <exception cref="FileException">If file creation failed.</exception>
        public void SaveBuffer(string path, string buffer)
        {
            try
            {
                var dir = GetDirectoryName(path);

                EnsureDirectoryExists(dir);

                File.WriteAllText(path, buffer);
            } catch
            {
                System.Console.WriteLine("Error: FileManager.SaveBuffer()");
                throw new FileException("Can not write to file " + path);
            }
        }

        /// <summary>
        /// Requests OS for removing a file.
        /// If the file does not exist, no exception is thrown
        /// The method is blocking.
        /// </summary>
        /// <param name="path">Path of the file to be removed</param>
        /// <exception cref="FileException">If the path does not point to a file.</exception>
        public void RemoveFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileException("File " + path + " does not exist!");
            }
            File.Delete(path);
        }

        /// <summary>
        /// Loads file content into a string.
        /// The method is blocking.
        /// </summary>
        /// <param name="path">Path of the file to be read</param>
        /// <returns>The content of the file.</returns>
        public string GetFileContent(string path)
        {
            try {
                return File.ReadAllText(path);
            } catch {
                System.Console.WriteLine("Error: FileManager.GetFileContent()");
                throw new FileException("Can not read from file " + path);
            }
        }

        /// <summary>
        /// This method creates a directory at a certain path. If the directory already exists, it does nothing.
        /// </summary>
        /// <param name="dirPath">Path of the directory.</param>
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