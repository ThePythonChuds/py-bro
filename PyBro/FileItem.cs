using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PyBro
{
    public class FileItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string IconKind { get; set; } 
        public Brush IconColor { get; set; }
        public List<FileItem> Children { get; set; } = new List<FileItem>();

        public bool IsDirectory => Children.Count > 0 || Directory.Exists(Path);
    }
}
