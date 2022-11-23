using System.Data.SQLite;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Club_Organizer.Pages.Clients.Class;
using System.IO;

namespace Club_Organizer.Pages.Clients
{
    public partial class PG_clients : Page
    {
		static string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

		string conn = @"Data Source=" + db_path + "/clients.db;Version=3;";
		public static DataTable dt_client = new DataTable();

		public PG_clients()
		{
			InitializeComponent();
			data_update();
		}

		// Заполнение таблицы клиентов \\
		private void data_update()
		{
			dt_client = new DataTable();
			CL_clients_info.get_info();
			data_client.ItemsSource = dt_client.AsDataView();
		}

		// Кнопки \\
		// Обновление данных таблицы клиентов \\
		private void client_update_Click(object sender, RoutedEventArgs e)
		{
			dt_client = new DataTable();
			data_update();
		}
		// Обновление данных клиентов в таблице \\
		private void client_check_Click(object sender, RoutedEventArgs e)
		{
			CL_clients_info_update.update_clients_info();
			dt_client = new DataTable();
			data_update();
		}
		// Удаление записи клиента из таблицы \\
		private void client_delete_Click(object sender, RoutedEventArgs e)
		{
			if (data_client.SelectedItem == null)
			{
				return;
			}
			else
			{
				DataRowView rowView = (DataRowView)data_client.SelectedItem;
				SQLiteConnection db_conn = new SQLiteConnection(conn);
				db_conn.Open();
				using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM " +
					"clients_data WHERE ID=" + rowView["ID"], db_conn))
				{
					cmd.ExecuteNonQuery();
				}
				db_conn.Close();
				dt_client = new DataTable();
				data_update();
			}
		}
	}
}
