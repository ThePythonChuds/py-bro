/*
 * Project: PyBro
 * File: IView.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the IView interface, which defines the operations required
 * for displaying model data and collecting information from the user interface.
 */

namespace PyBro.Contracts
{
    /// <summary>
    /// Defines the behavior required for the view component of the application.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Displays the information received from the model.
        /// </summary>
        /// <param name="modelInfo">The information produced by the model during the current update.</param>
        void Show(ModelTickInfo modelInfo);

        /// <summary>
        /// Collects the current view state and user actions into a tick information object.
        /// </summary>
        /// <returns>The information collected from the view during the current update.</returns>
        ViewTickInfo PackViewTickInfo();
    }
}