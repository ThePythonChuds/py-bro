using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.Contracts
{
    public class MessageQueues
    {
        private static readonly ConcurrentQueue<IModelCommand> _viewToModelCommandQueue = new ConcurrentQueue<IModelCommand>();
        private static readonly ConcurrentQueue<IViewCommand> _modelToViewCommandQueue = new ConcurrentQueue<IViewCommand>();

        public static void SendModelCommand(IModelCommand cmd)
        {
            _viewToModelCommandQueue.Enqueue(cmd);
        }

        public static IModelCommand? ReceiveModelCommand()
        {
            if (_viewToModelCommandQueue.Count == 0)
            {
                return null;
            }

            if (_viewToModelCommandQueue.TryDequeue(out var item))
            {
                return item;
            }
            return null;
        }

        public static void SendViewCommand(IViewCommand cmd)
        {
            _modelToViewCommandQueue.Enqueue(cmd);
        }

        public static IViewCommand? ReceiveViewCommand()
        {
            if (_modelToViewCommandQueue.Count == 0)
            {
                return null;
            }
            if (_modelToViewCommandQueue.TryDequeue(out var item))
            {
                return item;
            }

            return null;
        }
    }
}
