namespace PyBro {
    public interface IUi {
        public (Coords?, Coords?) GetHighlightCoords();
        public void SaveFile(string path);
        public void CreateFile(string path);
        public void OpenFile(string path);
        public void RemoveFile(string path);
        public void Refresh();
        public void RunScript();
    }
}