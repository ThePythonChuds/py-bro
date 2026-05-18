/*
 * Project: PyBro
 * File: Program.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the Program class, which represents the starting point
 * of the application.
 */

using PyBro;

class Program
{
    /// <summary>
    /// Starts the PyBro application by building all required components and running it.
    /// </summary>
    /// <param name="args">Command-line arguments passed to the application.</param>
    [System.STAThreadAttribute]
    public static void Main(string[] args)
    {
        var app = new ApplicationBuilder()
            .WithPythonInterpreter(new PythonInterpreter())
            .WithFileManager(new FileManager())
            .Build();

        app.Run();
    }
}