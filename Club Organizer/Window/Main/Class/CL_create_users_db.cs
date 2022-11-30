using System;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Club_Organizer.Window.Main.Class
{
    class CL_create_users_db
    {
		public static Thread users = new Thread(create_db);

		static string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

		static string query_create = "CREATE TABLE IF NOT EXISTS userdata " +
			"(id INTEGER NOT NULL PRIMARY KEY UNIQUE," +
			"Фамилия TEXT NOT NULL," +
			"Имя TEXT NOT NULL," +
			"Отчество TEXT NOT NULL," +
			"Пол TEXT NOT NULL," +
			"Должность TEXT NOT NULL," +
			"Права INTEGER NOT NULL," +
			"Логин TEXT NOT NULL," +
			"Пароль TEXT NOT NULL)";
		static string query_select = "SELECT * FROM userdata WHERE " +
			"id=@id AND Логин=@login";
		static string query_insert = "INSERT INTO userdata " +
			"(id, Логин, Пароль, Имя, " +
			"Фамилия, Отчество, Должность, Пол, Права) " +
			"VALUES (@id, @login, @pass, @name, @lastname, " +
			"@secondname, @position, @gender, @root)";

		// Создание базы пользователей \\
		private static void create_db()
		{
			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path = currentPath + @"\DB";
			
			// Создание файла \\
			FileInfo fileInfo = new FileInfo(path + @"\users.db");
			try
			{
				if (fileInfo.Exists)
				{
					create_table();
				}
			}
			catch
			{
				File.Create(path + @"\users.db");
			}
			finally
			{
				create_table();
			}
		}

		// Создание примитива таблицы пользователей \\
		private static void create_table()
		{
			string conn = @"Data Source=" + db_path + "/users.db;Version=3;";
			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_create, db_conn);
			cmd.ExecuteNonQuery();
			db_conn.Close();

			check_dev();
		}

		// Проферка наличия учётки разработчика \\
		private static void check_dev()
		{
			string conn = @"Data Source=" + db_path + "/users.db;Version=3;";
			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_select, db_conn);
			cmd.Parameters.AddWithValue("@id", "1");
			cmd.Parameters.AddWithValue("@login", "dev");
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			if (dt.Rows.Count > 0)
			{
				// pass
				db_conn.Close();
			}

			else
			{
				db_conn.Close();
				create_dev();
			}
		}

		// Создание учётки разработчика
		private static void create_dev()
		{
			string pass = hashPass("admin");

			string conn = @"Data Source=" + db_path + "/users.db;Version=3;";
			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_insert, db_conn);
			cmd.Parameters.AddWithValue("@login", "dev");
			cmd.Parameters.AddWithValue("@pass", pass);
			cmd.Parameters.AddWithValue("@name", "Дмитрий");
			cmd.Parameters.AddWithValue("@lastname", "Ляхов");
			cmd.Parameters.AddWithValue("@secondname", "Сергеевич");
			cmd.Parameters.AddWithValue("@position", "Разработчик");
			cmd.Parameters.AddWithValue("@gender", "муж");
			cmd.Parameters.AddWithValue("@root", 1);
			cmd.Parameters.AddWithValue("@id", 1);
			cmd.ExecuteNonQuery();
			db_conn.Close();
		}

		// Хэширование пароля \\
		private static string hashPass(string password)
		{
			MD5 md5 = MD5.Create();

			byte[] b = Encoding.ASCII.GetBytes(password);
			byte[] hash = md5.ComputeHash(b);

			StringBuilder? sb = new StringBuilder();
			foreach (var a in hash)
			{
				sb.Append(a.ToString("X2"));
			}

			return Convert.ToString(sb);
		}
	}
}
