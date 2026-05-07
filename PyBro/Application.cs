namespace PyBro {
    public class Application {
        private IPythonInterpretor _pythonInterpretor;
        private IUi _ui;
        private IFileManager _fileManager;
        private IBufferManager _bufferManager;
        private bool _isRunning;
        public Application()
        {
            _isRunning = true;

            // daca nu compileaza, inseamna ca nu sunt definite clasele care implementeaza
            _pythonInterpretor = new PythonInterpretor();
            _ui = new Ui();
            _fileManager = new FileManager();
            _bufferManager = new BufferManager();
        }

        public void RunMainLoop()
        {
            while(_isRunning) {}
        }
    }
}