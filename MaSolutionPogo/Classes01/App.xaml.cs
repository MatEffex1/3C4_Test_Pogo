using System.Drawing;
using System.Windows;

namespace Classes01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public interface IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Save
    {

    }

    public class Load
    {

    }

    public class Erase
    {

    }

    public class ColorPallet
    {
        private Color ActiveColor { get; set; }
        private Color[]? ColorSelection { get; }
    }


    public class Container
    {
        private int Width { get; set; }
        private int Height { get; set; }
    }

    public abstract class Forme : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Carre : Forme
    {

    }

    public class Triangle : Forme
    {

    }

    public class Cercle : Forme
    {

    }

    public class Polygon : Forme
    {

    }

    public class Pipe
    {
        private Color ActiveColor { get; set; }

        void newColor()
        {

        }
    }

    public class Texte : IPosition
    {
        private string? TextField { get; set; }
        private int? FontSize { get; set; }
        private string? FontFamily { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
