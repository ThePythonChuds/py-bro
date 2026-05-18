/*
 * Project: PyBro
 * File: TreeDir.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the TreeDir class, which builds and refreshes the directory
 * tree used by the application's file explorer.
 */

using System;
using System.IO;
using System.Windows.Media;
using PyBro.Contracts;

namespace PyBro
{
    /// <summary>
    /// Provides functionality for building and refreshing the application's directory tree.
    /// </summary>
    public class TreeDir : ITreeDir
    {
        /// <summary>
        /// Builds a file tree from the specified directory path.
        /// Only Python files and directories are included in the result.
        /// </summary>
        /// <param name="directoryPath">The root directory path used to build the file tree.</param>
        /// <returns>A list of file items representing the directory structure.</returns>
        public static List<FileItem> BuildFileTree(string directoryPath)
        {
            var items = new List<FileItem>();
            var dirInfo = new DirectoryInfo(directoryPath);

            try
            {
                foreach (var directory in dirInfo.GetDirectories())
                {
                    items.Add(new FileItem
                    {
                        Name = directory.Name,
                        Path = directory.FullName,
                        IconKind = "Folder",
                        IconColor = Brushes.Orange,
                        Children = BuildFileTree(directory.FullName)
                    });
                }

                foreach (var file in dirInfo.GetFiles("*.py"))
                {
                    items.Add(new FileItem
                    {
                        Name = file.Name,
                        Path = file.FullName,
                        IconKind = "LanguagePython",
                        IconColor = Brushes.SkyBlue
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return items;
        }

        /// <summary>
        /// Creates a new directory tree component.
        /// </summary>
        public TreeDir()
        {
        }

        /// <summary>
        /// Refreshes the directory tree structure.
        /// </summary>
        public void Refresh()
        {
        }
    }
}