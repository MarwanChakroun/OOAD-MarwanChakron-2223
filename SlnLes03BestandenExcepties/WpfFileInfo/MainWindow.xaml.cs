using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfFileInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string inhoud = null;
        string fileName;
        int len = 0;
        int quantity = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnChoice_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Tekstbestanden|.TXT;.TEXT";

            if (dialog.ShowDialog() == true)
            {

                fileName = dialog.FileName;
                using (StreamReader reader = File.OpenText(fileName))
                {

                    inhoud = reader.ReadToEnd();

                    for (int i = 0; i < inhoud.Length; i++)
                    {
                        if (inhoud[len] == ' ' || inhoud[len] == '\t' || inhoud[len] == '\n')
                        {
                            quantity = quantity + 1;
                        }

                        len = len + 1;
                    }


                    FileInfo info = new FileInfo(fileName);
                    lblBestand.Content = info.Name;
                    lblWoorden.Content = quantity;
                    lblExtensie.Content = System.IO.Path.GetExtension(fileName);
                    lblGemaakt.Content = File.GetCreationTime(fileName);
                    lblMapnaam.Content = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(fileName));
                }

            }
        }
    }
}

