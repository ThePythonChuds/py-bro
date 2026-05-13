using System;
using System.Windows.Threading;
namespace PyBro {

    public class Application {

        private Model _model;

        private View _view;

        private Controller _controller;

        private bool _isRunning;


        private System.Windows.Application _app;

        public Application()
        {
            _isRunning = true;

            // Initializare componente MVC
            _model      = new Model();
            _view       = new View();
            _controller = new Controller(_model, _view);
            _app = new System.Windows.Application();

        }

        [System.STAThreadAttribute]
        public void Run()
        {

            this.HookControllerTick();

            _app.Run(new PyBro.UI.MainWindow());
        }

        private void HookControllerTick() {

            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,0,16);

            timer.Tick += (_, _) => {
                _isRunning = _controller.Tick();
                if (!_isRunning) {
                    _app.Shutdown();
                }
            };

            timer.Start();
        }
    }
}
