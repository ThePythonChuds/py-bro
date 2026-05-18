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
    public interface IView : ICommandMessageQueueListener
    {

    }
}