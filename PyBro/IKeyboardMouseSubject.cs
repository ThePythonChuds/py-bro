using System.Collections.Generic;

namespace PyBro {
    public interface IKeyboardMouseSubject {
       public void UpdateListeners(IKeyboardMouseEvent e);
       public void AddListener(IKeyboardMouseListener l); 
       public void RemoveListener(IKeyboardMouseListener l);
    }

    public class KeyboardMouseSubject : IKeyboardMouseSubject {
        private List<IKeyboardMouseListener> listeners = new List<IKeyboardMouseListener>();

        public void UpdateListeners(IKeyboardMouseEvent e)
        {
            foreach (var listener in listeners)
            {
                listener.GetUpdate(e);
            }
        }

        public void AddListener(IKeyboardMouseListener l)
        {
            listeners.Add(l);
        }

        public void RemoveListener(IKeyboardMouseListener l)
        {
            listeners.Remove(l);
        }
    }
}