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

}
