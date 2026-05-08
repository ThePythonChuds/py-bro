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

        public Model.TickInfo ApplyTickInfo(View.TickInfo tickInfo)
        {
            return null; // TODO: 
        }

        public class TickInfo
        {
            public TickInfo()
            {
                
            }
        }
    }
}