using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Club_Organizer.Pages.Contracts.Frames.Tennis.Class
{
    class CL_OT_contract_save
    {
		public static string id = "";

		public static void client_check()
		{
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/clients.db;Version=3;";
			string query = "SELECT * FROM clients_data WHERE fullname=@fullname AND Телефон=@phone";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			cmd.Parameters.AddWithValue("@fullname", FR_tennis.fullname);
			cmd.Parameters.AddWithValue("@phone", FR_tennis.phone_text);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			if (dt.Rows.Count > 0)
			{
				SQLiteDataReader dr = null;
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					id = Convert.ToString(dr.GetInt32(dr.GetOrdinal("id")));
				}
				
				CTR_service();
			}
			else
			{
				CL_tennis_new_client.new_client();
			}
		}

		private static void CTR_service()
		{
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string name = FR_tennis.lastname_text + "_" +
				FR_tennis.name_text + "_" +
				FR_tennis.secondname_text + "_" + id;

			string conn = @"Data Source=" + db_path + "/services.db;Version=3;";
			string query = "INSERT INTO " + name + " () VALUE ()";
		}
	}
}
