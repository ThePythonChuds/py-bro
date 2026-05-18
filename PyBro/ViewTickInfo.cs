/*
 * Project: PyBro
 * File: ViewTickInfo.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the ViewTickInfo class, which stores information collected
 * from the view during one application update.
 */

namespace PyBro
{
    /// <summary>
    /// Represents the data sent from the view to the model during one update cycle.
    /// </summary>
    public class ViewTickInfo
    {
        /// <summary>
        /// Gets the current text content from the editor.
        /// </summary>
        public string TextBuffer { get; private set; }

        /// <summary>
        /// Creates a new view tick information object using the current editor content.
        /// </summary>
        /// <param name="buffer">The text content collected from the editor.</param>
        public ViewTickInfo(string buffer)
        {
            TextBuffer = buffer;
        }
    }
}