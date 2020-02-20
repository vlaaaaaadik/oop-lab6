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
            double bulg = 100, doich = 160, poland = 120;
            if ((bool)chekbox.IsChecked)
            {
               sum += 50 * Convert.ToDouble(days.Text);
            }
            if((bool)twoRadio.IsChecked)
            {
                bulg += 50;
                doich += 40;
                poland += 60;
            }
            switch(combo.SelectedIndex)
            {
                case 0: sum += Convert.ToDouble(days.Text) * bulg; break;
                case 1: sum += Convert.ToDouble(days.Text) * doich; break;
                case 2: sum += Convert.ToDouble(days.Text) * poland; break;
            }
            cost.Content = sum.ToString() + " $";

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
