
namespace PyBro
{
    public class UpdateViewBufferCommand : IPyBroViewCommand
    {
        public string BufferContent { get; private set; }

        public void Execute(IUi ui, ITreeDir treeDir)
        {
            ui.UpdateBuffer(BufferContent);
        }
    }
}