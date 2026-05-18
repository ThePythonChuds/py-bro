/*
 * Project: PyBro
 * File: Application.cs
 * Authors: Filip Robert - Andrei, Beligan Tudor, Modreanu Stefan, Pinzaru Alexandru - Gabriel
 *
 * Description:
 * This file contains the Application class, which is responsible for
 * initializing the WPF application and starting the main controller update loop.
 */

using System.Windows.Threading;

using PyBro.Contracts;
using PyBro.UI;

namespace PyBro {

    /// <summary>
    /// Represents the main entry point of the application.
    /// This class connects the model, view, and controller, then starts the WPF interface.
    /// </summary>
    internal class Ide(IModel model, IView view, IController controller)
    {

        private System.Windows.Application _app = new System.Windows.Application();

        private IModel _model = model;

        private IView _view = view;

        private IController _controller = controller;

        private bool _isRunning = true;

        /// <summary>
        /// Starts the application, connects the controller to the update loop,
        /// and displays the main window.
        /// </summary>
        [System.STAThreadAttribute]
        public void Run()
        {

            this.HookControllerTick();

            _app.Run(new MainWindow());
        }

        /// <summary>
        /// Creates a timer that periodically calls the controller's Tick method.
        /// If Tick returns false, the application is shut down.
        /// </summary>
        private void HookControllerTick() {

            var timer = new DispatcherTimer();
            
            timer.Interval = new TimeSpan(0, 0, 0, 0, 16); // NOTE: Tickurile de update se aplica la intervale de 16ms

            timer.Tick += (_, _) => {
                _controller.Tick();
            };

            timer.Start();
        }
    }
}
