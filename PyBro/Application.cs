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
            app.Run(new PyBro.UI.MainWindow());
            while (_isRunning) {
                _isRunning = _controller.Tick();

                // Filip: Optional, putem sa adaugam delay aici dar nu cred ca e cazul
            }
        }
    }
}