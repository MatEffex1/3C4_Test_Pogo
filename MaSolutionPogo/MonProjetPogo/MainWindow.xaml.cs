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

namespace MonProjetPogo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ButtonClickMe.Click += Button_ClickFirstTime;

            TextBlockGame.Text = "Baldur's Gate 3";

            TextBlock newTextBlock = new TextBlock();
            newTextBlock.Text = "New TextBlock";

            StackPanelMain.Children.Add(newTextBlock);
        }

        private void Button_ClickFirstTime(object sender, RoutedEventArgs e)
        {
            //List<Doctor> doctors = App.Doctors;

            foreach (var doctor in App.Doctors)
            {

            }

            string name = TextBoxName.Text;

            MessageBox.Show($"Bonjour {name}", "Title", MessageBoxButton.OK, MessageBoxImage.Error);

            ButtonClickMe.Click -= Button_ClickFirstTime;
            ButtonClickMe.Click += Button_ClickSecondTime;
        }

        private void Button_ClickSecondTime(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked twice!", "Title", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
