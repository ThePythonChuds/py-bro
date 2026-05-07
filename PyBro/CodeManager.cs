using System.Collections.Generic;

namespace PyBro
{
    class CodeManager : ICodeManager
    {
        Stack<IBufferChangeEvent> stack = null;

        public CodeManager() {
            stack = new Stack<IBufferChangeEvent>();
        }

        public override void PushBufferChangeEvent(IBufferChangeEvent e) {
            stack.Push(e);
        }
        
        public override IBufferChangeEvent PopBufferChangeEvent() {
            return stack.Pop();
        }

        public override void ProcessBufferChangeEvent(IBufferChangeEvent e) {
            // TODO: implementeaza Alex
        }
    }
}