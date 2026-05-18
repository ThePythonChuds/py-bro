using System;
using System.Windows.Automation.Peers;
using System.Windows.Threading;
namespace PyBro {

    public class Application(IModel model, IView view, IController controller)
    {

        private System.Windows.Application _app = new System.Windows.Application();

        private IModel _model = model;

        private IView _view = view;

        private IController _controller = controller;

        private bool _isRunning = true;

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
