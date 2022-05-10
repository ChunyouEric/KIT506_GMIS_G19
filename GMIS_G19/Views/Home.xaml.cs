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
using GMIS_G19.Interfaces;
using GMIS_G19.Models;

namespace GMIS_G19.Views
{
	/// <summary>
	/// Interaction logic for Home.xaml
	/// </summary>
	public partial class Home : Page
	{
		private IWindow _ParentWindow;

		public Home(IWindow parentWindow)
		{
			InitializeComponent();
			_ParentWindow = parentWindow;
			Init();
		}

		public void Init()
		{
			ComboBoxStudentCategory.ItemsSource = Enum.GetValues(typeof(Category)).Cast<Category>();
			ComboBoxStudentCategory.SelectedIndex = 0;
		}

		private void OnNextButtonClick(object sender, RoutedEventArgs e)
		{
			switch ((Category) ComboBoxStudentCategory.SelectionBoxItem)
			{
				case Category.Masters:
					_ParentWindow.ScreenManager.LoadMaster();
					break;
				case Category.Bachelors:
					//TODO: Add screen manager load bachelor screen
					break;
			}
		}
	}
}