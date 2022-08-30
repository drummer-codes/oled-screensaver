using System.Windows;
using System.Windows.Input;

namespace OLEDScreensaver
{
	public partial class Blackout : Window
	{
		public Blackout()
		{
			InitializeComponent();
			Loaded += MainWindow_Loaded;
		}

		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Maximized;
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
