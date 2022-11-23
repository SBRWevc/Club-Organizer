using System.Data.SQLite;
using System.IO;

namespace Club_Organizer.Pages.Users.Class
{
    class CL_users_info_update
    {
		public static void update_users_info()
		{
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/users.db;Version=3;";
			string query = "SELECT id, Фамилия," +
				"Имя, Отчество, Пол, Должность," +
				"Права, Логин FROM userdata";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteDataAdapter da = new SQLiteDataAdapter(query, db_conn);
			SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(da);
			da.Update(PG_users.dt_users);
			db_conn.Close();
		}
	}
}
