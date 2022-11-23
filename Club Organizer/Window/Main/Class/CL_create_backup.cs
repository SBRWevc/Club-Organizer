using System;
using System.IO;
using System.Windows;

namespace Club_Organizer.Window.Main.Class
{
    class CL_create_backup
    {
		// Создание пути бэкапа \\
		public static void create_backup_dir()
		{
			string doc = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path_new = doc + @"\Ладога\Backup";

			// Создание пути \\
			DirectoryInfo dirInfo = new DirectoryInfo(path_new);
			if (!dirInfo.Exists)
			{
				dirInfo.Create();
			}	
		}

		// Создание бэкапа услуг \\
		public static void create_backup_services()
		{
			string doc = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path_new = doc + @"\Ладога\Backup";

			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path_old = currentPath + @"\DB";


			// Услуги \\
			FileInfo services = new FileInfo(path_old + @"\services.db");
			if (services.Exists)
			{
				File.Copy(path_old + @"\services.db", path_new + @"\services.db", true);
			}
		}

		// Создание бэкапа клиентов \\
		public static void create_backup_clients()
		{
			string doc = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path_new = doc + @"\Ладога\Backup";

			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path_old = currentPath + @"\DB";

			// Клиенты \\
			FileInfo clients = new FileInfo(path_old + @"\clients.db");
			if (clients.Exists)
			{
				File.Copy(path_old + @"\clients.db", path_new + @"\clients.db", true);
			}
		}

		// Создание бэкапа пользователей \\
		public static void create_backup_users()
		{
			string doc = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path_new = doc + @"\Ладога\Backup";

			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path_old = currentPath + @"\DB";

			// Пользователи \\
			FileInfo users = new FileInfo(path_old + @"\users.db");
			if (users.Exists)
			{
				File.Copy(path_old + @"\users.db", path_new + @"\users.db", true);
			}
		}

		// Создание бэкапа договоров \\
		public static void create_backup_contracts()
		{
			string doc = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path_new = doc + @"\Ладога\Backup";

			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path_old = currentPath + @"\DB";

			// Пользователи \\
			FileInfo users = new FileInfo(path_old + @"\contracts.db");
			if (users.Exists)
			{
				File.Copy(path_old + @"\contracts.db", path_new + @"\contracts.db", true);
			}
		}
	}
}
