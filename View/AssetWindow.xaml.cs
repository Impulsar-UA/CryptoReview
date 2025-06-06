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
using static CryptoReview.Model.Asset;

namespace CryptoReview.View
{
    public partial class AssetWindow : Window
    {        
        public AssetWindow(string assetName)
        {
            DataContext = new AssetViewModel(assetName);
            InitializeComponent();
            LoadDataAsync(DataContext as AssetViewModel, assetName);

        }
        private async void LoadDataAsync(AssetViewModel viewModel, string assetName)
        {
            await viewModel.UpdateAsset(assetName);
            canvas.Loaded += (s, e) => DrawGraph();
        }
        public void DrawGraph()
        {
            canvas.Children.Clear();
            var ViewModel = DataContext as AssetViewModel;

            if (ViewModel.AssetHistory == null || ViewModel.AssetHistory.Count == 0)
                return;

            double width = canvas.ActualWidth;
            double height = canvas.ActualHeight;

            decimal maxValue = decimal.MinValue;
            decimal minValue = decimal.MaxValue;

            foreach (var entry in ViewModel.AssetHistory)
            {
                if (entry.PriceUsd > maxValue)
                    maxValue = (decimal)entry.PriceUsd;
                if (entry.PriceUsd < minValue)
                    minValue = (decimal)entry.PriceUsd;
            }
            canvas.Children.Clear();
            Polyline polyline = new Polyline();
            polyline.Stroke = Brushes.Blue;
            polyline.StrokeThickness = 2;
            canvas.Children.Add(polyline);

            for (int i = 0; i < ViewModel.AssetHistory.Count; i++)
            {
                double x = i * (width / (ViewModel.AssetHistory.Count - 1));
                double y = height - ((double)ViewModel.AssetHistory[i].PriceUsd - (double)minValue) * (height / ((double)maxValue - (double)minValue));
                polyline.Points.Add(new Point(x, y));
            }

            ToolTip toolTip = new ToolTip();

            canvas.MouseMove += (sender, e) =>
            {
                Point mousePosition = e.GetPosition(canvas);
                int index = (int)(mousePosition.X / (width / (ViewModel.AssetHistory.Count - 1)));

                if (index >= 0 && index < ViewModel.AssetHistory.Count)
                {
                    var entry = ViewModel.AssetHistory[index];

                    toolTip.Content = $"Price: {entry.PriceUsd}, Time: {entry.Time.ToString("yyyy-MM-dd")}";

                    Point toolTipPosition = e.GetPosition(this);
                    toolTip.Placement = System.Windows.Controls.Primitives.PlacementMode.RelativePoint;
                    toolTip.PlacementTarget = this;
                    toolTip.HorizontalOffset = toolTipPosition.X + 10;
                    toolTip.VerticalOffset = toolTipPosition.Y + 10;

                    toolTip.IsOpen = true;
                }
                else
                {
                    toolTip.IsOpen = false;
                }
            };

            canvas.MouseLeave += (sender, e) =>
            {
                toolTip.IsOpen = false;
            };
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
