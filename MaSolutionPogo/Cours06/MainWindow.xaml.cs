using System.Collections.Generic;
using System.Windows;

namespace Cours06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Creation de liste
            List<Doctor> list = new List<Doctor>();

            // Création de dictionnaire
            Dictionary<int, Doctor> dictInt = new Dictionary<int, Doctor>()
            {
                { 1000, new Doctor() { Id = 1000, Name = "Mael" }},
                { 1234, new Doctor() { Id = 1234, Name = "Karine" }},
            };

            // Read, accéder à un élément
            Doctor doctor1000 = dictInt[1000];
            Doctor doctor1234 = dictInt[1234];

            if (dictInt.ContainsKey(9999))
            {
                // CRASH si n'existe pas
                Doctor doctor9999 = dictInt[9999];
            }

            // Iterer sur tout les éléments
            foreach (var keyValuePair in dictInt)
            {
                int key = keyValuePair.Key;
                Doctor doctor = keyValuePair.Value;
            }

            foreach (var doctor in dictInt.Values)
            {
                Doctor doctorNew = doctor;
            }

            foreach (int key in dictInt.Keys)
            {
                int Id = key;
            }

            dictInt.Add(9999, new Doctor());
            dictInt.Remove(9999);
        }
    }

    class Doctor
    {
        public int Id;
        public string Name;
    }
}
