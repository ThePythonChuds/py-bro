/*
 * Project: PyBro
 * File: Model.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the Model class, which manages the application's data,
 * text buffers, file operations, and Python script execution logic.
 */

namespace PyBro
{
    /// <summary>
    /// Represents the model layer of the application.
    /// It stores application data and processes information received from the view.
    /// </summary>
    public class Model : IModel
    {
        private IPythonInterpreter _pythonInterpreter;

        private IFileManager _fileManager;

        // key -> file name
        // value -> text buffer
        private Dictionary<string, ITextBuffer> _textBuffers;

        /// <summary>
        /// Creates a model using the required Python interpreter and file manager services.
        /// </summary>
        /// <param name="pi">The Python interpreter used to execute scripts.</param>
        /// <param name="fm">The file manager used to handle file operations.</param>
        public Model(IPythonInterpreter pi, IFileManager fm)
        {
            _pythonInterpreter = pi;
            _fileManager = fm;
            _textBuffers = new Dictionary<string, ITextBuffer>();
        }

        /// <summary>
        /// Adds or replaces a text buffer associated with a file name.
        /// </summary>
        /// <param name="fileName">The name of the file associated with the text buffer.</param>
        /// <param name="textBuffer">The text buffer that stores the file content.</param>
        public void AddTextBuffer(string fileName, ITextBuffer textBuffer)
        {
            _textBuffers[fileName] = textBuffer;
        }

        /// <summary>
        /// Processes the information received from the view during one application update.
        /// </summary>
        /// <param name="tickInfo">The information collected from the view during the current tick.</param>
        /// <returns>The information that should be sent back to the view.</returns>
        public ModelTickInfo ApplyTickInfo(ViewTickInfo tickInfo)
        {
            var result = new ModelTickInfo();

            return result;
        }
    }
}