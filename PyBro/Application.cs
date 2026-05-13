using System;
using System.Windows.Threading;
namespace PyBro {

    public class Application {

        private System.Windows.Application _app;

        private Model _model;

        private View _view;

        private Controller _controller;

        private bool _isRunning;


        public Application()
        {
            // NOTE: _app trebuie sa fie initializat inaintea celorlalte componente MVC
            _app = new System.Windows.Application();
            
            _isRunning = true;

            // Initializare componente MVC
            _model      = new Model();
            _view       = new View();
            _controller = new Controller(_model, _view);
        }


        [System.STAThreadAttribute]
        public void Run()
        {

            this.HookControllerTick();

            _app.Run(new PyBro.UI.MainWindow());
        }

        private void HookControllerTick() {

            var timer = new DispatcherTimer();
            
            timer.Interval = new TimeSpan(0, 0, 0, 0, 16); // NOTE: Tickurile de update se aplica la intervale de 16ms

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
