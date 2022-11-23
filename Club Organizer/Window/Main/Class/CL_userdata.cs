using Club_Organizer.Pages.Auth.Class;
using System.Data.SQLite;
using System.IO;

namespace Club_Organizer.Window.Main.Class
{
    class CL_userdata
    {
		static string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

		static string conn = @"Data Source=" + db_path + "/users.db;Version=3;";
		static string query = "SELECT id, Фамилия, " +
			"Имя, Отчество, Пол, Должность, Права, Логин " +
			"FROM userdata WHERE @id=id";

		public static int id = CL_auth.id;
		public static string lastname = "";
		public static string name = "";
		public static string secondname = "";
		public static string gender = "";
		public static string position = "";
		public static int root = 0;
		public static string login = "";

		public static void getdatauser()
		{
			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			cmd.Parameters.AddWithValue("@id", id);
			SQLiteDataReader? dr = null;
			dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				id = dr.GetInt32(dr.GetOrdinal("id"));
				lastname = dr.GetString(dr.GetOrdinal("Фамилия"));
				name = dr.GetString(dr.GetOrdinal("Имя"));
				secondname = dr.GetString(dr.GetOrdinal("Отчество"));
				gender = dr.GetString(dr.GetOrdinal("Пол"));
				position = dr.GetString(dr.GetOrdinal("Должность"));
				root = dr.GetInt32(dr.GetOrdinal("Права"));
				login = dr.GetString(dr.GetOrdinal("Логин"));
			}

			db_conn.Close();
		}

		public static void clerdatauser()
		{
			id = CL_auth.id;
			lastname = "";
			name = "";
			secondname = "";
			gender = "";
			position = "";
			root = 0;
			login = "";
		}
	}
}
