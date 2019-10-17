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

namespace Basic_Calculator
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(firstNumberTextBox.Text))
            {
                MessageBox.Show("First number is empty", "Input error");
                return;
            }
            if (string.IsNullOrEmpty(secondNumberTextBox.Text))
            {
                MessageBox.Show("Second number is empty", "Input error");
                return;
            }
            decimal firstNumber = decimal.Parse(firstNumberTextBox.Text);
            decimal secondNumber = decimal.Parse(secondNumberTextBox.Text);
            switch((string)((ComboBoxItem)mathFunctionComboBox.SelectedItem).Content)
            {
                case "+":
                    MessageBox.Show((firstNumber + secondNumber).ToString(), "Result");
                    break;
                case "-":
                    MessageBox.Show((firstNumber - secondNumber).ToString(), "Result");
                    break;
                case "*":
                    MessageBox.Show((firstNumber * secondNumber).ToString(), "Result");
                    break;
                case "/":
                    MessageBox.Show((firstNumber / secondNumber).ToString(), "Result");
                    break;
                case "%":
                    MessageBox.Show((firstNumber % secondNumber).ToString(), "Result");
                    break;
            }
        }
    }
}
