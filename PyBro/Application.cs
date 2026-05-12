namespace PyBro {
    public class Application {

        private Model _model;

        private View _view;

        private Controller _controller;

        private bool _isRunning;

        public Application()
        {
            _isRunning = true;

            // Initializare componente MVC
            _model      = new Model();
            _view       = new View();
            _controller = new Controller(_model, _view);

        }

        [System.STAThreadAttribute]
        public void RunMainLoop()
        {
            var app = new System.Windows.Application();

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMiliseconds(16);

            timer.Tick += (_, _) => {
                _isRunning = _controller.Tick();
                if (!_isRunning) {
                    app.Shutdown();
                }
            }
            timer.Start();

            app.Run(new PyBro.UI.MainWindow());
        }
    }
}
