using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Forms;
using WaveSim;
using Application = System.Windows.Application;

namespace OLEDScreensaver
{
	public partial class App : Application
	{
		private HwndSource winWPFContent;

		private void ApplicationStartup(object sender, StartupEventArgs e)
		{
			if (e.Args.Length == 0 || e.Args[0].ToLower().StartsWith("/s"))
			{
				foreach (Screen s in Screen.AllScreens)
				{
					if (s != Screen.PrimaryScreen)
					{
						Blackout window = new Blackout();
						window.Left = s.WorkingArea.Left;
						window.Top = s.WorkingArea.Top;
						window.Width = s.WorkingArea.Width;
						window.Height = s.WorkingArea.Height;
						window.Show();
					}
					else
					{
						MainWindow window = new MainWindow();
						window.Left = s.WorkingArea.Left;
						window.Top = s.WorkingArea.Top;
						window.Width = s.WorkingArea.Width;
						window.Height = s.WorkingArea.Height;
						window.Show();
					}
				}
			}
			else if (e.Args[0].ToLower().StartsWith("/p"))
			{
				MainWindow window = new MainWindow();
				Int32 previewHandle = Convert.ToInt32(e.Args[1]);
				IntPtr pPreviewHnd = new IntPtr(previewHandle);
				RECT lpRect = new RECT();
				bool bGetRect = Win32API.GetClientRect(pPreviewHnd, ref lpRect);

				HwndSourceParameters sourceParams = new HwndSourceParameters("sourceParams");

				sourceParams.PositionX = 0;
				sourceParams.PositionY = 0;
				sourceParams.Height = lpRect.Bottom - lpRect.Top;
				sourceParams.Width = lpRect.Right - lpRect.Left;
				sourceParams.ParentWindow = pPreviewHnd;
				sourceParams.WindowStyle = (int)(WindowStyles.WS_VISIBLE | WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN);

				winWPFContent = new HwndSource(sourceParams);
				winWPFContent.Disposed += (o, args) => window.Close();
				winWPFContent.RootVisual = window.MainGrid;

			} else if (e.Args[0].ToLower().StartsWith("/c"))
			{
			}
		}
	}
}
