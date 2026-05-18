using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.Contracts
{
    public interface IUiAdapter
    {
        string GetTextBufferContent();

        void UpdateBuffer(string bufferContent);

        void SendCommandToModel(IModelCommand cmd);

        void DisplayOutput(string stdout, string stderr);

        void DisplayError(string errorMessage);
        void UpdateTitle(string newTitle);
    }
}
