using PyBro.Contracts;
using PyBro.Core;

namespace PyBro.MVC {
    public class Model : IModel
    {

        private readonly IPythonInterpreter _pythonInterpreter;


        private readonly IFileManager _fileManager;

        // key -> file name
        // value -> text buffer
        private readonly Dictionary<string, ITextBuffer> _textBuffers;
        private string? _activeBufferFileName = null;

        public Model(IPythonInterpreter pi, IFileManager fm)
        {
            _pythonInterpreter = pi;
            _fileManager = fm;
            _textBuffers = new Dictionary<string, ITextBuffer>();
        }

        public void AddTextBuffer(string fileName, ITextBuffer textBuffer)
        {
            _textBuffers[fileName] = textBuffer;
        }

        public void ExecuteCommands()
        {
            throw new NotImplementedException(); // TODO: implement command execution logic
        }

    }
}