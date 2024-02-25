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
            FullCryptoListWindow window = new();
            window.Show();
            CurrentWindow.Close();
        }
        private static RelayCommand? _goToFullCryptoListCommand;
        public static RelayCommand GoToFullCryptoListCommand
        {
            get
            {
                return _goToFullCryptoListCommand ?? (_goToFullCryptoListCommand = new RelayCommand(obj => GoToFullCryptoList(obj as Window)));
            }
        }
        private static void GoToMarketsList(Window CurrentWindow)
        {
            CryptoMarketsListWindow window = new();
            window.Show();
            CurrentWindow.Close();
        }
        private static RelayCommand? _goToMarketsListCommand;
        public static RelayCommand GoToMarketsListCommand
        {
            get
            {
                return _goToMarketsListCommand ?? (_goToMarketsListCommand = new RelayCommand(obj => GoToMarketsList(obj as Window)));
            }
        }
        private static void GoToMainMenu(Window CurrentWindow)
        {
            MainWindow window = new();
            window.Show();
            CurrentWindow.Close();
        }
        private static RelayCommand? _goToMainMenuCommand;
        public static RelayCommand GoToMainMenuCommand
        {
            get
            {
                return _goToMainMenuCommand ?? (_goToMainMenuCommand = new RelayCommand(obj => GoToMainMenu(obj as Window)));
            }
        }
    }
}
