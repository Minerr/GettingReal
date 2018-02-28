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
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
		private SupportMenuViewModel _viewModel;

        public LoginWindow(object viewModel)
        {
			_viewModel = viewModel as SupportMenuViewModel;

			InitializeComponent();
			DataContext = viewModel;
        }

		private void UserIdEnter_Click(object sender, RoutedEventArgs e)
		{
			SupportWindow supportWindow = new SupportWindow(_viewModel);
			App.Current.MainWindow.Close();
			App.Current.MainWindow = supportWindow;
			this.Close();
			supportWindow.Show();
		}
	}
}
