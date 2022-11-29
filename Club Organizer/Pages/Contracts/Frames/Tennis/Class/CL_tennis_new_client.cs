using Club_Organizer.Window.Main.Class;
using System;
using System.Data.SQLite;
using System.IO;

namespace Club_Organizer.Pages.Contracts.Frames.Tennis.Class
{
	class CL_tennis_new_client
	{
		public static int id = 0;

		public static void new_client()
		{
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/clients.db;Version=3;";
			string query = "INSERT INTO clients_data (Фамилия, Имя, Отчество, " +
				"fullname, Паспорт, Выдан, Отдел, Город, Улица, Дом," +
				"Корпус, Квартира, Телефон, Email, ДР, Зарегестрирован, Администратор, ЧС) " +
				"VALUES (@lastname, @name, @secondname, @fullname, @passport, @passport_date, " +
				"@passport_who, @city, @street, @house, @subhouse, @flat, @phone," +
				"@email, @birthday, @registration, @admin, @blst)";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd_add = new SQLiteCommand(query, db_conn);
			cmd_add.Parameters.AddWithValue("@lastname", FR_tennis.lastname_text);
			cmd_add.Parameters.AddWithValue("@name", FR_tennis.name_text);
			cmd_add.Parameters.AddWithValue("@secondname", FR_tennis.secondname_text);
			cmd_add.Parameters.AddWithValue("@fullname", FR_tennis.fullname_text);
			cmd_add.Parameters.AddWithValue("@passport", FR_tennis.passport_num_text);
			cmd_add.Parameters.AddWithValue("@passport_date", FR_tennis.passport_date_text);
			cmd_add.Parameters.AddWithValue("@passport_who", FR_tennis.passport_who_text);
			cmd_add.Parameters.AddWithValue("@city", FR_tennis.city_text);
			cmd_add.Parameters.AddWithValue("@street", FR_tennis.street_text);
			cmd_add.Parameters.AddWithValue("@house", FR_tennis.house_text);
			cmd_add.Parameters.AddWithValue("@subhouse", FR_tennis.subhouse_text);
			cmd_add.Parameters.AddWithValue("@flat", FR_tennis.flat_text);
			cmd_add.Parameters.AddWithValue("@phone", FR_tennis.phone_text);
			cmd_add.Parameters.AddWithValue("@email", FR_tennis.email_text);
			cmd_add.Parameters.AddWithValue("@birthday", FR_tennis.birthday_text);
			cmd_add.Parameters.AddWithValue("@registration", DateTime.Today.ToString("d.M.yyyy"));
			cmd_add.Parameters.AddWithValue("@admin", CL_userdata.lastname + " " +
				CL_userdata.name.Substring(0, CL_userdata.name.Length -
				CL_userdata.name.Length + 1) + "." +
				CL_userdata.secondname.Substring(0,
				CL_userdata.secondname.Length -
				CL_userdata.secondname.Length + 1) + ".");
			cmd_add.Parameters.AddWithValue("@blst", "Нет");
			cmd_add.ExecuteNonQuery();
			db_conn.Close();

			get_id();
		}

		private static void get_id()
		{			
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/clients.db;Version=3;";
			string query = "SELECT * FROM clients_data " +
				"WHERE fullname=@fullname";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			cmd.Parameters.AddWithValue("@fullname",
				FR_tennis.fullname_text);
			SQLiteDataReader dr = null;
			dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				id = dr.GetInt32(dr.GetOrdinal("id"));
			}

			db_conn.Close();

			new_service();
		}

		private static void new_service()
		{
			string name = FR_tennis.lastname_text + "_" +
				FR_tennis.name_text + "_" +
				FR_tennis.secondname_text + "_" +
				Convert.ToString(id);

			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/services.db;Version=3;";
			string query_create = "CREATE TABLE IF NOT EXISTS " +
				name +
				"(id INTEGER PRIMARY KEY AUTOINCREMENT, " +
				"id_client TEXT NOT NULL, " +
				"Название TEXT NOT NULL, " +
				"Тип TEXT NOT NULL, " +
				"Дата TEXT NOT NULL, " +
				"day TEXT NOT NULL, " +
				"Начало TEXT NOT NULL, " +
				"Конец TEXT NOT NULL, " +
				"Часов TEXT NOT NULL, " +
				"Корт TEXT NOT NULL, " +
				"Цена TEXT NOT NULL, " +
				"Скидка TEXT NOT NULL, " +
				"Итого TEXT NOT NULL)";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd_create = new SQLiteCommand(query_create, db_conn);
			cmd_create.ExecuteNonQuery();
			db_conn.Close();
		}
	}
}
