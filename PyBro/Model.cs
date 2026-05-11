namespace PyBro {
    public class Model {

        private IPythonInterpreter _pythonInterpreter;

        private IConsole _console;

        private IFileManager _fileManager;

        private TextBuffer _textBuffer = new TextBuffer("");

        public Model()
        {
            _pythonInterpreter = new PythonInterpreter();
            _console = new Console();
            _fileManager = new FileManager();
        }


        /// <summary>
        /// Checks every tick for what it should do
        /// </summary>
        /// <param name="tickInfo">The tick information from the view.</param>
        /// <returns>The tick information to be applied to the model.</returns>
        public Model.TickInfo ApplyTickInfo(View.TickInfo tickInfo)
        {
            var result = new Model.TickInfo();
            this._textBuffer = new TextBuffer(tickInfo.TextBuffer);
            ApplyAutoIndent();


            return result; 
        }

        private void ApplyAutoIndent()
        {
            TextBuffer.IndentLevel = 0;
            foreach (var line in _textBuffer.Lines)
            {
                if (line.Contains(":"))
                {
                    TextBuffer.IndentLevel++;
                }
            }
            _textBuffer.Lines.Last().Insert(0, new string(TextBuffer.IndentString[0], (int)TextBuffer.IndentLevel * TextBuffer.IndentString.Length));
        }

        public class TickInfo
        {
            public string OutputToConsole { get; set; } = "";
            public string ErroredToConsole { get; set; } = "";
            public bool ShouldExit { get; set; }
            public TickInfo()
            {
                
            }
        }
    }
}