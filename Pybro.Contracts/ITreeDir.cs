/*
 * Project: PyBro
 * File: ITreeDir.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the ITreeDir interface, which defines the operation
 * required for refreshing the directory tree displayed by the application.
 */

namespace PyBro.Contracts
{
    /// <summary>
    /// Defines the behavior required for a directory tree component.
    /// </summary>
    public interface ITreeDir
    {
        /// <summary>
        /// Refreshes the displayed directory tree structure.
        /// </summary>
        void Refresh();
    }
}