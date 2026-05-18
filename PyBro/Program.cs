/*
 * Project: PyBro
 * File: Program.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the Program class, which represents the starting point
 * of the application.
 */

using System.IO;
using PyBro;

class Program
{
    /// <summary>
    /// Starts the PyBro application by dynamically loading the required components
    /// and running the main application instance.
    /// </summary>
    /// <param name="args">Command-line arguments passed to the application.</param>
    [System.STAThreadAttribute]
    public static void Main(string[] args)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;

        string modelDllPath = Path.Combine(basePath, "PyBro.Model.dll");

        var pythonInterpreter = DynamicLoader.Load<IPythonInterpreter>(
            modelDllPath,
            "PyBro.PythonInterpreter"
        );

        var fileManager = DynamicLoader.Load<IFileManager>(
            modelDllPath,
            "PyBro.FileManager"
        );

        var app = new ApplicationBuilder()
            .WithPythonInterpreter(pythonInterpreter)
            .WithFileManager(fileManager)
            .Build();

        app.Run();
    }
}