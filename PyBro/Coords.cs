/*
 * Project: PyBro
 * File: Coords.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the Coords class, which represents a position using
 * a row and a column inside the editor.
 */

namespace PyBro
{
    /// <summary>
    /// Represents a position in the editor using row and column coordinates.
    /// </summary>
    public class Coords
    {
        /// <summary>
        /// Creates a new coordinate pair.
        /// </summary>
        /// <param name="row">The row position.</param>
        /// <param name="col">The column position.</param>
        public Coords(uint row, uint col)
        {
            Row = row;
            Col = col;
        }

        /// <summary>
        /// Gets or sets the row position.
        /// </summary>
        public uint Row { get; set; }

        /// <summary>
        /// Gets or sets the column position.
        /// </summary>
        public uint Col { get; set; }
    }
}