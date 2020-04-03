using System.Windows.Shapes;

namespace Strategy
{
    public interface IField
    {
        string Name { get; }
        char Mark { get; }
        FieldType Type { get; }
    }
    public enum FieldType
    {
        GRASS,
        STONE,
        TREE,
        WATER
    }
    public abstract class GameField : IField{
        public Rectangle Texture { get; set; }

        public abstract string Name { get; }

        public abstract char Mark { get; }

        public abstract FieldType Type { get; }

    }
}
