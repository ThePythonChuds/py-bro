/*
 * Project: PyBro
 * File: Controller.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the Controller class, which coordinates the communication
 * between the view and the model during each application update.
 */

namespace PyBro
{
    /// <summary>
    /// Controls the main application flow by passing data between the view and the model.
    /// </summary>
    public class Controller : IController
    {
        private Model _model;
        private View _view;

        /// <summary>
        /// Creates a controller using the provided model and view instances.
        /// </summary>
        /// <param name="model">The model that handles the application state and logic.</param>
        /// <param name="view">The view that handles user interface input and output.</param>
        public Controller(Model model, View view)
        {
            this._model = model;
            this._view = view;
        }

        /// <summary>
        /// Executes one update cycle of the application.
        /// </summary>
        /// <returns>
        /// True if the application should continue running; otherwise, false.
        /// </returns>
        public bool Tick()
        {
            var viewTickInfo = _view.PackViewTickInfo();
            var modelTickInfo = _model.ApplyTickInfo(viewTickInfo);
            _view.Show(modelTickInfo);

            return !modelTickInfo.ShouldExit;
        }
    }
}