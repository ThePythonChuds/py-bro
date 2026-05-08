namespace PyBro {
    public interface IKeyboardMouseListener {
        public void GetUpdate(IKeyboardMouseEvent e);
    }

    public class KeyboardMouseListener : IKeyboardMouseListener {

        public KeyboardMouseListener();
        public void GetUpdate(IKeyboardMouseEvent e)
        {
            if (e.EType == EventType.KeyPressed)
            {
                // TODO: vedem
            }

            if(e.EType == EventType.MouseClick)
            {
                // TODO: vedem
            }
        }
    }
}