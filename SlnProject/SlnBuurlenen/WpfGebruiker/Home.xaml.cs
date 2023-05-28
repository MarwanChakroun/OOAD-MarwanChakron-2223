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
        public Home(Gebruiker gb)
        {
            InitializeComponent();
            List<auto> autos = autoRead.getallcar();
            foreach (var i in autos)
            {
                pnlItems.Children.Add(addCard(i));   
            }
        }

        public StackPanel addCard(auto auto)
        {
            Foto foto = fotoAuto.getFirstPhotoFromID(auto.id);
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            StackPanel pnl = new StackPanel();
            pnl.Children.Add(grid);
            pnl.Width = 300;
            pnl.Height = 200;
            pnl.Margin = new Thickness(20);

            Image img = new Image();
            img.Width = 200;
            img.Height = 100;
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
            lbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0e387a"));
            Grid.SetColumn(lbl, 1);
            grid.Children.Add(img);
            grid.Children.Add(lbl);
            if (auto.type == 1)
            {
                Label lbl2 = new Label();
                lbl2.Content = $"Merk: {auto.merk}";
                lbl2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0e387a"));
                Label lbl3 = new Label();
                lbl3.Content = $"Model: {auto.model}";
                lbl3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0e387a"));
                grid.Children.Add(lbl2);
                Grid.SetColumn(lbl2, 1);
                grid.Children.Add(lbl3);
                Grid.SetColumn(lbl3, 1);
            }
            Button btn = new Button();
            btn.Tag = auto.id;
            btn.Content = "Details";
            btn.FontWeight = FontWeights.Bold;
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0e387a"));
            btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.VerticalAlignment = VerticalAlignment.Bottom;
            pnl.Children.Add(btn);
            return pnl;
        }
    }
}
