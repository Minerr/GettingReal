using Application;
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
    /// Interaction logic for SupportWindow.xaml
    /// </summary>
    public partial class SupportWindow : Window
    {
		private SupportMenuViewModel _supportVM;


		public SupportWindow(SupportMenuViewModel supportVM)
        {
			_supportVM = supportVM;
			InitializeComponent();
			DataContext = supportVM;
        }

		private void CreatePermissionRequest(object sender, RoutedEventArgs e)
		{
			SelectPermissionWindow selectPermissionWindow = new SelectPermissionWindow(_supportVM);
			selectPermissionWindow.Show();
		}

		private void RetrieveAllConsents(object sender, RoutedEventArgs e)
		{
			SelectConsentWindow selectConsentWindow = new SelectConsentWindow(_supportVM);
			selectConsentWindow.Show();
		}
	}
}
