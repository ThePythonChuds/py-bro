namespace PyBro {
    public class Application {
        private bool _isRunning = true;
        Application() {}

        public void RunMainLoop()
        {
            while(_isRunning) {}
        }
    }
}