using CryptoReview.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoReview.ViewModel
{
    public partial class MainViewModel
    {

        private static void GoToFullCryptoList(Window CurrentWindow)
        {
            CurrentWindow.Close();
            FullCryptoListWindow window = new();
            window.Show();
        }
        private static RelayCommand? _goToFullCryptoListCommand;
        public static RelayCommand GoToFullCryptoListCommand
        {
            get
            {
                return _goToFullCryptoListCommand ?? (_goToFullCryptoListCommand = new RelayCommand(obj => GoToFullCryptoList(obj as Window)));
            }
        }
    }
}
