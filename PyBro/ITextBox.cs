using System;

namespace PyBro
{

	public interface ITextBox
	{
        /// <summary>
        /// Adds text to the buffer starting at coords.
        /// </summary>
        /// <param name="text">Text to be inserted.</param>
        /// <param name="coords">Position at which to insert text</param>
		public void AddString(String text, Coords coords);

		/// <summary>
        /// Deletes the text inbetween the start and end position.
        /// The method includes both ends. [start, end]
        /// </summary>
        /// <param name="start">Start position</param>
        /// <param name="end"></param>
		public void RemoveString(Coords start, Coords end);
	}
}
