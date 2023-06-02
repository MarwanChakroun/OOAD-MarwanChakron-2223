using MyClassLibrary;
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

namespace WpfGebruiker
{
    /// <summary>
    /// Interaction logic for Voertuigen.xaml
    /// </summary>
    public partial class Voertuigen : Page
    {
        private readonly Foto fotoAuto = new Foto();
        private readonly auto autoRead = new auto();
        List<auto> autoList = new List<auto>();
        Gebruiker actualuser = new Gebruiker();
        public Voertuigen(Gebruiker gb)
        {
            InitializeComponent();
            actualuser = gb;
            autoList = autoRead.getallOfOwner(gb.id);
            foreach (var i in autoList)
            {
                pnlCars.Children.Add(addCard(i));

            }
        }

        public StackPanel addCard(auto auto)
        {
            Foto foto = fotoAuto.getFirstPhotoFromID(auto.id);
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(90, GridUnitType.Pixel) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(180, GridUnitType.Pixel) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20, GridUnitType.Pixel)});
            StackPanel pnl = new StackPanel();
            pnl.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2E6DDA"));
            pnl.Children.Add(grid);
            pnl.Width = 260;
            pnl.Height = 130;
            pnl.Margin = new Thickness(10);
            grid.Margin = new Thickness(10);
            Image img = new Image();
            img.Width = 100;
            using (var ms = new System.IO.MemoryStream(foto.data))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                img.Source = new BitmapImage();
                img.Source = image;
            }

            Label lbl = new Label();
            lbl.Content = $"{auto.naam}";
            lbl.FontWeight = FontWeights.Bold;
            lbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            Grid.SetColumn(lbl, 1);
            grid.Children.Add(img);
            grid.Children.Add(lbl);
            if (auto.type == 1)
            {
                Label lbl2 = new Label();
                lbl2.Content = $"Merk: {auto.merk}";
                lbl2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
                lbl2.Margin = new Thickness(0, 20, 0, 5);
                Label lbl3 = new Label();
                lbl3.Content = $"Model: {auto.model}";
                lbl3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
                lbl3.Margin = new Thickness(0, 40, 0, 0);
                grid.Children.Add(lbl2);
                Grid.SetColumn(lbl2, 1);
                grid.Children.Add(lbl3);
                Grid.SetColumn(lbl3, 1);
            }

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;

            Button btnDelete = new Button();
            btnDelete.Margin = new Thickness(0,0,5,0);
            btnDelete.Width = 60;
            btnDelete.Height = 24;
            btnDelete.Content = "Delete";
            btnDelete.FontWeight = FontWeights.Bold;
            btnDelete.Background = Brushes.Red;
            btnDelete.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            btnDelete.Click += (sender, e) =>
            {
                autoRead.DeleteAuto(auto.id);
                pnlCars.Children.Clear();
                autoList = autoRead.getallOfOwner(actualuser.id);
                foreach (var i in autoList)
                {
                    pnlCars.Children.Add(addCard(i));

                }
            };
            stackPanel.Children.Add(btnDelete);

            Button btnEdit = new Button();
            btnEdit.Margin = new Thickness(0,0,5,0);
            btnEdit.Width = 60;
            btnEdit.Height = 24;
            btnEdit.Content = "Edit";
            btnEdit.FontWeight = FontWeights.Bold;
            btnEdit.Background = Brushes.SteelBlue;
            btnEdit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            btnEdit.Click += (sender, e) =>
            {

            };
            stackPanel.Children.Add(btnEdit);

            Button btnDetails = new Button();
            btnDelete.Margin = new Thickness(0,0,5,0); ;
            btnDetails.Width = 60;
            btnDetails.Height = 24;
            btnDetails.Content = "Info";
            btnDetails.FontWeight = FontWeights.Bold;
            btnDetails.Background = Brushes.DarkGray;
            btnDetails.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            btnDetails.Click += (sender, e) =>
            {
                if (auto.type == 1)
                {
                    DetailsGemotoriseerd page = new DetailsGemotoriseerd(auto, actualuser);
                    page.Show();
                }

                if (auto.type == 2)
                {
                    DetailsGetrokken page = new DetailsGetrokken(auto, actualuser);
                    page.Show();
                }
            };
            stackPanel.Children.Add(btnDetails);
            pnl.Children.Add(stackPanel);
            return pnl;
        }

        private void btnToevoegenVoertuig_Click(object sender, RoutedEventArgs e)
        {
            AddVoertuig page = new AddVoertuig(actualuser);
            page.Show();
        }
    }
}
