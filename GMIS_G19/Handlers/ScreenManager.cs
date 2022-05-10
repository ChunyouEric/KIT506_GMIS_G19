using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GMIS_G19.Interfaces;
using GMIS_G19.Views;

namespace GMIS_G19.Handlers
{
    public class ScreenManager
    {
	    private Frame _MainFrame;
	    private IWindow _MainWindow;

	    public ScreenManager(Frame mainFrame, IWindow mainWindow)
	    {
		    _MainFrame = mainFrame;
		    _MainWindow = mainWindow;
	    }

	    public void LoadHome()
	    {
		    _MainFrame.Content = new Home(_MainWindow);
	    }

	    public void LoadMaster()
		{
			_MainFrame.Content = new Master(_MainWindow);
	    }
		
    }
}
