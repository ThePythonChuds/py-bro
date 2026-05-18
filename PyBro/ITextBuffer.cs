/*
 * Project: PyBro
 * File: ITextBuffer.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the ITextBuffer interface, which defines the operations
 * required for storing and managing editor text content.
 */

namespace PyBro
{
    /// <summary>
    /// Defines the behavior required for a text buffer component.
    /// </summary>
    public interface ITextBuffer
    {
        /// <summary>
        /// Returns information about the current indentation level and indentation string.
        /// </summary>
        /// <returns>
        /// A tuple containing the current indentation level and the indentation string.
        /// </returns>
        (UInt32, string) GetCurrentIndentInfo();

        /// <summary>
        /// Automatically applies indentation to the current line based on the existing buffer content.
        /// </summary>
        void Autoindent();

        /// <summary>
        /// Adds a new line to the text buffer.
        /// </summary>
        /// <param name="line">The line that should be added to the buffer.</param>
        void AddLine(string line);

        /// <summary>
        /// Replaces the current buffer content with the provided text.
        /// </summary>
        /// <param name="content">The new text content of the buffer.</param>
        void SetContent(string content);

        /// <summary>
        /// Returns the entire content stored in the text buffer.
        /// </summary>
        /// <returns>The complete text content of the buffer.</returns>
        string GetContent();
    }
}