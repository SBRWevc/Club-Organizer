using System.Data.SQLite;
using System.Data;
using System.IO;

namespace Club_Organizer.Pages.Users.Class
{
    class CL_users_info_check
    {
		public static bool ok;

		public static void checkinfo()
		{
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/users.db;Version=3;";
			string query = "SELECT Логин FROM userdata WHERE Логин=@login";
			string login = PG_users.login_text;

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			cmd.Parameters.AddWithValue("@login", login);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			if (dt.Rows.Count > 0)
			{
				ok = false;
			}

			else
			{
				ok = true;
				CL_users_new_user.newuser();
			}
		}
	}
}
