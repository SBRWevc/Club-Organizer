using Club_Organizer.Pages.Auth.Class;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Club_Organizer.Pages.Auth
{
    public partial class PG_auth : Page
    {
		public static string login_text = "";
		public static string pass_text = "";

		public PG_auth()
		{
			InitializeComponent();

			InputLanguageManager.SetInputLanguage(auth_login,
				CultureInfo.CreateSpecificCulture("en"));
			InputLanguageManager.SetInputLanguage(auth_pass,
				CultureInfo.CreateSpecificCulture("en"));
		}


		// Процесс авторизации \\
		private async void auth_data()
		{
			CL_auth.ok = false;

			login_text = auth_login.Text.Trim().ToLower();
			pass_text = auth_pass.Password.Trim().ToLower();

			CL_auth.auth();

			if (CL_auth.ok == true)
			{
				MainWindow.auth();

				auth_login.Text = "";
				auth_pass.Password = "";

				login_text = "";
				pass_text = "";
			}

			else
			{
				dialog_auth.IsOpen = true;

				auth_login.IsEnabled = false;
				auth_pass.IsEnabled = false;

				auth_login.Foreground = Brushes.Red;
				auth_pass.Foreground = Brushes.Red;

				error_text.Text = "Вы ввели неверные данные";

				await Task.Delay(3000);

				dialog_auth.IsOpen = false;
				auth_pass.Password = null;

				await Task.Delay(1500);

				auth_login.Foreground = Brushes.Black;
				auth_pass.Foreground = Brushes.Black;

				auth_login.IsEnabled = true;
				auth_pass.IsEnabled = true;
			}
		}


		// Кнопки \\
		// Авторизация \\
		private async void auth_enter_Click(object sender, RoutedEventArgs e)
		{
			if (auth_login.Text == "" && auth_pass.Password == "")
			{
				dialog_auth.IsOpen = true;

				auth_login.IsEnabled = false;
				auth_pass.IsEnabled = false;

				auth_login.Foreground = Brushes.Red;
				auth_pass.Foreground = Brushes.Red;

				error_text.Text = "Вы не ввели данные";

				await Task.Delay(3000);

				dialog_auth.IsOpen = false;

				await Task.Delay(1500);

				auth_login.Foreground = Brushes.Black;
				auth_pass.Foreground = Brushes.Black;

				auth_login.IsEnabled = true;
				auth_pass.IsEnabled = true;
			}
			else if (auth_login.Text == "" && auth_pass.Password != "")
			{
				dialog_auth.IsOpen = true;

				auth_login.IsEnabled = false;

				auth_login.Foreground = Brushes.Red;

				error_text.Text = "Вы не ввели логин";

				await Task.Delay(3000);

				dialog_auth.IsOpen = false;

				await Task.Delay(1500);

				auth_login.Foreground = Brushes.Black;

				auth_login.IsEnabled = true;
			}
			else if (auth_login.Text != "" && auth_pass.Password == "")
			{
				dialog_auth.IsOpen = true;

				auth_pass.IsEnabled = false;

				auth_pass.Foreground = Brushes.Red;

				error_text.Text = "Вы не ввели пароль";

				await Task.Delay(3000);

				dialog_auth.IsOpen = false;

				await Task.Delay(1500);

				auth_pass.Foreground = Brushes.Black;

				auth_pass.IsEnabled = true;
			}
			else if (auth_login.Text != "" && auth_pass.Password != "")
			{
				auth_data();
			}
			else
			{
				dialog_auth.IsOpen = true;

				auth_login.IsEnabled = false;
				auth_pass.IsEnabled = false;

				error_text.Text = "Слишком много попыток входа";

				await Task.Delay(3000);

				dialog_auth.IsOpen = false;

				auth_login.IsEnabled = true;
				auth_pass.IsEnabled = true;
			}
		}
		// Авторизация через ENTER \\
		private async void auth_pass_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				if (auth_login.Text == "" && auth_pass.Password == "")
				{
					dialog_auth.IsOpen = true;

					auth_login.IsEnabled = false;
					auth_pass.IsEnabled = false;

					auth_login.Foreground = Brushes.Red;
					auth_pass.Foreground = Brushes.Red;

					error_text.Text = "Вы не ввели данные";

					await Task.Delay(3000);

					dialog_auth.IsOpen = false;

					await Task.Delay(2500);

					auth_login.Foreground = Brushes.Black;
					auth_pass.Foreground = Brushes.Black;

					auth_login.IsEnabled = true;
					auth_pass.IsEnabled = true;
				}

				else if (auth_login.Text == "" && auth_pass.Password != "")
				{
					dialog_auth.IsOpen = true;

					auth_login.IsEnabled = false;

					auth_login.Foreground = Brushes.Red;

					error_text.Text = "Вы не ввели логин";

					await Task.Delay(3000);

					dialog_auth.IsOpen = false;

					await Task.Delay(2500);

					auth_login.Foreground = Brushes.Black;

					auth_login.IsEnabled = true;
				}

				else if (auth_login.Text != "" && auth_pass.Password == "")
				{
					dialog_auth.IsOpen = true;

					auth_pass.IsEnabled = false;

					auth_pass.Foreground = Brushes.Red;

					error_text.Text = "Вы не ввели пароль";

					await Task.Delay(3000);

					dialog_auth.IsOpen = false;

					await Task.Delay(2500);

					auth_pass.Foreground = Brushes.Black;

					auth_pass.IsEnabled = true;
				}

				else if (auth_login.Text != "" && auth_pass.Password != "")
				{
					auth_data();
				}

				else
				{
					dialog_auth.IsOpen = true;

					auth_login.IsEnabled = false;
					auth_pass.IsEnabled = false;

					error_text.Text = "Слишком много попыток входа";

					await Task.Delay(3000);

					dialog_auth.IsOpen = false;

					auth_login.IsEnabled = true;
					auth_pass.IsEnabled = true;
				}
			}
		}
	}
}
