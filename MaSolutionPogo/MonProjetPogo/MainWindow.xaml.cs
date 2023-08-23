using System.Windows;
using System.Windows.Controls;

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
