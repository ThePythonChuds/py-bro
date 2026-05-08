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

namespace PyBro.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            // Așa citești tot textul din editor
            string codulMeu = txtEditor.Text;
            string highlightText = txtEditor.SelectedText;
            if (string.IsNullOrWhiteSpace(codulMeu))
            {
                MessageBox.Show("Scrie ceva cod Python mai întâi!");
                return;
            }

            // Aici îl trimiți către logica ta de execuție
            // Exemplu: interpretor.Execute(codulMeu);
            txtConsole.AppendText(highlightText);
            txtConsole.AppendText($"\n[RUN]: Se execută {codulMeu} caractere...");
        }
    }
}

