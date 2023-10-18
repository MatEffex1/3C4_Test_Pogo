using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Windows;

namespace Classes2
{
    public enum Gender
    {
        Male,
        Female,
        NonBinary,
        Trans
    }

    public enum BuildObjects
    {
        Wall,
        Floor,
        Door,
        Pool
    }

    public enum BuyableObjects
    {
        Oven,
        Chair,
        Table,
        Bed,
        Sofa
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public class Character
    {
        public Character(string name, Gender gender, double height, double thickness)
        {
            Name = name;
            Gender = gender;
            Height = height;
            Thickness = thickness;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public double Height { get; set; }
        public double Thickness { get; set; }
        public int Money { get; set; }
        public List<Prop> BuyablesObjects { get; set; }
        public Job Job { get; set; }
        public List<Annimal> Animals { get; set; }

        public void customize()
        {

        }

        public void actions()
        {

        }
    }

    public interface IMovable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void move(Grid grid);
    }

    public interface IInteractable
    {
        public void interact();
    }

    public class Store
    {
        public Store(Prop prop)
        {

        }

        public void buy()
        {

        }
    }

    public class Annimal : IInteractable
    {
        public string Name { get; set; }

        public void interact()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Job
    {
        public int Id { get; set; }
        public int Salary { get; set; }
        public DateAndTime[] Horaire { get; set; }
    }

    public class Prop : IMovable, IInteractable
    {
        public int Id { get; set; }
        public int X { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Y { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void interact()
        {
            throw new System.NotImplementedException();
        }

        public void move(Grid grid)
        {

        }
    }

    public class Case
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Grid
    {
        public int Id { get; set; }
        public Case[][] cases { get; set; }
    }

    public class Construction
    {
        public List<Prop> BuildObjects { get; set; }

        public void add()
        {

        }

        public void delete()
        {

        }

        public void move()
        {

        }

        public void paint()
        {

        }
    }
}
