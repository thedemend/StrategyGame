using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Strategy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Building Building = null;
        private double X;
        private double Y;
        private IList<GameField> GameFields = new List<GameField>();
        public MainWindow()
        {
            
            InitializeComponent();
            String mapCode = "wwwtttssgg" + "wwwtttssgg" + "wwwtttssgg" + "wwwtttssgg" + "wwwtttssgg" + "wwwtttssgg"
                + "wwwtttssgg" + "wwwtttssgg" + "wwwtttssgg" + "wwwtttssgg";
            //String mapCode = MapGenerator.MapGenerate(MapGenerator.MapType.SMALL);
            //MessageBox.Show($"Map code je: {mapCode}");
            int top = 0;
            int left = 0;

            foreach (char itm in mapCode)
            {
                Rectangle rect = new Rectangle();
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                rect.Width = 50;
                rect.Height = 50;
                Canvas.SetTop(rect, top);
                Canvas.SetLeft(rect, left);
                GameField gm = null;
                switch (itm)
                {
                    case 'g':
                        mySolidColorBrush.Color = Color.FromArgb(255, 0, 255, 0);
                        gm = new Grass();
                        break;
                    case 's':
                        mySolidColorBrush.Color = Color.FromArgb(255, 125, 125, 125);
                        gm = new Stone();
                        break;
                    case 't':
                        mySolidColorBrush.Color = Color.FromArgb(255, 139, 69, 19);
                        gm = new Tree();
                        break;
                    case 'w':
                        mySolidColorBrush.Color = Color.FromArgb(255, 30, 144, 255);
                        gm = new Water();
                        break;
                }
                rect.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args) {
                    //MessageBox.Show($"Kliknul si na {gm.Name}");
                    
                };
                rect.Fill = mySolidColorBrush;
                rect.StrokeThickness = 0.3;
                rect.Stroke = Brushes.Black;
                map.Children.Add(rect);
                gm.Texture = rect;
                GameFields.Add(gm);
                left += 50;
                if (left == 500)
                {
                    left = 0;
                    top += 50;
                }


            }

        }

        public class Grass : GameField
        {
            public override string Name { get { return "Grass"; } }
            public override char Mark { get { return 'g'; } }
            public override FieldType Type { get { return FieldType.GRASS; } }
        }
        public class Stone : GameField
        {
            public override string Name { get { return "Rock"; } }
            public override char Mark { get { return 'r'; } }
            public override FieldType Type { get { return FieldType.STONE; } }
        }
        public class Tree : GameField
        {
            public override string Name { get { return "Tree"; } }
            public override char Mark { get { return 't'; } }
            public override FieldType Type { get { return FieldType.TREE; } }
        }
        public class Water : GameField
        {
            public override string Name { get { return "Water"; } }
            public override char Mark { get { return 'w'; } }
            public override FieldType Type { get { return FieldType.WATER; } }
        }

        private void map_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                
            }
        }

        private void Map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            X = p.X;
            Y = p.Y;
            X = X - (X % 50);
            Y = Y - (Y % 50);
            MessageBox.Show($"Souřadnice X: {X}, Y: {Y}");
        }
        private void BuildBuilding_Click(object sender, RoutedEventArgs e)
        {
            BuildBuilding buildBuildingDialog = new BuildBuilding();
            if (buildBuildingDialog.ShowDialog() == true)
            {
                Building  = buildBuildingDialog.Building;
            }
            if (Building != null)
            {
                MessageBox.Show(Building.Name);
            }
        }
    }
}
