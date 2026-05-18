/*
 * Project: PyBro
 * File: ArrayListTextBuffer.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the ArrayListTextBuffer class, which stores and manages
 * the text content of the editor using a list of strings.
 */

using System.Text;

namespace PyBro
{
    /// <summary>
    /// Implements a text buffer using a list of strings, where each element
    /// represents one line from the editor.
    /// </summary>
    public class ArrayListTextBuffer : ITextBuffer
    {
        private List<string> _buffer { get; set; }

        /// <summary>
        /// Creates an empty text buffer.
        /// </summary>
        public ArrayListTextBuffer()
        {
            this._buffer = new List<string>();
        }

        /// <summary>
        /// Adds a new line to the text buffer.
        /// If the line ends with a newline character, it is removed before storing.
        /// </summary>
        /// <param name="line">The line that will be added to the buffer.</param>
        public void AddLine(string line)
        {
            if (line.Last() == '\n')
            {
                line = line.Substring(0, line.Length - 1);
            }

            _buffer.Add(line);
        }

        /// <summary>
        /// Returns the entire content of the buffer as a single string.
        /// </summary>
        /// <returns>The complete text stored in the buffer.</returns>
        public string GetContent()
        {
            var sb = new StringBuilder();

            foreach (var line in _buffer)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Calculates the current indentation level and detects the indentation string
        /// used inside the buffer.
        /// </summary>
        /// <returns>
        /// A tuple containing the indentation level and the indentation string.
        /// </returns>
        public (uint, string?) GetCurrentIndentInfo()
        {
            uint indentLevel = 0;
            string? indentString = null;

            for (int i = 0; i < _buffer.Count; ++i)
            {
                var line = _buffer[i];

                if (indentLevel >= 1 && indentString == null)
                {
                    indentString = GetIndentString(line);
                }
                else if (indentLevel >= 1 && indentString != null && !indentString.Equals(GetIndentString(line)))
                {
                    var correctedLine = indentString + line.TrimStart();
                    _buffer[i] = correctedLine;
                }

                if (line.Contains(":"))
                {
                    indentLevel++;
                }
            }

            return (indentLevel, indentString);
        }

        /// <summary>
        /// Replaces the current buffer content with the provided text.
        /// The text is split into separate lines before being stored.
        /// </summary>
        /// <param name="content">The new text content of the buffer.</param>
        public void SetContent(string content)
        {
            _buffer = new List<string>(content.Split('\n'));
        }

        private static string GetIndentString(string line)
        {
            return line.Substring(0, line.Length - line.TrimStart().Length);
        }

        /// <summary>
        /// Automatically applies indentation to the last empty line in the buffer,
        /// based on the current indentation level.
        /// </summary>
        public void Autoindent()
        {
            var (indentLevel, indentString) = this.GetCurrentIndentInfo();

            if (_buffer.Last() == "")
            {
                var sb = new StringBuilder();

                for (int i = 0; i < indentLevel; ++i)
                {
                    sb.Append(indentString);
                }

                _buffer[_buffer.Count - 1] = sb.ToString();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}