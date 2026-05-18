/*
 * Project: PyBro
 * File: ApplicationBuilder.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the ApplicationBuilder class, which is responsible for
 * building and configuring the main application object using the Builder design pattern.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyBro.Contracts;
using PyBro.MVC;

namespace PyBro
{
    /// <summary>
    /// Builds and configures the main application object.
    /// This class uses the Builder design pattern to provide the required dependencies
    /// before creating the final Application instance.
    /// </summary>
    class ApplicationBuilder
    {

        private IPythonInterpreter? pythonInterpereter = null;

        /// <summary>
        /// Sets the Python interpreter dependency required by the application.
        /// </summary>
        /// <param name="pi">The Python interpreter implementation.</param>
        /// <returns>The current builder instance, allowing chained method calls.</returns>
        public ApplicationBuilder WithPythonInterpreter(IPythonInterpreter pi)
        {
            pythonInterpereter = pi;
            return this;
        }


        private IFileManager? fileManager = null;

        /// <summary>
        /// Sets the file manager dependency required by the application.
        /// </summary>
        /// <param name="fm">The file manager implementation.</param>
        /// <returns>The current builder instance, allowing chained method calls.</returns>
        public ApplicationBuilder WithFileManager(IFileManager fm)
        {
            fileManager = fm;
            return this;
        }

        private IUiAdapter? _uiAdapter = null;

        public ApplicationBuilder WithUiAdapter(IUiAdapter uiAdapter)
        {
            _uiAdapter = uiAdapter;
            return this;
        }

        private ITreeDir? _treeDir = null;

        public ApplicationBuilder WithTreeDir(ITreeDir treeDir)
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
        public Application Build()
        {
            if (pythonInterpereter == null)
            {
                throw new InvalidOperationException("PythonInterpreter is required to build the application.");
            }
            if (fileManager == null)
            {
                throw new InvalidOperationException("FileManager is required to build the application.");
            }
            // TODO: Add checks for other dependencies like _uiAdapter and _treeDir if they are required for the application to function properly.

            var model = new Model(pythonInterpereter, fileManager);
            var view = new View(_uiAdapter, _treeDir);
            var controller = new Controller(model, view);
            return new Application(model, view, controller);
        }
    }
}
