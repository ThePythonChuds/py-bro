using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro
{
    public class ModelTickInfo
    {
        public string OutputToConsole { get; set; } = "";
        public string ErroredToConsole { get; set; } = "";
        public bool ShouldExit { get; set; }
        public string BufferContent { get; set; } = "";

        public List<IPyBroViewCommand>? Commands { get; set; } = null;
        public ModelTickInfo()
        {

        }
    }

    public interface IPyBroViewCommand
    {
        void Execute(IUi ui, ITreeDir treeDir);
    }

    public class UpdateViewBufferCommand : IPyBroViewCommand
    {
        public string BufferContent { get; private set; }
        
        public void Execute(IUi ui, ITreeDir treeDir)
        {
            ui.UpdateBuffer(BufferContent);
        }
    }
}
