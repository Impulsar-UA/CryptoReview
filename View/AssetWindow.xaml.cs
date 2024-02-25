using CryptoReview.ViewModel;
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
using System.Windows.Shapes;

namespace CryptoReview.View
{
    public partial class AssetWindow : Window
    {
        public AssetWindow()
        {
            DataContext = VMController.MainVM;
            InitializeComponent();
        }
        private void LabelUrlClick(object sender, MouseButtonEventArgs e)
        {
            var label = (Label)sender;
            var explorerUrl = label.Content as string;
            if (!string.IsNullOrEmpty(explorerUrl))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(explorerUrl)
                    {
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                }
                e.Handled = true;
            }
        }
    }
}
