using System.Collections.Generic;

namespace PyBro
{
    class BufferManager : IBufferManager
    {
        Stack<IBufferChangeEvent> buffer = null;

        public BufferManager() {
            buffer = new Stack<IBufferChangeEvent>();
        }

        public override void PushBufferChangeEvent(IBufferChangeEvent e) {
            buffer.Push(e);
        }
        
        public override IBufferChangeEvent PopBufferChangeEvent() {
            return buffer.Pop();
        }

        public override void ProcessBufferChangeEvent(IBufferChangeEvent e) {
            // TODO: implementeaza Alex
        }
    }
}