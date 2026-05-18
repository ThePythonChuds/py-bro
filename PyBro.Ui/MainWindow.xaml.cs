using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
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
using PyBro.Commands;
using PyBro.Contracts;

namespace PyBro.UI
{
    public partial class MainWindow : Window
    {
        public string? CurrentFile { get; private set; } = null;
        public MainWindow()
        {
            InitializeComponent();
            txtEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
        }

        /// <summary>
        /// Retrieves the entire current text content from the editor.
        /// </summary>
        /// <returns>A string representing the source code in the editor.</returns>
        public string GetTextBufferContent()
        {
            return txtEditor.Text;
        }

        /// <summary>
        /// Executes the Python code from the editor using the interpreter, displays the result in the console, 
        /// and saves the current script.
        /// </summary>
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Python files (*.py)|*.py|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".py";
            saveFileDialog.AddExtension = true;

            string script = txtEditor.Text;
            string path = null;

            if (string.IsNullOrWhiteSpace(script))
            {
                txtConsole.Text = "No code to run. Maybe you wanna print some hello worlds?"; 
                return;
            }


            var cmd = new ModelCommandRunPythonScript(script);
            MessageQueues.SendModelCommand(cmd);


            if (CurrentFile != null)
                path = CurrentFile;
            else
            {
                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    path = saveFileDialog.FileName;
                    CurrentFile = saveFileDialog.FileName;
                }
            }

            var sbc = new ModelCommandSaveBuffer(path, script);
            MessageQueues.SendModelCommand(sbc);
        }


        /// <summary>
        /// Opens a dialog to select a local file and loads its content into the editor.
        /// </summary>
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool? result = fileDialog.ShowDialog();

            if (result == true)
            {
                try
                {
                    string filePath = fileDialog.FileName;
                    CurrentFile = filePath;

                    var cmd = new ModelCommandLoadFile(filePath);
                    MessageQueues.SendModelCommand(cmd);
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
            saveFileDialog.Filter = "Python files (*.py)|*.py|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".py";
            saveFileDialog.AddExtension = true;

            string scriptToSave = txtEditor.Text;
            string path = null;

            if (CurrentFile != null)
                path = CurrentFile;
            else
            {
                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    path = saveFileDialog.FileName;
                    CurrentFile = saveFileDialog.FileName;
                }
                else
                    return;
            }

            var modelCmd = new ModelCommandSaveBuffer(path, scriptToSave);
            MessageQueues.SendModelCommand(modelCmd);
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
                    var modelCmd = new ModelCommandLoadFile(selectedItem.Path);
                    MessageQueues.SendModelCommand(modelCmd);

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


        private void txtEditor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        internal void SetTextBufferContent(string bufferContent)
        {
            txtEditor.Text = bufferContent;
        }

        internal void DisplayOutput(string stdout, string stderr)
        {
            txtConsole.Clear();

            if (!string.IsNullOrEmpty(stderr))
            {
                txtConsole.AppendText(stderr);
            }
            else
            {
                txtConsole.AppendText(stdout);
            }
        }

        internal void DisplayError(string errorMessage)
        {
            // Filip: O alta idee ar fi sa avem un TextBlock separat pentru erori, care sa aiba textul rosu, iar txtConsole sa fie doar pentru output normal. In felul asta nu amestecam erorile cu outputul normal si e mai usor de citit.
            // F: mi se pare asa crazy ca stie ai-ul din visual studio si ce vreau sa transmit prin mesaj.. Future is scary
            txtConsole.Clear();
            txtConsole.AppendText("\n[ERROR] " + errorMessage);
        }

        internal void UpdateTitle(string newTitle)
        {
            this.Title = newTitle;
        }
    }
}


    
