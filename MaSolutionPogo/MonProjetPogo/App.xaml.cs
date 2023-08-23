using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MonProjetPogo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<Doctor> Doctors = new List<Doctor>()
        {
            new Doctor() { Id = "456" },
            new Doctor(),
            new Doctor(),
        };

        public Doctor doc123 = new Doctor() { Id = "123", Name = "Pogo" };
    }

    public class Doctor
    {
        public string Id { get; init; }
        public string Name { get; set; }
    }
}
