using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro
{

    public interface IPyBroCommand {
    
    }

    public class ViewTickInfo
    {
        public string TextBuffer { get; private set; }
        public List<IPyBroCommand>? Commands { get; set; } = null;
        public ViewTickInfo(string buffer)
        {
            TextBuffer = buffer;
        }

        public void AddCommand(IPyBroCommand command)
        {
            if (Commands == null)
            {
                Commands = new List<IPyBroCommand>();
            }
            Commands.Add(command);
        }
    }
}
