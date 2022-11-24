using System.Data.SQLite;
using System.IO;

namespace Club_Organizer.Pages.Contracts.Class
{
    class CL_contracts_info_update
    {
		public static void update_info()
		{
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/contracts.db;Version=3;";
			string query = "SELECT id, Фамилия," +
				"Имя, Отчество, Паспорт, Отдел," +
				"Телефон, Email, ДР," +
				"Зарегестрирован, Администратор FROM contracts_data";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteDataAdapter da = new SQLiteDataAdapter(query, db_conn);
			SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(da);
			da.Update(PG_contracts.dt_contract);
			db_conn.Close();
		}
	}
}
