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

namespace GMIS_G19.UserControls
{
    /// <summary>
    /// Interaction logic for CustomFilter.xaml
    /// </summary>
    public partial class CustomFilter : UserControl
    {
	    public bool IsShowComboBox { get; set; }
        public bool IsShowTextBox { get; set; }
        public IEnumerable ComboBoxItemSource { get; set; }
        public string LabelText { get; set; }

        public event EventHandler ComboFilterSelectionChangedEventHandler;

        public CustomFilter()
        {
            InitializeComponent();
        }

        private void OnComboFilterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboFilterSelectionChangedEventHandler.Invoke(sender,e);
        }

        private void OnTextBoxFilterTextChanged(object sender, TextChangedEventArgs e)
        {
	        throw new NotImplementedException();
        }

        private void OnUserControlLoaded(object sender, RoutedEventArgs e)
        {
	        LblFilter.Content = LabelText;
	        CbFilter.Visibility = IsShowComboBox ? Visibility.Visible : Visibility.Hidden;
	        TxbFilter.Visibility = IsShowTextBox ? Visibility.Visible : Visibility.Hidden;
	        CbFilter.ItemsSource = ComboBoxItemSource;
	        CbFilter.SelectedIndex = 0;
        }
    }
}
