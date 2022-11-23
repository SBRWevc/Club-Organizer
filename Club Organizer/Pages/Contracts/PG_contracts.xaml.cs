using Club_Organizer.Pages.Contracts.Frames.Tennis;
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
			if (MainWindow.fast_contract_tennis == true)
			{
				frame_new_contract.Navigate(new FR_tennis());

				await Task.Delay(100);

				add_contract_dialog.IsOpen = true;
				MainWindow.fast_contract_tennis = false;
			}
			else if (MainWindow.fast_contract_box == true)
			{
				frame_new_contract.Navigate(new FR_tennis());

				await Task.Delay(100);

				add_contract_dialog.IsOpen = true;
				MainWindow.fast_contract_box = false;
			}
			else if (MainWindow.fast_contract_gymnastic == true)
			{
				frame_new_contract.Navigate(new FR_tennis());

				await Task.Delay(100);

				add_contract_dialog.IsOpen = true;
				MainWindow.fast_contract_gymnastic = false;
			}
			else if (MainWindow.fast_contract_karate == true)
			{
				frame_new_contract.Navigate(new FR_tennis());

				await Task.Delay(100);

				add_contract_dialog.IsOpen = true;
				MainWindow.fast_contract_karate = false;
			}
		}

		private void tennis_Click(object sender, RoutedEventArgs e)
		{
			add_contract_dialog.IsOpen = true;
			frame_new_contract.Navigate(new FR_tennis());
		}
	}
}
