using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace Club_Organizer.Window.Main.Class
{
	class CL_create_contracts_db
	{
		public static Thread contracts = new Thread(create_db);

		static string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";
		static string query_create = "CREATE TABLE IF NOT EXISTS contracts_data " +
			"(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
			"id_client INTEGER NOT NULL, " +
			"Имя TEXT NOT NULL, " +
			"id_service INTEGER NOT NULL, " +
			"Название TEXT NOT NULL, " +
			"Тип TEXT NOT NULL, " +
			"Начало TEXT NOT NULL, " +
			"Окончание TEXT NOT NULL, " +
			"Скидка TEXT NOT NULL, " +
			"Итого TEXT NOT NULL, " +
			"Создан TEXT NOT NULL);";

		// Создание базы пользователей \\
		private static void create_db()
		{
			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path = currentPath + @"\DB";

			// Создание файла \\
			FileInfo fileInfo = new FileInfo(path + @"\contracts.db");
			try
			{
				if (fileInfo.Exists)
				{
					create_table();
				}
			}
			catch
			{
				File.Create(path + @"\contracts.db");
			}
			finally
			{
				create_table();
			}
		}

		// Создание примитива таблицы договоров \\
		private static void create_table()
		{
			string conn = @"Data Source=" + db_path + "/contracts.db;Version=3;";
			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_create, db_conn);
			cmd.ExecuteNonQuery();
			db_conn.Close();
		}
	}
}
