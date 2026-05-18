using PyBro.UI;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Automation.Peers;
using PyBro.Contracts;
using PyBro.Commands;

namespace PyBro.MVC
{
    public class View : IView
    {
        private IUiAdapter _ui;
        private ITreeDir _treeDir;

        public View(IUiAdapter ui, ITreeDir treeDir)
        {
            _ui = ui;
            _treeDir = treeDir;
        }

        public void ExecuteCommands()
        {
            for (var cmd = MessageQueues.ReceiveViewCommand(); cmd != null; cmd = MessageQueues.ReceiveViewCommand())
            {
                ResolveCommand(cmd);
            }
        }

        private void ResolveCommand(IViewCommand cmd)
        {
            switch (cmd)
            {
                case ViewCommandDisplayPythonError displayErrorCmd:
                    {
                        displayErrorCmd.Execute(new object[] { _ui });
                        break;
                    }

                case ViewCommandRewriteActiveBuffer rewriteBufferCmd:
                    {
                        rewriteBufferCmd.Execute(new object[] { _ui });
                        break;
                    }

                case ViewCommandSendOutputToConsole sendOutputCmd:
                    {
                        sendOutputCmd.Execute(new object[] { _ui });
                        break;
                    }

                case ViewCommandUpdateTitle updateTitleCmd:
                    {
                        updateTitleCmd.Execute(new object[] { _ui });
                        break;
                    }

                default:
                    {
                        throw new InvalidOperationException($"Unknown command type: {cmd.GetType().Name}");
                    }
            }
        }
    }
}
