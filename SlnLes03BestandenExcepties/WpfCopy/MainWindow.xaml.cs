using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace WpfCopyVs2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string info;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnChoice_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
            string chosenFileName;
            if (dialog.ShowDialog() == true)
            {
                // user picked a file and pressed OK
                chosenFileName = dialog.FileName;
                txtbIn.Text = chosenFileName;
                btnGo.IsEnabled = true;
                info = File.ReadAllText(chosenFileName);
            }
            else
            {
                // user cancelled or escaped dialog window
            }

        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
            dialog.FileName = "savedfile.txt";
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, info);
            }
            else
            {
                // user pressed Cancel or escaped dialog window
            }
        }
    }
}
