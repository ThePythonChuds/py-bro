using PyBro.Commands;
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
            for (var cmd = MessageQueues.ReceiveModelCommand(); cmd != null; cmd = MessageQueues.ReceiveModelCommand())
            {
                ExecuteCommand(cmd);
            }
        }

        private void ExecuteCommand(IModelCommand cmd)
        {
            switch (cmd) // <-- Where the magic happens ;)
            {
                case ModelCommandLoadFile modelCommandLoadFile:
                    {
                        var args = new object[1];
                        args[0] = _fileManager;
                        modelCommandLoadFile.Execute(args);
                        break;
                    }

                case ModelCommandRewriteBuffer modelCommandRewriteBuffer:
                    {
                        var args = new object[1];
                        args[0] = _textBuffers;
                        modelCommandRewriteBuffer.Execute(args);
                        break;
                    }

                case ModelCommandRunPythonScript modelCommandRunPythonScript:
                    {
                        var args = new object[1];
                        args[0] = _pythonInterpreter;
                        modelCommandRunPythonScript.Execute(args);
                        break;
                    }

                case ModelCommandSaveBuffer modelCommandSaveBuffer:
                    {
                        var args = new object[1];
                        args[0] = _fileManager;
                        modelCommandSaveBuffer.Execute(args);
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException($"Unknown command type: {cmd.GetType().Name}");
                    }
            }
        }
    }
}