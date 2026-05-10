using Xunit;
using PyBro;
using System.IO;

namespace PyBro.Tests
{
    public class FileManagerTests
    {
        private readonly FileManager _fm = new FileManager();
        private readonly string _testDir = Path.Combine(Path.GetTempPath(), "PyBroTests");

        private string TempFile(string name) => Path.Combine(_testDir, name);

        public FileManagerTests()
        {
            Directory.CreateDirectory(_testDir);
        }

        [Fact]
        public void CreateFile_CreatesFileOnDisk()
        {
            var path = TempFile("test1.py");
            _fm.CreateFile(path);
            Assert.True(File.Exists(path));
            File.Delete(path);
        }

        [Fact]
        public void CreateFile_EmptyFile_HasNoContent()
        {
            var path = TempFile("test2.py");
            _fm.CreateFile(path);
            Assert.Equal("", File.ReadAllText(path));
            File.Delete(path);
        }

        [Fact]
        public void CreateFile_InvalidPath_ThrowsFileException()
        {
            Assert.Throws<FileException>(() => _fm.CreateFile("Z:\\invalid\\path\\file.py"));
        }

        [Fact]
        public void SaveBuffer_WritesContentToFile()
        {
            var path = TempFile("test3.py");
            _fm.SaveBuffer(path, "print('hello')");
            Assert.Equal("print('hello')", File.ReadAllText(path));
            File.Delete(path);
        }

        [Fact]
        public void SaveBuffer_OverwritesExistingContent()
        {
            var path = TempFile("test4.py");
            _fm.SaveBuffer(path, "first");
            _fm.SaveBuffer(path, "second");
            Assert.Equal("second", File.ReadAllText(path));
            File.Delete(path);
        }

        [Fact]
        public void SaveBuffer_CreatesFileIfNotExists()
        {
            var path = TempFile("test5.py");
            if (File.Exists(path)) File.Delete(path);
            _fm.SaveBuffer(path, "content");
            Assert.True(File.Exists(path));
            File.Delete(path);
        }

        [Fact]
        public void SaveBuffer_CreatesDirectoryIfNotExists()
        {
            var path = TempFile("subdir\\test6.py");
            _fm.SaveBuffer(path, "x");
            Assert.True(File.Exists(path));
            File.Delete(path);
        }

        [Fact]
        public void SaveBuffer_EmptyContent_WritesEmptyFile()
        {
            var path = TempFile("test7.py");
            _fm.SaveBuffer(path, "");
            Assert.Equal("", File.ReadAllText(path));
            File.Delete(path);
        }

        [Fact]
        public void SaveBuffer_MultilineContent_SavedCorrectly()
        {
            var path = TempFile("test8.py");
            var content = "line1\nline2\nline3";
            _fm.SaveBuffer(path, content);
            Assert.Equal(content, File.ReadAllText(path));
            File.Delete(path);
        }

        [Fact]
        public void GetFileContent_ReturnsCorrectContent()
        {
            var path = TempFile("test9.py");
            File.WriteAllText(path, "hello world");
            Assert.Equal("hello world", _fm.GetFileContent(path));
            File.Delete(path);
        }

        [Fact]
        public void GetFileContent_EmptyFile_ReturnsEmptyString()
        {
            var path = TempFile("test10.py");
            File.WriteAllText(path, "");
            Assert.Equal("", _fm.GetFileContent(path));
            File.Delete(path);
        }

        [Fact]
        public void GetFileContent_NonexistentFile_ThrowsFileException()
        {
            Assert.Throws<FileException>(() => _fm.GetFileContent(TempFile("nonexistent.py")));
        }

        [Fact]
        public void GetFileContent_MultilineFile_ReturnsAll()
        {
            var path = TempFile("test11.py");
            var content = "a\nb\nc";
            File.WriteAllText(path, content);
            Assert.Equal(content, _fm.GetFileContent(path));
            File.Delete(path);
        }

        [Fact]
        public void RemoveFile_DeletesFile()
        {
            var path = TempFile("test12.py");
            File.WriteAllText(path, "x");
            _fm.RemoveFile(path);
            Assert.False(File.Exists(path));
        }

        [Fact]
        public void RemoveFile_NonexistentFile_ThrowsFileException()
        {
            Assert.Throws<FileException>(() => _fm.RemoveFile(TempFile("ghost.py")));
        }

        [Fact]
        public void SaveBuffer_ThenGetFileContent_ReturnsSameContent()
        {
            var path = TempFile("test13.py");
            _fm.SaveBuffer(path, "test content");
            Assert.Equal("test content", _fm.GetFileContent(path));
            File.Delete(path);
        }

        [Fact]
        public void CreateFile_ThenRemoveFile_FileNoLongerExists()
        {
            var path = TempFile("test14.py");
            _fm.CreateFile(path);
            _fm.RemoveFile(path);
            Assert.False(File.Exists(path));
        }

        [Fact]
        public void SaveBuffer_SpecialCharacters_SavedCorrectly()
        {
            var path = TempFile("test15.py");
            var content = "print('ăîșțâ')";
            _fm.SaveBuffer(path, content);
            Assert.Equal(content, _fm.GetFileContent(path));
            File.Delete(path);
        }

        [Fact]
        public void SaveBuffer_LargeContent_SavedCorrectly()
        {
            var path = TempFile("test16.py");
            var content = new string('x', 100000);
            _fm.SaveBuffer(path, content);
            Assert.Equal(content.Length, _fm.GetFileContent(path).Length);
            File.Delete(path);
        }

        [Fact]
        public void CreateFile_CalledTwice_DoesNotThrow()
        {
            var path = TempFile("test17.py");
            _fm.CreateFile(path);
            var ex = Record.Exception(() => _fm.CreateFile(path));
            Assert.Null(ex);
            File.Delete(path);
        }

        [Fact]
        public void GetFileContent_AfterSaveBuffer_ReturnsUpdatedContent()
        {
            var path = TempFile("test18.py");
            _fm.SaveBuffer(path, "v1");
            _fm.SaveBuffer(path, "v2");
            Assert.Equal("v2", _fm.GetFileContent(path));
            File.Delete(path);
        }
    }
}