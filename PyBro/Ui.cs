using PyBro.UI;
using System;
namespace PyBro
{
    public class Ui : IUi
    {
        private MainWindow? MainWindow
        {
            get {
                if (_mainWindow == null)
                {
                    _mainWindow = (MainWindow)Application.Current.MainWindow;
                }
                return _mainWindow;
            }
        }

        public Ui()
        {
            this.MainWindow = null;
        }

        public string GetBuffer()
        {
            return this.MainWindow.GetBuffer();
        }

        public (Coords?, Coords?) GetHighlightCoords()
        {
            return (null, null); // TODO:
        }

        public void SaveFile(string path) { }
        public void CreateFile(string path) { }
        public void OpenFile(string path) { }
        public void RemoveFile(string path) { }
        public void Refresh() { }
        public void RunScript() { }
    }
}
