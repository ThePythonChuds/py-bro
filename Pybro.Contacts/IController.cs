/*
 * Project: PyBro
 * File: IController.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the IController interface, which defines the main update
 * operation required by application controllers.
 */

namespace PyBro
{
    /// <summary>
    /// Defines the behavior required for a controller component.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Executes one update cycle of the application.
        /// </summary>
        /// <returns>
        /// True if the application should continue running; otherwise, false.
        /// </returns>
        bool Tick();
    }
}