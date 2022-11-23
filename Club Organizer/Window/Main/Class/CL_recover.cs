using System;
using System.IO;

namespace Club_Organizer.Window.Main.Class
{
    class CL_recover
    {
        public static void recover_users()
        {
			string doc = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path_old = doc + @"\Ладога\Backup";

			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path_new = currentPath + @"\DB";

			// Пользователи \\
			FileInfo users = new FileInfo(path_old + @"\users.db");
			if (users.Exists)
			{
				File.Copy(path_old + @"\users.db", path_new + @"\users.db", true);
			}
		}

		public static void recover_clients()
		{
			string doc = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path_old = doc + @"\Ладога\Backup";

			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path_new = currentPath + @"\DB";

			// Клиенты \\
			FileInfo clients = new FileInfo(path_old + @"\clients.db");
			if (clients.Exists)
			{
				File.Copy(path_old + @"\clients.db", path_new + @"\clients.db", true);
			}
		}

		public static void recover_services()
		{
			string doc = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path_old = doc + @"\Ладога\Backup";

			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path_new = currentPath + @"\DB";


			// Услуги \\
			FileInfo services = new FileInfo(path_old + @"\services.db");
			if (services.Exists)
			{
				File.Copy(path_old + @"\services.db", path_new + @"\services.db", true);
			}
		}
	}
}
