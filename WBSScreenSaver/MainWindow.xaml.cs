using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace OLEDScreensaver
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Loaded += MainWindow_Loaded;
		}

		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{

			double width = MainGrid.RenderSize.Width, 
				   height = MainGrid.RenderSize.Height, 
				   vmin = Math.Min(width, height), 
				   logoSize = vmin / 8.4375,
				   sizeUnit = logoSize / 8;

			logo.Width = logo.Height = logoSize;

            time.FontSize = sizeUnit * 8;
            time.Margin = new Thickness(0, 0, sizeUnit * 8, sizeUnit * 10);
            time.Height = sizeUnit * 12;

            date.FontSize = sizeUnit * 4;
            date.Margin = new Thickness(0, 0, sizeUnit * 8, sizeUnit * 5);
            date.Height = sizeUnit * 8;

			var timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 1);
			timer.Tick += delegate { SyncTime(); };
			timer.Start();

			SyncTime();

            WindowState = WindowState.Maximized;
			Mouse.OverrideCursor = Cursors.None;
		}

		void SyncTime()
		{
			date.Content = DateTime.Now.ToLongDateString();
			time.Content = DateTime.Now.ToShortTimeString();
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
