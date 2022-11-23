using System.IO;

namespace Club_Organizer.Window.Main.Class
{
    class CL_create_services_db
    {
		// Создание базы услуг \\
		public static void create_db()
		{
			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path = currentPath + @"\DB";

			// Создание пути \\
			DirectoryInfo dirInfo = new DirectoryInfo(path);
			if (!dirInfo.Exists)
			{
				dirInfo.Create();
			}

			// Создание файла \\
			FileInfo fileInfo = new FileInfo(path + @"\services.db");
			if (!fileInfo.Exists)
			{
				File.Create(path + @"\services.db");
			}		
		}
	}
}
