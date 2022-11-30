using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace Club_Organizer.Window.Main.Class
{
    class CL_create_clients_db
    {
		public static Thread clients = new Thread(create_db);

		static string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";
		static string query_create = "CREATE TABLE IF NOT EXISTS clients_data " +
			"(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
			"Фамилия TEXT NOT NULL," +
			"Имя TEXT NOT NULL," +
			"Отчество TEXT NOT NULL," +
			"fullname TEXT NOT NULL," +
			"Паспорт TEXT NOT NULL," +
			"Выдан TEXT NOT NULL," +
			"Отдел TEXT NOT NULL," +
			"Город TEXT NOT NULL," +
			"Улица TEXT NOT NULL," +
			"Дом TEXT NOT NULL," +
			"Корпус TEXT NOT NULL," +
			"Квартира TEXT NOT NULL," +
			"Телефон TEXT NOT NULL," +
			"Email TEXT NOT NULL," +
			"ДР TEXT NOT NULL," +
			"Зарегестрирован TEXT NOT NULL," +
			"Администратор TEXT NOT NULL," +
			"ЧС TEXT NOT NULL);";

		// Создание базы клиентов \\
		private static void create_db()
		{
			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path = currentPath + @"\DB";

			// Создание файла \\
			FileInfo fileInfo = new FileInfo(path + @"\clients.db");
			try
			{
				if (fileInfo.Exists)
				{
					create_table();
				}
			}
			catch
			{
				File.Create(path + @"\clients.db");
			}
			finally
			{
				create_table();
			}
		}

		// Создание примитива таблицы клиентов \\
		private static void create_table()
		{
			string conn = @"Data Source=" + db_path + "/clients.db;Version=3;";
			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_create, db_conn);
			cmd.ExecuteNonQuery();
			db_conn.Close();
		}
	}
}
