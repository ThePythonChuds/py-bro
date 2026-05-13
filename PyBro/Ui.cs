using PyBro.UI;
using System;
namespace PyBro
{
    public class Ui : IUi
    {
        private MainWindow _mainWindow;
        public Ui()
        {
            //System.Windows.Application.Current.Dispatcher.Invoke(() =>
            //{
                _mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
            //});
        }

        public string GetBuffer()
        {
            return _mainWindow.GetBuffer();
        }

        public (Coords?, Coords?) GetHighlightCoords()
        {
            return (null, null);
        }

        public void SaveFile(string path) { }
        public void CreateFile(string path) { }
        public void OpenFile(string path) { }
        public void RemoveFile(string path) { }
        public void Refresh() { }
        public void RunScript() { }
    }
}