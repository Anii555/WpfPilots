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
        public MainWindow()
        {
            InitializeComponent();
        }

        private Button[,] CreateButtons(int quantity)
        {
            Button[,] buttons = new Button[quantity, quantity];
            int[] position = new int[2] { 50, 20 }; //положение по горизонтали
            Random random = new Random();

            for (int i = 0; i < quantity; i++)
            {
                for (int j = 0; j < quantity; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = position[random.Next(0,2)]; //50
                    buttons[i, j].Height = buttons[i, j].Width == 50 ? 20 : 50; 
                    buttons[i, j].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    buttons[i, j].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    buttons[i, j].Margin = new Thickness(10);
                    buttons[i, j].Click += ChangePosition_Click;

                    string position_name = $"btn_{i}_{j}".ToString();
                    buttons[i, j].Name = position_name;
                }
            }
            return buttons;
        }

        private void AddToWrapPanel(int quantity, Button[,] buttons)
        {
            for (int i = 0; i < quantity; i++)
                for (int j = 0; j < quantity; j++)
                {
                    uniformdGrid.Children.Add(buttons[i, j]);
                }
        }

        private int GetQuantityButtons()
        {
            ComboBoxItem item = (ComboBoxItem)cmbBox.SelectedItem;
            int count = int.Parse((string)item.Content);
            return count;
        }

        private void СreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (uniformdGrid.Children.Count > 0)
                uniformdGrid.Children.Clear();
            int count = GetQuantityButtons();
            Button[,] buttons = CreateButtons(count);
            AddToWrapPanel(count, buttons);
        }

        private void ChangePosition_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string[] name_btn = btn.Name.Split('_');
            string current_row = name_btn[1];
            string current_column = name_btn[2];

            MessageBox.Show("Столбец такой-то: " + current_column + " | Строка такая-то: " + current_row);
            btn.Height = btn.Width == 50 ? 50 : 20;
            btn.Width = btn.Height == 50 ? 20 : 50;
        }
    }
}
