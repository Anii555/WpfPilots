using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPilots
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Deck Deck;
        private Style _verticalButtonStyle;
        private Style _horizontalButtonStyle;
        private Random _random;
        private Button[,] _buttons;
        private int _quantity;

        public MainWindow()
        {
            InitializeComponent();

            _verticalButtonStyle = this.FindResource("VerticalButton") as Style;
            _horizontalButtonStyle = this.FindResource("HorizontalButton") as Style;
            _random = new Random();
        }

        private List<List<LevelArm>> GenerateGrid()
        {
            var result = new List<List<LevelArm>>(_quantity);

            for (var i = 0; i < _quantity; i++)
            {
                var list = new List<LevelArm>(_quantity);

                for (var j = 0; j < _quantity; j++)
                {
                    var isVertical = _random.Next(0, 2) == 1;
                    var levelArm = new LevelArm
                    {
                        IsVertical = isVertical,
                        Column = j,
                        Row = i,
                    };

                    list.Add(levelArm);
                }

                result.Add(list);
            }

            return result;
        }

        private void CreateButtons()
        {
            _buttons = new Button[_quantity, _quantity];
            var grid = GenerateGrid();
            Deck = new Deck(grid);

            foreach (var levelArm in Deck.AllArms)
            {
                var button = new Button();
                button.Style = levelArm.IsVertical ? _verticalButtonStyle : _horizontalButtonStyle;
                button.Click += ChangePosition_Click;

                _buttons[levelArm.Column, levelArm.Row] = button;
            }
        }

        private void PrintButtons()
        {
            if (uniformdGrid.Children.Count > 0)
                uniformdGrid.Children.Clear();

            for (int i = 0; i < _quantity; i++)
                for (int j = 0; j < _quantity; j++)
                {
                    uniformdGrid.Children.Add(_buttons[j, i]);
                }
        }

        private void SetQuantityButtons()
        {
            var item = (ComboBoxItem)cmbBox.SelectedItem;
            _quantity = int.Parse((string)item.Content);
        }

        private void СreateButton_Click(object sender, RoutedEventArgs e)
        {
            SetQuantityButtons();
            CreateButtons();
            uniformdGrid.Columns = _quantity;
            uniformdGrid.Rows = _quantity;
            PrintButtons();
        }

        private void ChangePosition_Click(object sender, RoutedEventArgs e)
        {
            int index = uniformdGrid.Children.IndexOf((Button)sender);

            int current_row = index / uniformdGrid.Columns;
            int current_column = index % uniformdGrid.Columns;

            UpdateButtons(current_column, current_row);
        }

        private void UpdateButtons(int column, int row)
        {
            for (int i = 0; i < _quantity; i++)
            {
                if (i == column) continue;

                var button = _buttons[i, row];
                button.Style = button.Width > button.Height ? _verticalButtonStyle : _horizontalButtonStyle;
            }

            for (int j = 0; j < _quantity; j++)
            {
                var button = _buttons[column, j];
                button.Style = button.Width > button.Height ? _verticalButtonStyle : _horizontalButtonStyle;
            }
        }
    }
}
