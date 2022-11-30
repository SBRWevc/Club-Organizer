using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_Organizer.Pages.Contracts.Frames.Tennis.Class
{
    class CL_contract_save
    {
        public static void CTR_service()
        {
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string name = FR_tennis.lastname_text + "_" +
				FR_tennis.name_text + "_" +
				FR_tennis.secondname_text + "_" +
				CL_tennis_clients_info.id;

			string conn = @"Data Source=" + db_path + "/services.db;Version=3;";
            string query = "INSERT INTO " + name + " () VALUE ()";
		}

        private void CTR_save()
        {
			string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

			string conn = @"Data Source=" + db_path + "/contracts.db;Version=3;";
            string query = "INSERT INTO contracts_data (id_client, Имя, id_service, Название, " +
                "Тип, Начало, Окончание, Скидка, Итого, Создан) VALUES (@id_clien, @name, @id_service, " +
                "@service_name, @type, @start, @end, @sale, @price, @create)";

            SQLiteConnection db_conn = new SQLiteConnection(conn);
            db_conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
            cmd.Parameters.AddWithValue("@id_client", CL_tennis_clients_info.id);
            cmd.Parameters.AddWithValue("@name", CL_tennis_clients_info.lastname + " " + 
                CL_tennis_clients_info.name + " " + 
                CL_tennis_clients_info.secondname);
            cmd.Parameters.AddWithValue("@id_sevice", "");
		}
    }
}
