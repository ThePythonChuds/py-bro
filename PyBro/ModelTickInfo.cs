/*
 * Project: PyBro
 * File: ModelTickInfo.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the ModelTickInfo class, which stores the information
 * produced by the model during one application update.
 */

namespace PyBro
{
    /// <summary>
    /// Represents the data sent from the model to the view after one update cycle.
    /// </summary>
    public class ModelTickInfo
    {
        /// <summary>
        /// Gets or sets the text that should be displayed in the output console.
        /// </summary>
        public string OutputToConsole { get; set; } = "";

        /// <summary>
        /// Gets or sets the error text that should be displayed in the console.
        /// </summary>
        public string ErroredToConsole { get; set; } = "";

        /// <summary>
        /// Indicates whether the application should stop running.
        /// </summary>
        public bool ShouldExit { get; set; }

        /// <summary>
        /// Gets or sets the current text buffer content.
        /// </summary>
        public string BufferContent { get; set; } = "";

        /// <summary>
        /// Creates an empty model tick information object.
        /// </summary>
        public ModelTickInfo()
        {

        }
    }
}