using Club_Organizer.Pages.Contracts.Frames;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Club_Organizer.Pages.Contracts
{
	public partial class PG_contracts : Page
	{
		public PG_contracts()
		{
			InitializeComponent();
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (MainWindow.fast_contract == true)
			{
				frame_new_contract.Navigate(new FR_tennis());

				await Task.Delay(100);

				add_contract_dialog.IsOpen = true;
				MainWindow.fast_contract = false;
			}
		}

		private void tennis_Click(object sender, RoutedEventArgs e)
		{
			add_contract_dialog.IsOpen = true;
			frame_new_contract.Navigate(new FR_tennis());
		}
	}
}
