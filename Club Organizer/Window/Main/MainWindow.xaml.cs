using Club_Organizer.Pages.Auth;
using Club_Organizer.Pages.Clients;
using Club_Organizer.Pages.Contracts;
using Club_Organizer.Pages.Main;
using Club_Organizer.Pages.Services;
using Club_Organizer.Pages.Users;
using Club_Organizer.Window.Main.Class;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Club_Organizer
{
	public partial class MainWindow
	{
		public static string prof_login = "";
		public static string prof_pass = "";
		public static bool fast_contract_tennis;
		public static bool fast_contract_box;
		public static bool fast_contract_gymnastic;
		public static bool fast_contract_karate;

		public MainWindow()
		{
			InitializeComponent();

			frame_main.Navigate(new PG_auth());

			// Настройки отображения \\
			main_page.Visibility = Visibility.Collapsed;
			contracts_menu.Visibility = Visibility.Collapsed;
			contracts_page.Visibility = Visibility.Collapsed;
			clients_menu.Visibility = Visibility.Collapsed;
			clients_page.Visibility = Visibility.Collapsed;
			reports_separator.Visibility = Visibility.Collapsed;
			reports_page.Visibility = Visibility.Collapsed;
			profile_menu.Visibility = Visibility.Collapsed;
			profile.Visibility = Visibility.Collapsed;
		}

		// Успешная авторизация \\
		public static void auth()
		{
			MainWindow? main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

			if (main.profile_host.IsBottomDrawerOpen != false)
			{
				main.profile_host.IsBottomDrawerOpen = false;
			}

			CL_userdata.clerdatauser();

			CL_userdata.getdatauser();

			main.main_page.Visibility = Visibility.Visible;
			main.contracts_menu.Visibility = Visibility.Visible;
			main.contracts_page.Visibility = Visibility.Visible;
			main.clients_menu.Visibility = Visibility.Visible;
			main.clients_page.Visibility = Visibility.Visible;
			main.reports_separator.Visibility = Visibility.Visible;
			main.reports_page.Visibility = Visibility.Visible;
			main.profile_menu.Visibility = Visibility.Visible;
			main.profile.Visibility = Visibility.Visible;

			main.profile.Content = CL_userdata.lastname + " " +
				CL_userdata.name.Substring(0, CL_userdata.name.Length -
				CL_userdata.name.Length + 1) + "." +
				CL_userdata.secondname.Substring(0,
				CL_userdata.secondname.Length -
				CL_userdata.secondname.Length + 1) + ".";
			main.fullname.Text = CL_userdata.lastname + " " +
				CL_userdata.name + " " + CL_userdata.secondname;
			main.profile_login.Text = CL_userdata.login;
			main.profile_position.Text = CL_userdata.position;

			if (CL_userdata.gender == "жен")
			{
				main.avatar.Source = new BitmapImage(new Uri
					("/res/avatar/woman.png", UriKind.Relative));
			}
			else if (CL_userdata.gender == "муж")
			{
				if (main.fullname.Text == "Ляхов Дмитрий Сергеевич")
				{
					main.avatar.Source = new BitmapImage(new Uri
					("/res/avatar/dev.png", UriKind.Relative));
				}
				else
				{
					main.avatar.Source = new BitmapImage(new Uri
						("/res/avatar/man.png", UriKind.Relative));
				}
			}
			else
			{
				main.avatar.Source = new BitmapImage(new Uri
					("/res/avatar/neutral.png", UriKind.Relative));
			}

			main.frame_main.Navigate(new PG_main());
		}


		// Страницы \\
		// Главная \\
		private void main_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			frame_main.Navigate(new PG_main());
		}
		// Договоры \\
		private void contracts_menu_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			contracts_menuitem.IsSubmenuOpen = true;
		}
		// Клиенты \\
		private void clients_menu_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			clients_menuitem.IsSubmenuOpen = true;
		}
		// Отчёты \\
		private void reports_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}
		}
		
		
		// Drawer \\
		// Кнопка профиля \\
		private void profile_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			profile_menuitem.IsSubmenuOpen= true;
		}
		// Обновление данных пользователя \\
		private void profile_save_button_Click(object sender, RoutedEventArgs e)
		{
			if (PG_auth.login_text == profile_login.Text && profile_pass.Password.Trim().ToLower() == "")
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			else if (PG_auth.login_text != profile_login.Text && profile_pass.Password.Trim().ToLower() == "")
			{
				prof_login = profile_login.Text.Trim().ToLower();
				CL_update_user.login_update();
				CL_userdata.getdatauser();
				profile_host.IsBottomDrawerOpen = false;
			}

			else if (PG_auth.login_text == profile_login.Text && profile_pass.Password.Trim().ToLower() != "")
			{
				prof_pass = profile_pass.Password.Trim().ToLower();
				CL_update_user.pass_update();
				CL_userdata.getdatauser();
				profile_host.IsBottomDrawerOpen = false;
			}

			else
			{
				prof_login = profile_login.Text.Trim().ToLower();
				prof_pass = profile_pass.Password.Trim().ToLower();
				CL_update_user.all_update();
				CL_userdata.getdatauser();
				profile_host.IsBottomDrawerOpen = false;
			}
		}


		// MenuItems \\
		// Меню договоров \\
		// Вызов окна создания нового договора | Теннис \\
		private void fastcontract_tennis_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			fast_contract_tennis = true;

			fast_contract_box = false;
			fast_contract_gymnastic = false;
			fast_contract_karate = false;

			frame_main.Navigate(new PG_contracts());
		}
		// Вызов окна создания нового договора | Бокс \\
		private void fastcontract_box_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			fast_contract_box = true;

			fast_contract_tennis = false;
			fast_contract_gymnastic = false;
			fast_contract_karate = false;
		}
		// Вызов окна создания нового договора | Гимнастика \\
		private void fastcontract_gymnastic_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			fast_contract_gymnastic = true;

			fast_contract_tennis = false;
			fast_contract_box = false;
			fast_contract_karate = false;
		}
		// Вызов окна создания нового договора | Карате \\
		private void fastcontract_karate_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			fast_contract_karate = true;

			fast_contract_tennis = false;
			fast_contract_box = false;
			fast_contract_gymnastic = false;
		}
		// Страница договоров \\
		private void contracts_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			frame_main.Navigate(new PG_contracts());
		}
		// Страница услуг \\
		private void services_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			frame_main.Navigate(new PG_services());
		}

		// Меню клиентов \\
		// Страница списка клиентов \\
		private void clients_list_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			frame_main.Navigate(new PG_clients());
		}
		// Страница черного списка \\
		private void blacklist_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}
		}

		// Меню профиля \\
		// Вызов окна профиля \\
		private void profile_settings_Click(object sender, RoutedEventArgs e)
		{
			profile_host.IsBottomDrawerOpen = true;
		}
		// Страница пользователей \\
		private void users_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			frame_main.Navigate(new PG_users());
		}
		// Восстановление бэкапа \\
		private void recover_Click(object sender, RoutedEventArgs e)
		{
			CL_recover.recover_services();
			CL_recover.recover_clients();
			CL_recover.recover_users();
		}
		// Выход из учётной записи \\
		private void exit_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			main_page.Visibility = Visibility.Collapsed;
			contracts_menu.Visibility = Visibility.Collapsed;
			contracts_page.Visibility = Visibility.Collapsed;
			clients_menu.Visibility = Visibility.Collapsed;
			clients_page.Visibility = Visibility.Collapsed;
			reports_separator.Visibility = Visibility.Collapsed;
			reports_page.Visibility = Visibility.Collapsed;
			profile_menu.Visibility = Visibility.Collapsed;
			profile.Visibility = Visibility.Collapsed;

			frame_main.Navigate(new PG_auth());

			CL_userdata.clerdatauser();
		}


		// Создание файлов \\
		// Базы данных \\
		private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
		{
			CL_create_users_db.create_db();
			CL_create_clients_db.create_db();
			CL_create_services_db.create_db();
			CL_create_contracts_db.create_db();
		}
		// Бэкапы \\
		private void MetroWindow_Closed(object sender, EventArgs e)
		{
			CL_create_backup.create_backup_dir();
			CL_create_backup.create_backup_services();
			CL_create_backup.create_backup_clients();
			CL_create_backup.create_backup_users();
			CL_create_backup.create_backup_contracts();
		}
	}
}
