namespace PyBro {
    public interface IBufferManager {
        public void PushBufferChangeEvent(IBufferChangeEvent e);
        public IBufferChangeEvent PopBufferChangeEvent();
        public IBuffer GetBuffer();
        public void ProcessBufferChangeEvent(IBufferChangeEvent e); 
    }
}