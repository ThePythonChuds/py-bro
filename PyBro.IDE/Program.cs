using PyBro.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.IDE
{
    internal class Program
    {
        /// <summary>
        /// Starts the PyBro application by dynamically loading the required components
        /// and running the main application instance.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        [System.STAThreadAttribute]
        public static void Main(string[] args)
        {
           
            string modelDllPath = Path.Combine(basePath, "PyBro.Model.dll");

            var pythonInterpreter = DynamicLoader.Load<IPythonInterpreter>(
                modelDllPath,
                "PyBro.PythonInterpreter"
            );

            var fileManager = DynamicLoader.Load<IFileManager>(
                modelDllPath,
                "PyBro.FileManager"
            );

            var app = new IdeBuilder()
                .WithPythonInterpreter(pythonInterpreter)
                .WithFileManager(fileManager)
                .Build();

            app.Run();
        }
    }
}
