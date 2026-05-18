/*
 * Project: PyBro
 * File: IUi.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the IUi interface, which defines the operations required
 * for communication with the user interface layer.
 */

namespace PyBro.Contracts
{
    /// <summary>
    /// Defines the behavior required for the user interface component.
    /// </summary>
    public interface IUi
    {

        /// <summary>
        /// Returns the current text content from the editor.
        /// </summary>
        /// <returns>The text currently written in the editor.</returns>
        string GetBuffer();

        /// <summary>
        /// Saves the current editor content to the specified file path.
        /// </summary>
        /// <param name="path">The path where the file should be saved.</param>
        void SaveFile(string path);

        /// <summary>
        /// Creates a new file at the specified path.
        /// </summary>
        /// <param name="path">The path where the file should be created.</param>
        void CreateFile(string path);

        /// <summary>
        /// Opens the file located at the specified path.
        /// </summary>
        /// <param name="path">The path of the file that should be opened.</param>
        void OpenFile(string path);

        /// <summary>
        /// Removes the file located at the specified path.
        /// </summary>
        /// <param name="path">The path of the file that should be removed.</param>
        void RemoveFile(string path);

        /// <summary>
        /// Refreshes the user interface content.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Runs the current script written in the editor.
        /// </summary>
        void RunScript();
    }
}