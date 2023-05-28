using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MyClassLibrary;
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
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private readonly Foto fotoAuto = new Foto();
        private readonly auto autoRead = new auto();
        List<auto> autoList = new List<auto>();
        bool firstload = false;
        public Home(Gebruiker gb)
        {
            InitializeComponent();
            autoList = autoRead.getallcar();
            foreach (var i in autoList)
            {
                addCard(i);
            }
        }

        private void Checkfilter(object sender, RoutedEventArgs e)
        {
            autoList = autoRead.getallcar();
            if (firstload == false)
            {
                firstload = true;
            }
            else
            {
               pnlItems.Children.Clear();
            }
            if (chkMotor != null && chkMotor.IsChecked == true && chktrok != null && chktrok.IsChecked == true)
            {
                foreach (var i in autoList)
                {
                    addCard(i);
                }
            }
            else
            {
                if (chkMotor.IsChecked == true)
                {
                    foreach (var i in autoList)
                    {
                        if (i.type == 1)
                        {
                            addCard(i);
                        }
                    }
                }

                if (chktrok.IsChecked == true)
                {
                    foreach (var i in autoList)
                    {
                        if (i.type == 2)
                        {

                        }
                    }
                }
            }
        }

        public void addCard(auto auto)
        {
            Foto foto = fotoAuto.getFirstPhotoFromID(auto.id);
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() {Width = new GridLength(90, GridUnitType.Pixel)});
            grid.ColumnDefinitions.Add(new ColumnDefinition() {Width = new GridLength(180, GridUnitType.Pixel)});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20, GridUnitType.Pixel) });
            StackPanel pnl = new StackPanel();
            pnl.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2E6DDA"));
            pnl.Children.Add(grid);
            pnl.Width = 260;
            pnl.Height = 115;
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
            Button btn = new Button();
            btn.Tag = auto.id;
            btn.Margin = new Thickness(0,0,0,150);
            btn.Content = "Details";
            btn.FontWeight = FontWeights.Bold;
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0e387a"));
            pnl.Children.Add(btn);
            Grid.SetColumn(btn, 2);
            //if (pnlItems == null){pnlItems.Children.Add(pnl);}
        }
    }
}
