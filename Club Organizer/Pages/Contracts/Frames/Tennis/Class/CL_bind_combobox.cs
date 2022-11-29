using System.Data.SQLite;
using System.Windows.Controls;
using System.IO;

namespace Club_Organizer.Pages.Contracts.Frames.Tennis.Class
{
    class CL_bind_combobox
    {
		public static void BindComboBox(ComboBox comboBoxName)
		{
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/clients.db;Version=3;";
			string query_client_name = "SELECT id, fullname " +
				"FROM clients_data";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteDataAdapter da = new SQLiteDataAdapter(query_client_name, db_conn);
			da.Fill(FR_tennis.dt_clients_list);
			db_conn.Close();
		}
	}
}
