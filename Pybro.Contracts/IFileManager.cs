/*
 * Project: PyBro
 * File: IFileManager.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the IFileManager interface, which defines the basic file
 * operations required by the application.
 */

namespace PyBro.Contracts {
    public interface IFileManager {
        
        /// <summary>
        /// Creates an empty file  
        /// </summary>
        /// <param name="path">Path of the file to be created</param>
        /// <exception>
        /// Thrown when name is null.
        /// </exception>
        public void CreateFile(string path);

        /// <summary>
        /// This method creates the file if a file does not exist at that path, and tries to overwrite the buffer to the file if it exists already. 
        /// </summary>
        /// <param name="path">Path of the file to be created</param>
        /// <param name="buffer">Content of the file</param>
        /// <exception cref="FileException">If file creation failed.</exception>
        public void SaveBuffer(string path, string buffer);

        /// <summary>
        /// Requests OS for removing a file.
        /// </summary>
        /// <param name="path">Path of the file to be removed</param>
        /// <exception cref="FileException">If the path does not point to a file.</exception>
        public void RemoveFile(string path);

        /// <summary>
        /// Loads file content into a string.  
        /// </summary>
        /// <param name="path">Path of the file to be read</param>
        /// <returns>The content of the file.</returns>
        public string GetFileContent(string path);
    }
}