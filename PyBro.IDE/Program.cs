using PyBro.Contracts;
using PyBro.UI;
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
            var app = new System.Windows.Application();
            var mainWindow = new MainWindow();

            var ide = new IdeBuilder()
                .WithApp(app)
                .WithPythonInterpreter(new PythonInterpreter())
                .WithFileManager(new FileManager())
                .WithUiAdapter(new UiAdapter(mainWindow))
                .WithTreeDir(new TreeDir())
                .Build();

            ide.Run();
        }
    }
}
