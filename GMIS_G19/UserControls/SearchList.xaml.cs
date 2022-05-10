using System;
using System.Collections;
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
using GMIS_G19.Models;

namespace GMIS_G19.UserControls
{
	/// <summary>
	/// Interaction logic for SearchList.xaml
	/// </summary>
	public partial class SearchList : UserControl
	{
		public DisplayType DisplayType { get; set; }
		private MastersStudentController _MastersStudentController => DataContext as MastersStudentController;

		public SearchList()
		{
			InitializeComponent();
		}

		public void ListBindSource()
		{
			switch (DisplayType)
			{
				case DisplayType.Students:
					LstObjectList.ItemsSource = _MastersStudentController.FilteredStudent;
					break;
				case DisplayType.Groups:
					//TODO
					break;
				case DisplayType.Classes:
					//TODO
					break;
				case DisplayType.Meetings:
					//TODO
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void OnLstObjectListBind()
		{
			GridView lstObjectListGridView = new GridView();
			switch (DisplayType)
			{
				case DisplayType.Students:

					#region List Bind

					GridViewColumn gvc1 = new GridViewColumn
					{
						DisplayMemberBinding = new Binding("GivenName"),
						Header = "Given Name",
						Width = 100
					};
					lstObjectListGridView.Columns.Add(gvc1);
					GridViewColumn gvc2 = new GridViewColumn
					{
						DisplayMemberBinding = new Binding("FamilyName"),
						Header = "Last Name",
						Width = 100
					};
					lstObjectListGridView.Columns.Add(gvc2);
					GridViewColumn gvc3 = new GridViewColumn
					{
						DisplayMemberBinding = new Binding("GroupId"),
						Header = "Group Id",
						Width = 100
					};
					lstObjectListGridView.Columns.Add(gvc3);
					GridViewColumn gvc4 = new GridViewColumn
					{
						DisplayMemberBinding = new Binding("Title"),
						Header = "Title",
						Width = 100
					};
					lstObjectListGridView.Columns.Add(gvc4);
					GridViewColumn gvc5 = new GridViewColumn
					{
						DisplayMemberBinding = new Binding("Campus"),
						Header = "Campus",
						Width = 100
					};
					lstObjectListGridView.Columns.Add(gvc5);
					GridViewColumn gvc6 = new GridViewColumn
					{
						DisplayMemberBinding = new Binding("Phone"),
						Header = "Phone",
						Width = 100
					};
					lstObjectListGridView.Columns.Add(gvc6);
					GridViewColumn gvc7 = new GridViewColumn
					{
						DisplayMemberBinding = new Binding("Email"),
						Header = "Email",
						Width = 100
					};
					lstObjectListGridView.Columns.Add(gvc7);
					GridViewColumn gvc8 = new GridViewColumn
					{
						DisplayMemberBinding = new Binding("Category"),
						Header = "Category",
						Width = 100
					};
					lstObjectListGridView.Columns.Add(gvc8);
					LstObjectList.View = lstObjectListGridView;

					#endregion

					#region Filter

					var groupList = (new List<string>() {"All"});
					groupList.AddRange(_MastersStudentController.Students.Select(student => student.GroupId.ToString())
						.Distinct());
					CustomFilter groupFilter = new CustomFilter()
					{
						LabelText = "Group: ",
						IsShowComboBox = true,
						IsShowTextBox = false,
						ComboBoxItemSource = groupList
					};
					groupFilter.ComboFilterSelectionChangedEventHandler += OnGroupFilterChanged;
					var classList = (new List<string>() {"All"});
					classList.AddRange(_MastersStudentController.Classes.Select(cls => cls.Id.ToString()).Distinct());
					CustomFilter classFilter = new CustomFilter()
					{
						LabelText = "Class",
						IsShowComboBox = true,
						IsShowTextBox = false,
						ComboBoxItemSource = classList,
					};
					classFilter.ComboFilterSelectionChangedEventHandler += OnClassFilterChanged;

					PanelFilter.Children.Clear();
					PanelFilter.Children.Add(groupFilter);
					PanelFilter.Children.Add(classFilter);

					#endregion

					ListBindSource();
					break;
				case DisplayType.Groups:
					break;
				case DisplayType.Classes:
					break;
				case DisplayType.Meetings:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void OnClassFilterChanged(object sender, EventArgs e)
		{
			if (sender is ComboBox comboBox)
			{
				_MastersStudentController.FilterStudentByClassId(comboBox.SelectedValue.ToString());
			}

			ListBindSource();
		}

		private void OnGroupFilterChanged(object sender, EventArgs e)
		{
			if (sender is ComboBox comboBox)
			{
				_MastersStudentController.FilterStudentByGroupId(comboBox.SelectedValue.ToString());
			}

			ListBindSource();
		}

		private void OnUserControlLoaded(object sender, RoutedEventArgs e)
		{
			OnLstObjectListBind();
		}
	}
}