/*
 * Project: PyBro
 * File: View.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the View class, which collects information from the user
 * interface and displays the information received from the model.
 */

namespace PyBro
{
    /// <summary>
    /// Represents the view layer of the application.
    /// It communicates with the UI and prepares user interface data for the controller.
    /// </summary>
    public class View : IView
    {
        private IUi _ui;
        private ITreeDir _treeDir;

        /// <summary>
        /// Creates a new view and initializes the UI and directory tree components.
        /// </summary>
        public View()
        {
            _ui = new Ui();
            _treeDir = new TreeDir();
        }

        /// <summary>
        /// Displays the information received from the model.
        /// </summary>
        /// <param name="modelInfo">The information produced by the model during the current update.</param>
        public void Show(ModelTickInfo modelInfo)
        {
            if (!string.IsNullOrWhiteSpace(modelInfo.OutputToConsole))
            {
                System.Console.WriteLine("STDOUT:");
                System.Console.WriteLine(modelInfo.OutputToConsole);
            }

            if (!string.IsNullOrWhiteSpace(modelInfo.ErroredToConsole))
            {
                System.Console.WriteLine("STDERR:");
                System.Console.WriteLine(modelInfo.ErroredToConsole);
            }
        }

        /// <summary>
        /// Collects the current state of the user interface and prepares it for the model.
        /// </summary>
        /// <returns>The information collected from the view during the current update.</returns>
        public ViewTickInfo PackViewTickInfo()
        {
            return new ViewTickInfo(_ui.GetBuffer());
        }
    }
}