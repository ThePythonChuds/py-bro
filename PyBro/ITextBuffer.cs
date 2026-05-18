using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro
{
    public interface ITextBuffer
    {
        (UInt32, string) GetCurrentIndentInfo();

        void Autoindent();

        void AddLine(string line);

        void SetContent(string content);

        string GetContent();
    }
}
