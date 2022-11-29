using Club_Organizer.Pages.Contracts.Class;
using Club_Organizer.Pages.Contracts.Frames.Tennis;
using System.Data;
using System.Data.SQLite;
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
			drawer_close();
		}


		// Быстрые договоры \\
		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (MainWindow.fast_contract_tennis == true)
			{
				frame_new_contract.Navigate(new FR_tennis());

				await Task.Delay(500);

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

		// Обработчик закрытия Drawer \\
		private async void drawer_close()
		{
			while (true)
			{
				await Task.Delay(1);
				if (FR_tennis.close == true) 
				{
					add_contract_dialog.IsOpen = false;
					FR_tennis.close = false;
				}
			}
		}


		// Кнопки \\
		// Создание договора | Теннис \\
		private void tennis_Click(object sender, RoutedEventArgs e)
		{
			add_contract_dialog.IsOpen = true;
			frame_new_contract.Navigate(new FR_tennis());
		}
		// Обновление данных таблицы договоров \\
		private void contracts_check_Click(object sender, RoutedEventArgs e)
		{
			dt_contract = new DataTable();
			data_update();
		}
		// Обновление данных договоров в таблице \\
		private void contracts_update_Click(object sender, RoutedEventArgs e)
		{
			CL_contracts_info_update.update_info();
			dt_contract = new DataTable();
			data_update();
		}
		// Удаление записи договора из таблицы \\
		private void contracts_delete_Click(object sender, RoutedEventArgs e)
		{
			if (data_contract.SelectedItem == null)
			{
				return;
			}
			else
			{
				DataRowView rowView = (DataRowView)data_contract.SelectedItem;
				SQLiteConnection db_conn = new SQLiteConnection(conn);
				db_conn.Open();
				using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM " +
					"contracts_data WHERE ID=" + rowView["ID"], db_conn))
				{
					cmd.ExecuteNonQuery();
				}
				db_conn.Close();
				dt_contract = new DataTable();
				data_update();
			}
		}
	}
}
