using PyBro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.UI
{
    public class UiAdapter : IUiAdapter
    {
        private readonly MainWindow _window;
        public UiAdapter()
        {
            _window = (MainWindow)System.Windows.Application.Current.MainWindow;
        }

        public string GetTextBufferContent()
        {
            return _window.GetTextBufferContent();
        }

        public void UpdateBuffer(string bufferContent)
        {
            _window.SetTextBufferContent(bufferContent);
        }

        public void SendCommandToModel(IModelCommand cmd)
        {

        }

        public void DisplayOutput(string stdout, string stderr)
        {
            _window.DisplayOutput(stdout, stderr);
        }

        public void DisplayError(string errorMessage)
        {
            _window.DisplayError(errorMessage);
        }

        public void UpdateTitle(string newTitle)
        {
            _window.UpdateTitle(newTitle);
        }
    }
}
