namespace PyBro {
    public interface IConsole {
        public void ExecBufferChangeEvent(IBufferChangeEvent e);
        public void SendOutputToConsole(); // TODO: da ti seama ce e cu asta!
    }
}