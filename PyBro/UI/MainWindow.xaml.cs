using Microsoft.Win32;
using Mono.Unix;
using PyBro;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
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
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            FileManager fileManager = new FileManager();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Python files (*.py)|*.py|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".py";
            saveFileDialog.AddExtension = true;
            string runScript = txtEditor.Text;
            string highlightText = txtEditor.SelectedText;
            string path = null;
            if (string.IsNullOrWhiteSpace(runScript))
            {
                txtConsole.Text = "Scrie ceva cod Python mai întâi!";
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

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool ? result = fileDialog.ShowDialog();
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
                    MessageBox.Show($"Nu am putut salva fișierul! \nDetalii: {ex.Message}",
                        "Eroare Salvare",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    txtConsole.AppendText($"\n[CRITICAL] Eroare neașteptată: {ex.Message}");
                }
            }
          txtEditor.Focus();
          txtEditor.CaretIndex = txtEditor.Text.Length;

        }

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
                txtConsole.AppendText("\n[INFO] Salvare reușită.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la salvare: " + ex.Message);
            }


        }
    }
}

