namespace PyBro {
    public interface IBufferChangeEvent {
        
    }

    public class WriteCommand : IBufferChangeEvent {
        public String Info {get; private set;}
        public Coords Position {get; private set;}
    }

    public class DeleteCommand : IBufferChangeEvent {
        public String Info {get; private set;}
        public Coords Position {get; private set;}
        public uint Len {get; private set;}
    }
}