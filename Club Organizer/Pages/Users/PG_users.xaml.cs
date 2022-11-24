using System;
using System.Data.SQLite;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Club_Organizer.Pages.Users.Class;
using System.Windows.Data;
using System.IO;

namespace Club_Organizer.Pages.Users
{
    public partial class PG_users : Page
    {
		public static string lastname_text = "";
		public static string name_text = "";
		public static string secondname_text = "";
		public static string gender_text = "муж";
		public static string position_text = "";
		public static string login_text = "";
		public static string pass_text = "";
		public static int root_text = 0;

		static string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

		string conn = @"Data Source=" + db_path + "/users.db;Version=3;";
		public static DataTable dt_users = new DataTable();

		public PG_users()
		{
			InitializeComponent();
			data_update();

			// Настройки языков для полей \\
			InputLanguageManager.SetInputLanguage(login, CultureInfo.CreateSpecificCulture("en"));
			InputLanguageManager.SetInputLanguage(pass, CultureInfo.CreateSpecificCulture("en"));
			InputLanguageManager.SetInputLanguage(lastname, CultureInfo.CreateSpecificCulture("ru"));
			InputLanguageManager.SetInputLanguage(name, CultureInfo.CreateSpecificCulture("ru"));
			InputLanguageManager.SetInputLanguage(secondname, CultureInfo.CreateSpecificCulture("ru"));
			InputLanguageManager.SetInputLanguage(position, CultureInfo.CreateSpecificCulture("ru"));
		}

		// Получение данных пользователей \\
		public void data_update()
		{
			dt_users = new DataTable();
			CL_users_info.get_info();
			data_users.ItemsSource = dt_users.AsDataView();
		}


		// Кнопки \\
		// Обновление таблицы пользователей \\
		private void users_update_Click(object sender, RoutedEventArgs e)
		{
			dt_users = new DataTable();
			data_update();
		}
		// Обновление данных пользователя \\
		private void users_check_Click(object sender, RoutedEventArgs e)
		{
			CL_users_info_update.update_users_info();
			dt_users = new DataTable();
			data_update();
		}
		// Удаление пользователя \\
		private void users_delete_Click(object sender, RoutedEventArgs e)
		{
			if (data_users.SelectedItem == null)
			{
				return;
			}
			else
			{
				DataRowView rowView = (DataRowView)data_users.SelectedItem;
				SQLiteConnection db_conn = new SQLiteConnection(conn);
				db_conn.Open();
				using (SQLiteCommand сmd = new SQLiteCommand("DELETE FROM userdata WHERE ID=" + rowView["ID"], db_conn))
				{
					сmd.ExecuteNonQuery();
				}
				db_conn.Close();
				dt_users = new DataTable();
				data_update();
			}
		}


		// Drawer \\
		// Выбор пола \\
		// Муж \\
		private void gender_man_Click(object sender, RoutedEventArgs e)
		{
			avatar_left.Source = new BitmapImage(new Uri("/res/avatar/man.png", UriKind.Relative));
			gender_text = "муж";
		}
		// Жен \\
		private void gender_woman_Click(object sender, RoutedEventArgs e)
		{
			avatar_left.Source = new BitmapImage(new Uri("/res/avatar/woman.png", UriKind.Relative));
			gender_text = "жен";
		}
		// Запись нового пользователя \\
		private async void add_user_Click(object sender, RoutedEventArgs e)
		{
			lastname_text = lastname.Text.Trim();
			name_text = name.Text.Trim();
			secondname_text = secondname.Text.Trim();
			position_text = position.Text.Trim();
			login_text = login.Text.Trim().ToLower(); ;
			pass_text = pass.Password.Trim().ToLower();

			if (position_text == "Управляющий" || position_text == "Директор")
			{
				root_text = 1;
			}

			else
			{
				root_text = 0;
			}
			if (lastname_text == "")
			{
				lastname.Foreground = Brushes.Red;

				await Task.Delay(2000);

				lastname.Foreground = Brushes.Black;
			}
			else if (name_text == "")
			{
				name.Foreground = Brushes.Red;

				await Task.Delay(2000);

				name.Foreground = Brushes.Black;
			}
			else if (secondname_text == "")
			{
				secondname.Foreground = Brushes.Red;

				await Task.Delay(2000);

				secondname.Foreground = Brushes.Black;
			}
			else if (position_text == "")
			{
				position.Foreground = Brushes.Red;

				await Task.Delay(2000);

				position.Foreground = Brushes.Black;
			}
			else if (login_text == "")
			{
				login.Foreground = Brushes.Red;

				await Task.Delay(2000);

				login.Foreground = Brushes.Black;
			}
			else if (pass_text == "")
			{
				pass.Foreground = Brushes.Red;

				await Task.Delay(2000);

				pass.Foreground = Brushes.Black;
			}
			else
			{
				CL_users_info_check.checkinfo();

				if (CL_users_info_check.ok == false)
				{
					login.Foreground = Brushes.Red;
					login.Text = "Такой логин уже используется";

					await Task.Delay(2000);

					login.Foreground = Brushes.Black;
					login.Text = null;
				}
				else
				{
					add_user_dialog.IsOpen = false;

					dt_users = new DataTable();

					data_update();
				}
			}
		}
		// Очистка данных \\
		private void add_user_dialog_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
		{
			lastname.Text = "";
			name.Text = "";
			secondname.Text = "";
			position.Text = "";
			login.Text = "";
			pass.Password = "";

			position_left.Text = "Должность";
		}


		// Binding \\
		// Фамилия \\
		private void lastname_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (lastname.Text != "")
			{
				Binding binding = new Binding();

				binding.ElementName = "lastname";
				binding.Path = new PropertyPath("Text");
				lastname_left.SetBinding(TextBlock.TextProperty, binding);
			}
			else
			{
				lastname_left.Text = "Фамилия";
			}
		}
		// Имя \\
		private void name_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (name.Text != "")
			{
				Binding binding = new Binding();

				binding.ElementName = "name";
				binding.Path = new PropertyPath("Text");
				name_left.SetBinding(TextBlock.TextProperty, binding);
			}
			else
			{
				name_left.Text = "Имя";
			}
		}
		// Отчество \\
		private void secondname_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (secondname.Text != "")
			{
				Binding binding = new Binding();

				binding.ElementName = "secondname";
				binding.Path = new PropertyPath("Text");
				secondname_left.SetBinding(TextBlock.TextProperty, binding);
			}
			else
			{
				secondname_left.Text = "Отчество";
			}
		}
		// Должность \\
		private void position_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Binding binding = new Binding();

			binding.ElementName = "position";
			binding.Path = new PropertyPath("Text");
			position_left.SetBinding(TextBlock.TextProperty, binding);
		}
	}
}
