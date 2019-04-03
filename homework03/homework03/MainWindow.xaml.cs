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

namespace homework03
{ 
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        // add a reference to tip.cs here
        Tip tip;
        public MainWindow()
        {
            InitializeComponent();

            // initialize an instance of Tip class 
            tip = new Tip();
        }

        private void BillCountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // when the event GotFocus happens, clear the billCountTextBox
            BillCountTextBox.Text = "";
        }

        private void BillCountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void BillCountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // when the billCountTextBox changes text, do the calculate with calling function performCalculate()
            performCalculate();
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            // when the stackPanel changes tag, do the calculate with calling function performCalculate()
            performCalculate();
        }

       

        private void performCalculate()
        {
            var selectedRadio = MyStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

            // consider that the multithreading would make .cs and .xaml run at the same time, so here we need to find out whether selectedRadio is null before using it
            if (selectedRadio != null)
            {
                tip.CalculateTip(BillCountTextBox.Text, double.Parse(selectedRadio.Tag.ToString()));
                tipAmountTextBox.Text = tip.TipAmount;
                totalAmountTextBox.Text = tip.TotalAmount;
            }          
        }


    }
}
