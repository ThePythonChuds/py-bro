namespace PyBro{
    public interface IKeyboardMouseEvent {
        public EventType EType {get; private set;} // Event type (e.g. keyboard, mouse)
        public Coords CaretPosition; 
        public int KeyCode {get; private set;} // What key is pressed
    }

    public class KeyboardMouseEvent : IKeyboardMouseEvent {
        public KeyboardMouseEvent(EventType EType, Coords CaretPosition, int KeyCode)
        {
            this.EType = EType;
            this.CaretPosition = CaretPosition;
            this.KeyCode = KeyCode;
        }
    }
}