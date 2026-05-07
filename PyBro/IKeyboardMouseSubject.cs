namespace PyBro {
    public interface IKeyboardMouseSubject {
       public void UpdateListeners(IKeyboardMouseEvent e);
       public void AddListener(IKeyboardMouseListener l); 
    }
}