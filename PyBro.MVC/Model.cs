namespace PyBro {
    public class Model : IModel
    {

        private IPythonInterpreter _pythonInterpreter;


        private IFileManager _fileManager;

        // key -> file name
        // value -> text buffer
        private Dictionary<string, ITextBuffer> _textBuffers;
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

        /// <summary>
        /// Checks every tick for what it should do
        /// </summary>
        /// <param name="tickInfo">The tick information from the view.</param>
        /// <returns>The tick information to be applied to the model.</returns>
        public ModelTickInfo ApplyTickInfo(ViewTickInfo tickInfo)
        {
            if (tickInfo.Commands != null)
            {
                foreach (var command in tickInfo.Commands)
                {
                    if (command is CreateBufferCommand createBufferCommand)
                    {
                        HandleCreateBufferCommand(createBufferCommand);
                    }
                    else if (command is SwitchActiveBufferCommand switchActiveBufferCommand)
                    {
                        // Handle switching the active buffer if needed
                        _activeBufferFileName = switchActiveBufferCommand.FileName;
                    }
                }
            }

            var result = new ModelTickInfo();
            return result;
        }

        private void HandleCreateBufferCommand(CreateBufferCommand command)
        {
            var fileName = command.FileName;
            if (_textBuffers.ContainsKey(fileName))
            {
                // Remove the existing buffer if it already exists
                _textBuffers.Remove(fileName);
            }
            var textBuffer = new ArrayListTextBuffer();
            textBuffer.SetContent(command.BufferContent);
            _textBuffers[fileName] = textBuffer;
        }
    }
}