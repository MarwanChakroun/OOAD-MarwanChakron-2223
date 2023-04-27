using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEscapeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Room currentRoom; // will become useful in later versions
        RandomMessageGenerator messageGenerator;
        public enum MessageType {
            itworks,
            itdoesntworks,
            itislocked
        }

        public MainWindow()
        {
            InitializeComponent();
            // define room
            Room room1 = new Room("bedroom","I seem to be in a medium sized bedroom. Thereis a locker to the left, a nice rug on the floor, and a bed to the right. ");
            // define items
            Item key1 = new Item("small silver key","A small silver key, makes me think of one I hadat highschool. ", true);
            Item stoelItem = new Item("bruine stoel", "How should we use this stoel ?", false);
            Item posterIteem = new Item("poster", "a poster with a lady in light dress on the beach, maybe it can be useful", true);
            Item key2 = new Item("large key","A large key. Could this be my way out? ", true);
            Item locker = new Item("locker","A locker. I wonder what's inside. ", false);
            lstRoomItems.Items.Add(key1);

            locker.HiddenItem = key2;
            locker.IsLocked = true;
            locker.Key = key1;
            Item bed = new Item("bed","Just a bed. I am not tired right now. ", false);
            bed.HiddenItem = key1;
        }

        private void LstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCheck.IsEnabled = lstRoomItems.SelectedValue != null; // room item selected
            btnPickUp.IsEnabled = lstRoomItems.SelectedValue != null; // room item selected
            btnUseOn.IsEnabled = lstRoomItems.SelectedValue != null && lstMyItems.SelectedValue != null; // room item and picked up item selected
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            // 1. find item to check
            Item roomItem = (Item)lstRoomItems.SelectedItem;
            // 2. is it locked?
            if (roomItem.IsLocked)
            {
                //lblMessage.Content = $"{roomItem.Description} {messageGenerator.GetRandomMessage(MessageType.itislocked)}";
                return;
            }
            // 3. does it contain a hidden item?
            Item foundItem = roomItem.HiddenItem;
            if (foundItem != null)
            {
                //lblMessage.Content = $"{messageGenerator.GetRandomMessage(MessageType.itworks)} {foundItem.Name}.";
                lstMyItems.Items.Add(foundItem);
                roomItem.HiddenItem = null;
                return;
            }
            // 4. just another item; show description
            lblMessage.Content = roomItem.Description;
        }

        private void BtnUseOn_Click(object sender, RoutedEventArgs e)
        {
            // 1. find both items
            Item myItem = (Item)lstMyItems.SelectedItem;
            Item roomItem = (Item)lstRoomItems.SelectedItem;
            // 2. item doesn't fit
            if (roomItem.Key != myItem)
            {
                //lblMessage.Content = $"{messageGenerator.GetRandomMessage(MessageType.itdoesntworks)}";
                return;
            }
            // 3. item fits; other item unlocked
            roomItem.IsLocked = false;
            roomItem.Key = null;
            lstMyItems.Items.Remove(myItem); 
            //lblMessage.Content = $"{messageGenerator.GetRandomMessage(MessageType.itworks)}, {roomItem.Name}!";
        }

        private void BtnPickUp_Click(object sender, RoutedEventArgs e)
        {
            // 1. find selected item
            Item selItem = (Item)lstRoomItems.SelectedItem;
            if (selItem.IsPortable == true)
            {
                // 2. add item to your items list
                lblMessage.Content = $"I just picked up the {selItem.Name}. ";
                lstMyItems.Items.Add(selItem);
                lstRoomItems.Items.Remove(selItem);
                currentRoom.Items.Remove(selItem);
            }
            lblMessage.Content = "deze item is niet draagbaar en kan niet opgepikt worden";
        }

        private void BtnUseOn_Drop(object sender, RoutedEventArgs e)
        {
            // 1. find selected item
            Item selItem = (Item)lstMyItems.SelectedItem;
            // 2. add item to your items list
            lblMessage.Content = $"I just drop the item back to the room {selItem.Name}. ";
            lstRoomItems.Items.Add(selItem);
            lstMyItems.Items.Remove(selItem);
            currentRoom.Items.Add(selItem);
        }
    }
}
