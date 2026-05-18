
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPyBroCommand {
        void Execute(object[] args);
    }

    public class CreateBufferCommand : IPyBroCommand
    {
        public string FileName { get; private set; }
        public string BufferContent { get; set; }

        public CreateBufferCommand(string fileName, string bufferContent)
        {
            FileName = fileName;
            BufferContent = bufferContent;
        }

        public void Execute(object[] args)
        {
            throw new NotImplementedException();
        }
    }
    public class SwitchActiveBufferCommand(string fileName) : IPyBroCommand
    {
        public string FileName { get; private set; } = fileName;

        public void Execute(object[] args)
        {
            throw new NotImplementedException();
        }
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
            Commands ??= [];
            Commands.Add(command);
        }
    }
}
