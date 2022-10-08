using LogicLibrary;
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
        private readonly Logic _logic;
        private Style _verticalButtonStyle;
        private Style _horizontalButtonStyle;
        private Button[,] _buttons;
        private int _quantity;

        public MainWindow()
        {
            _logic = new Logic();

            InitializeComponent();

            _verticalButtonStyle = this.FindResource("VerticalButton") as Style;
            _horizontalButtonStyle = this.FindResource("HorizontalButton") as Style;
        }

        private void CreateButtons()
        {
            _buttons = new Button[_quantity, _quantity];
            var deck = _logic.GenerateDeck(_quantity);

            foreach (var levelArm in deck.AllArms)
            {
                var button = new Button();
                button.Style = levelArm.IsVertical ? _verticalButtonStyle : _horizontalButtonStyle;
                button.Click += ChangePosition_Click;

                _buttons[levelArm.Column, levelArm.Row] = button;
            }

            PrintButtons();
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
            uniformdGrid.Columns = _quantity;
            uniformdGrid.Rows = _quantity;
            CreateButtons();
        }

        private void ChangePosition_Click(object sender, RoutedEventArgs e)
        {
            int index = uniformdGrid.Children.IndexOf((Button)sender);

            int current_row = index / uniformdGrid.Columns;
            int current_column = index % uniformdGrid.Columns;

            UpdateButtons(current_column, current_row);
            
            if (_logic.IsGameOver)
            {
                GameOver();
            }
        }

        private void UpdateButtons(int column, int row)
        {
            var positionChanged = _logic.ChangePosition(column, row);

            if (!positionChanged)
            {              
                return;
            }

            // Переворачиваем все кнопки в ряду
            for (int i = 0; i < _quantity; i++)
            {
                // Не переворачиваем нажатую кнопку
                if (i == column) continue;

                var button = _buttons[i, row];
                button.Style = button.Width > button.Height ? _verticalButtonStyle : _horizontalButtonStyle;
            }

            // Переворачиваем все кнопки в столбце, включая нажатую
            for (int j = 0; j < _quantity; j++)
            {
                var button = _buttons[column, j];
                button.Style = button.Width > button.Height ? _verticalButtonStyle : _horizontalButtonStyle;
            }
        }

        public void GameOver()
        {
            var answer = MessageBox.Show("Поздравляю, вы прошли игру! Начать новую?", Title, MessageBoxButton.YesNo);

            if (answer == MessageBoxResult.Yes) 
            {
                CreateButtons();
            }
        }
    }
}
