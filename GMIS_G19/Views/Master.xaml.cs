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
using GMIS_G19.Controllers;
using GMIS_G19.Interfaces;
using GMIS_G19.Models;
using GMIS_G19.UserControls;
using Views.GMIS_G19;

namespace GMIS_G19.Views
{
	/// <summary>
	/// Interaction logic for Master.xaml
	/// </summary>
	public partial class Master : Page
	{
		private IWindow _ParentWindow;
		private MastersStudentController _MasterStudentController => (MastersStudentController) DataContext;
		public Master(IWindow parentWindow)
		{
			InitializeComponent();
			_ParentWindow = parentWindow;
			StudentList.DisplayType = DisplayType.Students;
		}

		private void OnTbListSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (TbList.SelectedIndex)
			{
				case 0:
					//Student
					break;
				case 1:
					//Group
					break;
				case 2:
					//Class
					break;
				case 3:
					//Meeting
					break;
				default:
					break;
			}
		}
	}
}