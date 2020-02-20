using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace GlazedForms
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            double tree = 0.25, metal = 0.05, metalPlastic = 0.15;
            if ((bool)chekbox.IsChecked)
            {
               sum += 35;
            }
            if((bool)twoRadio.IsChecked)
            {
                tree += 0.05;
                metal += 0.05;
                metalPlastic += 0.05;
            }
            switch(combo.SelectedIndex)
            {
                case 0: sum += Convert.ToDouble(Width.Text) * Convert.ToDouble(Height.Text) * tree; break;
                case 1: sum += Convert.ToDouble(Width.Text) * Convert.ToDouble(Height.Text) * metal; break;
                case 2: sum += Convert.ToDouble(Width.Text) * Convert.ToDouble(Height.Text) * metalPlastic; break;
            }
            cost.Content = sum.ToString() + " грн";

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
