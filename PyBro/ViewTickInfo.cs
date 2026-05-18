using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro
{
    public class ViewTickInfo
    {
        public string TextBuffer { get; private set; }

        public ViewTickInfo(string buffer)
        {
            TextBuffer = buffer;
        }
    }
}
