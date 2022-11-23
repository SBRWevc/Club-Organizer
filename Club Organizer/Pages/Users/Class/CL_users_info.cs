using System.Data.SQLite;
using System.IO;

namespace Club_Organizer.Pages.Users.Class
{
    class CL_users_info
    {
		public static void get_info()
		{
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/users.db;Version=3;";
			string query = "SELECT id, Фамилия," +
				"Имя, Отчество, Пол, Должность," +
				"Права, Логин FROM userdata";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			da.Fill(PG_users.dt_users);
			db_conn.Close();
		}
	}
}
