/*
 * Project: PyBro
 * File: IModel.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the IModel interface, which defines the operations required
 * by the application's model layer.
 */

namespace PyBro.Contracts
{
    /// <summary>
    /// Defines the behavior required for the model component of the application.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Processes information received from the view during one application update.
        /// </summary>
        /// <param name="tickInfo">The information collected from the view during the current tick.</param>
        /// <returns>The information that should be sent back to the view.</returns>
        ModelTickInfo ApplyTickInfo(ViewTickInfo tickInfo);

        /// <summary>
        /// Adds a text buffer and associates it with a file name.
        /// </summary>
        /// <param name="fileName">The name of the file associated with the text buffer.</param>
        /// <param name="textBuffer">The text buffer that stores the file content.</param>
        void AddTextBuffer(string fileName, ITextBuffer textBuffer);
    }
}