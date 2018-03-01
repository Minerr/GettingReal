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
using Application;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
	/// <summary>
	/// Interaction logic for SelectConsentWindow.xaml
	/// </summary>
	public partial class SelectConsentWindow : Window
	{
		SupportMenuViewModel _viewModel;

		public SelectConsentWindow(SupportMenuViewModel viewModel)
		{
			_viewModel = viewModel;

			InitializeComponent();
			DataContext = viewModel;

			RetrieveAllConsents();
		}

		private void RetrieveAllConsents()
		{
			string tableContent = ConsentAPI.RetrieveAllConsents(_viewModel.UserID);

			if(tableContent != "")
			{
				string[] table = tableContent.Split(new string[] { "|n|" }, StringSplitOptions.None);

				for(int i = 1; i < table.Length; i++)
				{
					string[] columns = table[i].Split(new string[] { "|t|" }, StringSplitOptions.None);

					string userID = columns[0];
					string permissionID = columns[1];
					string createdTime = columns[2];
					string expiredTime = columns[3];
					string legalText = columns[4];

					_viewModel.AddConsentToList(
						Convert.ToInt32(userID),
						Convert.ToInt32(permissionID),
						Convert.ToDateTime(createdTime),
						Convert.ToDateTime(expiredTime),
						legalText
						);
				}
			}
		}

		private void btnRemoveConsent_Click(object sender, RoutedEventArgs e)
		{
			ConsentAPI.RevokeConsent(_viewModel.SelectedConsent.UserID, _viewModel.SelectedConsent.PermissionID);
			_viewModel.ClearConsentList();
			this.Close();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			_viewModel.ClearConsentList();
			this.Close();
		}
	}
}