using System.Data.SQLite;
using System.IO;

namespace Club_Organizer.Pages.Clients.Class
{
    class CL_clients_info
    {
		public static void get_info()
		{
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/clients.db;Version=3;";
			string query = "SELECT id, Фамилия," +
				"Имя, Отчество, Паспорт, Отдел," +
				"Телефон, Email, ДР," +
				"Зарегестрирован, Администратор FROM clients_data WHERE ЧС=@blst";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			cmd.Parameters.AddWithValue("@blst", "Нет");
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			da.Fill(PG_clients.dt_client);
			db_conn.Close();
		}
	}
}
