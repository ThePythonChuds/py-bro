namespace PyBro {
    public class Model {

        private IPythonInterpreter _pythonInterpreter;

        private IConsole _console;

        private IFileManager _fileManager;

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

            if (tickInfo.ShouldExit)
            {
                result.ShouldExit = true;
                return result;
            }

            if(tickInfo.ShouldRunScript)
            {
                var scriptResult = _pythonInterpreter.RunScript(tickInfo.ScriptToRun);

                result.OutputToConsole = scriptResult.Item1;
                result.ErroredToConsole = scriptResult.Item2;
            }
            return result; 
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