using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro
{
    public class CommandQueue<T> where T :class, ICommand
    {
        private static Queue<T> _commands = new Queue<T>();
        public static void PushCommand(T command)
        {
            _commands.Enqueue(command);
        }
        public static T? PopCommand()
        {
            if(_commands.Count() == 0)
            {
                return null;
            }
            return _commands.Dequeue();

        }


    }
}
