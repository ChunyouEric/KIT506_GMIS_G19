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
using GMIS_G19;
using GMIS_G19.Handlers;
using GMIS_G19.Interfaces;
using GMIS_G19.Views;

namespace Views.GMIS_G19
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
	    public ScreenManager ScreenManager { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ScreenManager = new ScreenManager(MainFrame, this);
            ScreenManager.LoadHome();
        }

    }
}
