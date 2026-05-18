/*
 * Project: PyBro
 * File: FileItem.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the FileItem class, which represents a file or directory
 * displayed in the application's file explorer.
 */

using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace PyBro
{
    /// <summary>
    /// Represents a file system item displayed in the file explorer.
    /// The item can be either a file or a directory and may contain child items.
    /// </summary>
    public class FileItem
    {
        /// <summary>
        /// Gets or sets the display name of the file or directory.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the full path of the file or directory.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the icon type used to visually represent this item.
        /// </summary>
        public string IconKind { get; set; }

        /// <summary>
        /// Gets or sets the color of the displayed icon.
        /// </summary>
        public Brush IconColor { get; set; }

        /// <summary>
        /// Gets or sets the child items contained by this item.
        /// This is mainly used when the item represents a directory.
        /// </summary>
        public List<FileItem> Children { get; set; } = new List<FileItem>();

        /// <summary>
        /// Indicates whether the current item represents a directory.
        /// </summary>
        public bool IsDirectory => Children.Count > 0 || Directory.Exists(Path);
    }
}