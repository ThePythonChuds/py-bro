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
            } catch (Exception e)
            {
                System.Console.WriteLine("Error: FileManager.CreateFile()");
                throw new FileException();
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
                var dir = Path.GetDirectoryName(path);

                this.EnsureDirectoryExists(dir);

                File.WriteAllText(path, buffer);
            } catch (Exception e)
            {
                System.Console.WriteLine("Error: FileManager.SaveBuffer()");
                throw new FileException();
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
            try
            {
                if (!File.Exists(path))
                    throw new FileException();
                File.Delete(path);
            }
            catch (FileException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new FileException();
            }
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
            } catch (Exception e)
            {
                System.Console.WriteLine("Error: FileManager.GetFileContent()");
                throw new FileException();
            }
        }

        /// <summary>
        /// This method creates a directory at a certain path. If the directory already exists, it does nothing.
        /// </summary>
        /// <param name="dirPath">Path of the directory.</param>
        private void EnsureDirectoryExists(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

    
        }
}