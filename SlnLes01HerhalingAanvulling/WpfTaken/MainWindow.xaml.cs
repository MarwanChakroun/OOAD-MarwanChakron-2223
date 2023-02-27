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

namespace WpfTaken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stack<ListBoxItem> deletedItems = new Stack<ListBoxItem>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            bool a = CheckForm();
            if (a == true)
            {
                AddTaak();
            }
        }

        public bool CheckForm()
        {
            tblck_fouten.Text = "";
            bool a = true;
            if (string.IsNullOrEmpty(tbx_taak.Text)) { tblck_fouten.Text += $"Gelieve een taak in te voeren\n"; a = false; }
            if (dtDeadline.SelectedDate == null) { tblck_fouten.Text += $"Gelieve een datum te kieen\n"; a = false; }
            if (cmbPrio.SelectedItem == null) { tblck_fouten.Text += $"Gelieve een prioriteit te kieen\n"; a = false; }
            if (rbAdam.IsChecked == false && rbBilal.IsChecked == false && rbChelsey.IsChecked == false) { tblck_fouten.Text += $"Gelieve een uitvoerder te kieen\n"; a = false; }
            return a;
        }

        public void AddTaak()
        {
            ListBoxItem taal = new ListBoxItem();
            string voornaam = uitvoerder();
            string deadline = dtDeadline.SelectedDate.Value.ToString("dd/MM/yyyy");
            switch (cmbPrio.Text)
            {
                case "hoog":
                    taal.Background = Brushes.Red;
                    break;
                case "normaal":
                    taal.Background = Brushes.Orange;
                    break;
                case "laag":
                    taal.Background = Brushes.Yellow;
                    break;
            }
            taal.Content = $"{tbx_taak.Text} (deadline: {deadline} door: {voornaam})";
            lbx_taken.Items.Add(taal);
        }

        public string uitvoerder()
        {
            string a = "";
            if (rbAdam.IsChecked == true) { a = "Adam"; }
            if (rbBilal.IsChecked == true) { a = "Bilal"; }
            if (rbChelsey.IsChecked == true) { a = "Chelsey"; }
            return a;
        }

        private void lbx_taken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_verwijderen.IsEnabled = true;
        }

        private void btn_verwijderen_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)lbx_taken.SelectedItem;
            deletedItems.Push(selectedItem);
            lbx_taken.Items.Remove(lbx_taken.SelectedItem);
            btn_terugzetten.IsEnabled = true;
        }

        private void btn_terugzetten_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem deletedItem = deletedItems.Pop();
            lbx_taken.Items.Add(deletedItem);
            btn_terugzetten.IsEnabled = false;
        }

        private void tbx_taak_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
