/*
 * Project: PyBro
 * File: ApplicationBuilder.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the ApplicationBuilder class, which is responsible for
 * building and configuring the main application object using the Builder design pattern.
 */

using PyBro.Contracts;
using PyBro.MVC;
using PyBro.UI;

namespace PyBro.IDE
{
    /// <summary>
    /// Builds and configures the main application object.
    /// This class uses the Builder design pattern to provide the required dependencies
    /// before creating the final Application instance.
    /// </summary>
    internal class IdeBuilder
    {

        private System.Windows.Application _app;
        public IdeBuilder WithApp(System.Windows.Application app)
        {
            _app = app;
            return this;
        }

        private MainWindow _mainWindow;
        public IdeBuilder WithMainWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            return this;
        }

        private IPythonInterpreter? _pythonInterpereter = null;

        /// <summary>
        /// Sets the Python interpreter dependency required by the application.
        /// </summary>
        /// <param name="pi">The Python interpreter implementation.</param>
        /// <returns>The current builder instance, allowing chained method calls.</returns>
        public IdeBuilder WithPythonInterpreter(IPythonInterpreter pi)
        {
            _pythonInterpereter = pi;
            return this;
        }


        private IFileManager? _fileManager = null;

        /// <summary>
        /// Sets the file manager dependency required by the application.
        /// </summary>
        /// <param name="fm">The file manager implementation.</param>
        /// <returns>The current builder instance, allowing chained method calls.</returns>
        public IdeBuilder WithFileManager(IFileManager fm)
        {
            _fileManager = fm;
            return this;
        }

        private IUiAdapter? _uiAdapter = null;

        public IdeBuilder WithUiAdapter(IUiAdapter uiAdapter)
        {
            _uiAdapter = uiAdapter;
            return this;
        }

        private ITreeDir? _treeDir = null;

        public IdeBuilder WithTreeDir(ITreeDir treeDir)
        {
            _treeDir = treeDir;
            return this;
        }

        /// <summary>
        /// Creates the final Application instance after all required dependencies are provided.
        /// </summary>
        /// <returns>A fully configured Application object.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when a required dependency has not been configured.
        /// </exception>
        public Ide Build()
        {
            if (_app == null)
            {
                throw new InvalidOperationException("Application is required to build the application.");
            }

            if (_pythonInterpereter == null)
            {
                throw new InvalidOperationException("PythonInterpreter is required to build the application.");
            }

            if (_fileManager == null)
            {
                throw new InvalidOperationException("FileManager is required to build the application.");
            }

            if (_uiAdapter == null)
            {
                throw new InvalidOperationException("UiAdapter is required to build the application.");
            }

            if (_treeDir == null)
            {
                throw new InvalidOperationException("TreeDir is required to build the application.");
            }

            if (_mainWindow == null)
            {
                throw new InvalidOperationException("MainWindow is required to build the application.");
            }

            var model = new Model(_pythonInterpereter, _fileManager);
            var view = new View(_uiAdapter, _treeDir);
            var controller = new Controller(model, view);
            return new Ide(model, view, controller, _app);
        }
    }
}
