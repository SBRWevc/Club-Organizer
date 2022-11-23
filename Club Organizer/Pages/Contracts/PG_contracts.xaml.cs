using Club_Organizer.Pages.Contracts.Class;
using Club_Organizer.Pages.Contracts.Frames.Tennis;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Club_Organizer.Pages.Contracts
{
	public partial class PG_contracts : Page
	{
		static string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

		string conn = @"Data Source=" + db_path + "/contracts.db;Version=3;";
		public static DataTable dt_contract = new DataTable();

		public PG_contracts()
		{
			InitializeComponent();
			data_update();
		}

		// Быстрые договоры \\
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

		// Заполнение таблицы договоров \\
		private void data_update()
		{
			dt_contract = new DataTable();
			CL_contracts_info.get_info();
			data_contract.ItemsSource = dt_contract.AsDataView();
		}

		// Кнопки \\
		// Создание договора | Теннис \\
		private void tennis_Click(object sender, RoutedEventArgs e)
		{
			add_contract_dialog.IsOpen = true;
			frame_new_contract.Navigate(new FR_tennis());
		}
	}
}
