using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Cours4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Group SelectedGroup { get => (Group)ComboBoxGroups.SelectedItem; }

        public MainWindow()
        {
            InitializeComponent();

            object doctor = new Doctor();
            //doctor.Name = "Mathieu";

            Doctor d1 = (Doctor)doctor;
            if (d1 != null)
            {
                d1.Name = "Mathieu";
            }

            ((Doctor)doctor).Name = "Mathieu";

            object obj = (object)d1;

            List<object> doctors = new List<object>();
            doctors.Add(obj);
            doctors.Add(d1);

            Doctor d2 = obj as Doctor;

            if (obj is Doctor)
            {

            }

            int number = 10;

            int? number2 = 10;

            string name = "allo";

            string? name2 = "bonjour";

            if (name2 != null)
            {

            }


            CheckBoxPogo.IsChecked = true;


            ComboBoxGroups.Items.Add(new Group() { Name = "Group 1", Time = 10 });
            ComboBoxGroups.Items.Add(new Group() { Name = "Group 2", Time = 12 });
            ComboBoxGroups.Items.Add(new Group() { Name = "Group 3", Time = 15 });

            ComboBoxGroups.SelectionChanged += ComboBoxGroups_SelectionChanged;
        }

        private void ComboBoxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Group group = (Group)ComboBoxGroups.SelectedItem;
            if (group != null)
            {

            }
        }

        private class Doctor
        {
            public string Name { get; set; } = "";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool? isChecked = checkBox.IsChecked;

            if (isChecked == true)
            {

            }
        }

        private void RadioButtonFood_Checked(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup == null)
                return;

            if (RadioButtonPepsi.IsChecked == true)
            {
                SelectedGroup.Drink = Group.DrinkType.Pepsi;
            }
            else if (RadioButtonPoutine.IsChecked == true)
            {
                SelectedGroup.Drink = Group.DrinkType.Poutine;
            }
            else
            {
                SelectedGroup.Drink = Group.DrinkType.Pogo;
            }
        }

        private class Group
        {
            public enum DrinkType
            {
                Pepsi,
                Poutine,
                Pogo
            };

            public string Name { get; set; }
            public int Time { get; set; }
            public DrinkType Drink { get; set; }

            public override string ToString()
            {
                return $"{Name} - {Time}";
            }
        }
    }
}
