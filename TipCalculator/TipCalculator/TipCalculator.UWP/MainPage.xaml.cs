using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TipCalculator.UWP
{
    public sealed partial class MainPage
    {
        Tip tip;
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new TipCalculator.App());

            tip = new Tip();
        }

        private void BillCountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void BillCountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            performCalculate();
        }

        private void BillCountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            performCalculate();
        }

        private void performCalculate()
        {
            var selectedRadio = MyStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

            if (selectedRadio == null)
            {

            }
            else
            {
                tip.CalculateTip(BillCountTextBox.Text, double.Parse(selectedRadio.Tag.ToString()));

                tipAmountTextBox.Text = tip.TipAmount;
                totalAmountTextBox.Text = tip.TotalAmount;
            }
        }
    }
}
