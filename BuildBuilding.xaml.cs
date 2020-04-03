using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace Strategy
{
    /// <summary>
    /// Interakční logika pro BuildBuilding.xaml
    /// </summary>
    public partial class BuildBuilding : Window
    {
        public BuildBuilding()
        {
            InitializeComponent();
            List<Building> items = new List<Building>();
            House h = new House();
            WareHouse wh = new WareHouse();
            items.Add(h);
            items.Add(wh);
            buildingList.ItemsSource = items;
        }
        public class House : Building
        {
            public override string Name { get { return "House"; } }
            public override char Mark { get { return 'h'; } }

            public override int SizeX { get { return 50; } }

            public override int SizeY { get { return 50; } }

            public override int CostWood { get { return 30; } }

            public override int CostStone { get { return 20; } }

            public override int CostIron { get { return 0; } }

        }
        public class WareHouse : Building
        {
            public override string Name { get { return "WareHouse"; } }
            public override char Mark { get { return '2'; } }

            public override int SizeX { get { return 100; } } 

            public override int SizeY { get { return 50; } }

            public override int CostWood { get { return 30; } }

            public override int CostStone { get { return 20; } }

            public override int CostIron { get { return 0; } }

        }

        public Building Building 
        {
            get { return Building; }

        }
        private class BuildingDescendant : Building
        {
            private object selectedItem;

            public BuildingDescendant(object selectedItem)
            {
                this.selectedItem = selectedItem;
            }

            public Rectangle Texture { get; set; }

            public override string Name { get; }

            public override char Mark { get; }
            public override int SizeX { get; }
            public override int SizeY { get; }

            public override int CostWood { get; }
            public override int CostIron { get; }
            public override int CostStone { get; }
        }
        private void ButtonBuild_Click(object sender, RoutedEventArgs e)
        {

            BuildingDescendant building = new BuildingDescendant(buildingList.SelectedItem);
            Window.GetWindow(this).DialogResult = true;
            Window.GetWindow(this).Close();
        }
    }
}
