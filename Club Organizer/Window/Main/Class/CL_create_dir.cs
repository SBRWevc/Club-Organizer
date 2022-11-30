using System;
using System.IO;
using System.Threading;

namespace Club_Organizer.Window.Main.Class
{
    class CL_create_dir
    {
		public static Thread backup = new Thread(create_backup_dir);
		public static Thread db = new Thread(create_DB_dir);

		// Создание пути бэкапа \\
		private static void create_backup_dir()
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

		// Создание пути БД \\
		private static void create_DB_dir()
		{
			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path = currentPath + @"\DB";

			// Создание пути \\
			DirectoryInfo dirInfo = new DirectoryInfo(path);
			if (!dirInfo.Exists)
			{
				dirInfo.Create();
			}
		}
	}
}
