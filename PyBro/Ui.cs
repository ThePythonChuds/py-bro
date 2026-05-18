/*
 * Project: PyBro
 * File: Ui.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the Ui class, which provides access to the WPF user
 * interface and exposes UI operations required by the application.
 */

using PyBro.UI;

namespace PyBro
{
    /// <summary>
    /// Provides communication between the application logic and the WPF main window.
    /// </summary>
    public class Ui : IUi
    {
        private MainWindow? _mainWindow = null;

        private MainWindow MainWindow
        {
            get
            {
                if (_mainWindow == null)
                {
                    _mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
                }

                return _mainWindow;
            }
        }

        /// <summary>
        /// Creates a new UI adapter.
        /// </summary>
        public Ui()
        {
        }

        /// <summary>
        /// Returns the current text written in the editor.
        /// </summary>
        /// <returns>The current editor content.</returns>
        public string GetBuffer()
        {
            return this.MainWindow.GetBuffer();
        }

        /// <summary>
        /// Returns the coordinates of the currently highlighted text area.
        /// </summary>
        /// <returns>
        /// A tuple containing the start and end coordinates of the highlighted area.
        /// If no text is highlighted, the values may be null.
        /// </returns>
        public (Coords?, Coords?) GetHighlightCoords()
        {
            return (null, null);
        }

        /// <summary>
        /// Saves the current editor content to the specified file path.
        /// </summary>
        /// <param name="path">The path where the file should be saved.</param>
        public void SaveFile(string path) { }

        /// <summary>
        /// Creates a new file at the specified path.
        /// </summary>
        /// <param name="path">The path where the file should be created.</param>
        public void CreateFile(string path) { }

        /// <summary>
        /// Opens the file located at the specified path.
        /// </summary>
        /// <param name="path">The path of the file that should be opened.</param>
        public void OpenFile(string path) { }

        /// <summary>
        /// Removes the file located at the specified path.
        /// </summary>
        /// <param name="path">The path of the file that should be removed.</param>
        public void RemoveFile(string path) { }

        /// <summary>
        /// Refreshes the user interface.
        /// </summary>
        public void Refresh() { }

        /// <summary>
        /// Runs the current script written in the editor.
        /// </summary>
        public void RunScript() { }
    }
}