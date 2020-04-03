using System.Windows.Shapes;

namespace Strategy
{ 
    public enum BuildingType
    {
        HOUSE,
        WAREHOUSE,
        WOODCUTTER
    }
    public abstract class Building 
    {
        public Rectangle Texture { get; set; }

        public abstract string Name { get; }

        public abstract char Mark { get; }
        public abstract int SizeX { get; }
        public abstract int SizeY { get; }

        public abstract int CostWood { get; }
        public abstract int CostIron { get; }
        public abstract int CostStone { get; }

        public override string ToString()
        {
            return $"{Name}\n{Mark}\n{SizeX}\n{SizeY}\n{CostWood}\n{CostStone}\n{CostIron}";
        }
    }
}
