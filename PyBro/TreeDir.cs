using System;
using System.IO;
using System.Windows.Media;

namespace PyBro
{

	public class TreeDir : ITreeDir
	{

        public static List<FileItem> BuildFileTree(string directoryPath)
        {
            var items = new List<FileItem>();
            var dirInfo = new DirectoryInfo(directoryPath);

            try
            {
                foreach (var directory in dirInfo.GetDirectories())
                {
                    items.Add(new FileItem
                    {
                        Name = directory.Name,
                        Path = directory.FullName,
                        IconKind = "Folder",
                        IconColor = Brushes.Orange,
                        Children = BuildFileTree(directory.FullName)
                    });
                }

                foreach (var file in dirInfo.GetFiles("*.py"))
                {
                    items.Add(new FileItem
                    {
                        Name = file.Name,
                        Path = file.FullName,
                        IconKind = "LanguagePython",
                        IconColor = Brushes.SkyBlue
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return items;
        }


        public TreeDir()
		{
		}

        public void Refresh()
		{

		}
    }
}
