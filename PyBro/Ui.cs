namespace PyBro
{
    public class Ui : IUi
    {
        public Ui()
        {

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