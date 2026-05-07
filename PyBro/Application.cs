namespace PyBro {
    public class Application {
        private bool _isRunning = true;
        public Application() {}

        public void RunMainLoop()
        {
            while(_isRunning) {}
        }
    }
}