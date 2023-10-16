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

    public interface ISavable
    {

    }

    public interface ILoadable
    {

    }

    public interface IErasable
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

    public class Texte
    {
        private string? TextField { get; set; }
        private int? FontSize { get; set; }
        private string? FontFamily { get; set; }
    }
}
