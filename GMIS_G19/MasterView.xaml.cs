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

namespace GMIS_G19
{
    /// <summary>
    /// Interaction logic for MasterView.xaml
    /// </summary>
    public partial class MasterView : Window
    {
        public MasterView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           SubMasterView mySubMainWindow = new SubMasterView();
           mySubMainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewForSearch myViewForSearch = new ViewForSearch();
            myViewForSearch.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           MainWindow myMainWindow = new MainWindow();
            myMainWindow.Show();
        }

       

       
    }
}
