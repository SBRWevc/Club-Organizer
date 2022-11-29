using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;

namespace Club_Organizer.Pages.Contracts.Frames.Tennis.Class
{
    class CL_tennis_clients_info
    {
		public static string id = "";
		public static string lastname = "";
		public static string name = "";
		public static string secondname = "";
		public static string passport = "";
		public static string passport_date = "";
		public static string passport_who = "";
		public static string city = "";
		public static string street = "";
		public static string house = "";
		public static string subhouse = "";
		public static string flat = "";
		public static string phone = "";
		public static string email = "";
		public static string birthday = "";
		public static string blacklist = "";

		public static void get_info()
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
				FR_tennis.fullname);
			SQLiteDataReader dr = null;
			dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				id = Convert.ToString(dr.GetInt32(dr.GetOrdinal("id")));
				lastname = dr.GetString(dr.GetOrdinal("Фамилия"));
				name = dr.GetString(dr.GetOrdinal("Имя"));
				secondname = dr.GetString(dr.GetOrdinal("Отчество"));
				passport = dr.GetString(dr.GetOrdinal("Паспорт"));
				passport_date = dr.GetString(dr.GetOrdinal("Выдан"));
				passport_who = dr.GetString(dr.GetOrdinal("Отдел"));
				city = dr.GetString(dr.GetOrdinal("Город"));
				street = dr.GetString(dr.GetOrdinal("Улица"));
				house = dr.GetString(dr.GetOrdinal("Дом"));
				subhouse = dr.GetString(dr.GetOrdinal("Корпус"));
				flat = dr.GetString(dr.GetOrdinal("Квартира"));
				phone = dr.GetString(dr.GetOrdinal("Телефон"));
				email = dr.GetString(dr.GetOrdinal("Email"));
				birthday = dr.GetString(dr.GetOrdinal("ДР"));
				blacklist = dr.GetString(dr.GetOrdinal("ЧС"));
			}

			db_conn.Close();
		}
	}
}
