using System.Data.SQLite;
using System.IO;

namespace Club_Organizer.Pages.Contracts.Class
{
    class CL_contracts_info
    {
		public static void get_info()
		{
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/contracts.db;Version=3;";
			string query = "SELECT id, Имя," +
				"Название, Тип, Начало, Окончание," +
				"Скидка, Сумма, Создан FROM contracts_data";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			da.Fill(PG_contracts.dt_contract);
			db_conn.Close();
		}
	}
}
