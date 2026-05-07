namespace PyBro {
    public interface ICodeManager {
        public void PushBufferChangeEvent(IBufferChangeEvent e);
        public IBufferChangeEvent PopBufferChangeEvent();

        public void ProcessBufferChangeEvent(IBufferChangeEvent e); 
    }
}