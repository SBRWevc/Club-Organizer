using System.IO;
using System.Threading;

namespace Club_Organizer.Window.Main.Class
{
    class CL_create_services_db
    {
		public static Thread services = new Thread(create_db);

		// Создание базы услуг \\
		private static void create_db()
		{
			string? currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			string path = currentPath + @"\DB";

			// Создание файла \\
			FileInfo fileInfo = new FileInfo(path + @"\services.db");
			if (!fileInfo.Exists)
			{
				File.Create(path + @"\services.db");
			}		
		}
	}
}
