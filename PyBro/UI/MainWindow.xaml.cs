using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using Mono.Unix;
using PyBro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static IronPython.Modules._ast;

namespace PyBro.UI
{
    public partial class MainWindow : Window
    {
        private string _currentFilePath = null;

        public MainWindow()
        {
            InitializeComponent();
            txtEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
        }

        /// <summary>
        /// Retrieves the entire current text content from the editor.
        /// </summary>
        /// <returns>A string representing the source code in the editor.</returns>
        public string GetBuffer()
        {
            return txtEditor.Text;
        }

        /// <summary>
        /// Executes the Python code from the editor using the interpreter, displays the result in the console, 
        /// and saves the current script.
        /// </summary>
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            FileManager fileManager = new FileManager();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Python files (*.py)|*.py|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".py";
            saveFileDialog.AddExtension = true;

            string runScript = txtEditor.Text;
            string path = null;

            if (string.IsNullOrWhiteSpace(runScript))
            {
                txtConsole.Text = "Scrie cod!"; 
                return;
            }

            var interpreter = new PyBro.PythonInterpreter();
            (string output, string error) = interpreter.RunScript(runScript);
            txtConsole.Clear();

            if (!string.IsNullOrEmpty(error))
            {
                txtConsole.AppendText(error);
            }
            else
            {
                txtConsole.AppendText(output);
            }

            if (_currentFilePath != null)
                path = _currentFilePath;
            else
            {
                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    path = saveFileDialog.FileName;
                    _currentFilePath = saveFileDialog.FileName;
                }
            }
            fileManager.SaveBuffer(path, runScript);
        }

        /// <summary>
        /// Opens a dialog to select a local file and loads its content into the editor.
        /// </summary>
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool? result = fileDialog.ShowDialog();
            FileManager fileManager = new FileManager();

            if (result == true)
            {
                try
                {
                    string loadedScript;
                    string filePath = fileDialog.FileName;
                    _currentFilePath = filePath;
                    loadedScript = fileManager.GetFileContent(filePath);
                    txtEditor.Text = loadedScript;
                }
                catch (FileException ex)
                {
                    MessageBox.Show($"Could not save the file! \nDetails: {ex.Message}",
                        "Save Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    txtConsole.AppendText($"\n[CRITICAL] Unexpected error: {ex.Message}");
                }
            }
            txtEditor.Focus();
        }

        /// <summary>
        /// Saves the editor content to the current file or opens a save dialog 
        /// if the file has not been saved previously.
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            FileManager fileManager = new FileManager();
            saveFileDialog.Filter = "Python files (*.py)|*.py|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".py";
            saveFileDialog.AddExtension = true;

            string scriptToSave = txtEditor.Text;
            string path = null;

            if (_currentFilePath != null)
                path = _currentFilePath;
            else
            {
                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    path = saveFileDialog.FileName;
                    _currentFilePath = saveFileDialog.FileName;
                }
                else
                    return;
            }

            try
            {
                fileManager.SaveBuffer(_currentFilePath, scriptToSave);
                txtConsole.AppendText("\n[INFO] Save successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save error: " + ex.Message);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (WindowState == WindowState.Normal)
                    WindowState = WindowState.Maximized;
                else
                    WindowState = WindowState.Normal;
            
            return;
            }

            if (e.LeftButton == MouseButtonState.Pressed && WindowState == WindowState.Normal)
            {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Recursively builds the file tree starting from a root directory 
        /// and sets it as the data source for the File Explorer.
        /// </summary>
        /// <param name="path">The absolute path to the selected folder.</param>
        private void LoadFolder(string path)
        {
            if (Directory.Exists(path))
            {
                var rootFolder = new FileItem
                {
                    Name = System.IO.Path.GetFileName(path),
                    Path = path,
                    IconKind = "Folder",
                    IconColor = Brushes.Orange,
                    Children = TreeDir.BuildFileTree(path)
                };

                fileExplorer.ItemsSource = new List<FileItem> { rootFolder };
            }
        }

        /// <summary>
        /// Handles the selection of a new item in the file tree. 
        /// If the item is a file, it loads its content into the editor.
        /// </summary>
        private void fileExplorer_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = e.NewValue as FileItem;
            if (selectedItem != null && !selectedItem.IsDirectory)
            {
                try
                {
                    FileManager fm = new FileManager();
                    txtEditor.Text = fm.GetFileContent(selectedItem.Path);
                    _currentFilePath = selectedItem.Path;
                    this.Title = $"PyBro - {selectedItem.Name}";
                }
                catch (Exception ex)
                {
                    txtConsole.AppendText("\n[ERROR] " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Opens a dialog to select a working directory and populates the file explorer.
        /// </summary>
        private void btnSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFolderDialog();
            dialog.Title = "Select folder";

            if (dialog.ShowDialog() == true)
            {
                string selectedPath = dialog.FolderName;

                LoadFolder(selectedPath);
                btnSelectFolder.Visibility = Visibility.Collapsed;
                fileExplorer.Visibility = Visibility.Visible;
            }
        }
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWin = new HelpWindow();
            helpWin.Owner = this; 
            helpWin.ShowDialog(); 
        }


    }
}