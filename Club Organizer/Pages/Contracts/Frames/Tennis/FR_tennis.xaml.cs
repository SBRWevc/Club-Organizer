using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Club_Organizer.Pages.Contracts.Frames.Tennis.Class;

namespace Club_Organizer.Pages.Contracts.Frames.Tennis
{
    public partial class FR_tennis : Page
    {
		// Данные клиента \\
		public static string id = "";
		public static string fullname = "";
		public static string lastname_text = "";
		public static string name_text = "";
		public static string secondname_text = "";
		public static string fullname_text = "";
		public static string passport_num_text = "";
		public static string passport_date_text = "";
		public static string passport_who_text = "";
		public static string city_text = "";
		public static string street_text = "";
		public static string house_text = "";
		public static string subhouse_text = "";
		public static string flat_text = "";
		public static string phone_text = "";
		public static string email_text = "";
		public static string birthday_text = "";

		// Данные разового занятия \\
		public static string OT_date_text = "";
		public static string OT_hour_text = "";
		public static string OT_minute_text = "";
		public static string OT_total_hour_text = "";
		public static string OT_court_text = "";
		public static string OT_price_text = "";
		public static string OT_sale_text = "";
		public static string OT_total_price_text = "";
		public static double OT_total_hour_doub = 0;

		// Активация дней \\
		public static bool? monday_check;
		public static bool? tuesday_check;
		public static bool? wednesday_check;
		public static bool? thursday_check;
		public static bool? friday_check;
		public static bool? saturday_check;
		public static bool? sunday_check;

		// Даты абонемента \\
		public static string date_start = "";
		public static string date_end = "";

		// Данные часов по дням \\
		// Понедельник \\
		public static string monday_start_hour = "";
		public static string monday_end_hour = "";
		public static string monday_start_min = "";
		public static string monday_end_min = "";
		// Вторник \\
		public static string tuesday_start_hour = "";
		public static string tuesday_end_hour = "";
		public static string tuesday_start_min = "";
		public static string tuesday_end_min = "";
		// Среда \\
		public static string wednesday_start_hour = "";
		public static string wednesday_end_hour = "";
		public static string wednesday_start_min = "";
		public static string wednesday_end_min = "";
		// Четверг \\
		public static string thursday_start_hour = "";
		public static string thursday_end_hour = "";
		public static string thursday_start_min = "";
		public static string thursday_end_min = "";
		// Пятница \\
		public static string friday_start_hour = "";
		public static string friday_end_hour = "";
		public static string friday_start_min = "";
		public static string friday_end_min = "";
		// Суббота \\
		public static string saturday_start_hour = "";
		public static string saturday_end_hour = "";
		public static string saturday_start_min = "";
		public static string saturday_end_min = "";
		// Воскресенье \\
		public static string sunday_start_hour = "";
		public static string sunday_end_hour = "";
		public static string sunday_start_min = "";
		public static string sunday_end_min = "";

		// Таблицы \\
		public static DataTable dt_clients_list = new DataTable();

		// Закрытие диалогового окна \\
		public static bool close;

		// Разовое или Абонемент \\
		public static bool OT_tab;
		public static bool PR_tab;


		public FR_tennis()
        {
            InitializeComponent();

			// Разовое занятие \\
			OT_total_sum();
			OT_time();

			// Абонемент \\
			PR_total_sum();
			PR_day_time();
			PR_day_count();
		}


		// Разовое занятие \\
		// Автоматический подсчёт цены \\
		private async void OT_total_sum()
		{
			while (true)
			{
				await Task.Delay(1);
				if (OT_price.Text != "" && OT_time_start_hour.Text != "" &&
					OT_time_start_min.Text != "" && OT_time_end_hour.Text != "" &&
					OT_time_end_min.Text != "")
				{
					if (OT_sale.Text != "")
					{
						OT_total_price.Text = Convert.ToString(
							Convert.ToInt32(OT_price.Text) *
							Convert.ToInt32(OT_total_hour_text) -
							Convert.ToInt32(OT_price.Text) / 100 *
							Convert.ToInt32(OT_sale.Text) *
							Convert.ToInt32(OT_total_hour_text));
					}
					else
					{
						OT_total_price.Text = Convert.ToString(
							Convert.ToInt32(OT_price.Text) *
							Convert.ToInt32(OT_total_hour_text));
					}
				}
			}
		}
		// Вывод времени \\
		private async void OT_time()
		{
			while (true)
			{
				await Task.Delay(1);

				if (OT_time_start_hour.Text != "" &&
					OT_time_start_min.Text != "" && OT_time_end_hour.Text != "" &&
					OT_time_end_min.Text != "")
				{
					if ((OT_time_end_min.Text == "30" || OT_time_start_min.Text == "30")
						|| (OT_time_end_min.Text == "30" && OT_time_start_min.Text == "30"))
					{
						if (OT_time_end_min.Text == "30" && OT_time_start_min.Text == "30")
						{
							OT_total_hour_doub = Convert.ToInt32(OT_time_end_hour.Text) -
								Convert.ToInt32(OT_time_start_hour.Text);
							OT_total_hour_text = OT_total_hour_doub.ToString();
							OT_total_hour.Text = OT_total_hour_doub.ToString();
						}
						else if (OT_time_end_min.Text != "30" && OT_time_start_min.Text == "30")
						{
							OT_total_hour_doub = Convert.ToInt32(OT_time_end_hour.Text) -
								Convert.ToInt32(OT_time_start_hour.Text) - 0.5;
							OT_total_hour_text = OT_total_hour_doub.ToString();
							OT_total_hour.Text = OT_total_hour_doub.ToString();
						}
						else
						{
							OT_total_hour_doub = Convert.ToInt32(OT_time_end_hour.Text) -
								Convert.ToInt32(OT_time_start_hour.Text) + 0.5;
							OT_total_hour_text = OT_total_hour_doub.ToString();
							OT_total_hour.Text = OT_total_hour_doub.ToString();
						}
					}
					else
					{
						OT_total_hour_doub = Convert.ToInt32(OT_time_end_hour.Text) -
								Convert.ToInt32(OT_time_start_hour.Text);
						OT_total_hour_text = OT_total_hour_doub.ToString();
						OT_total_hour.Text = OT_total_hour_doub.ToString();
					}
				}
				else
				{
					OT_total_hour.Text = "";
				}

				if (OT_time_start_hour.Text != "" && OT_time_start_min.Text != "")
				{
					OT_time_text.Text = OT_time_start_hour.Text + ":" + OT_time_start_min.Text;
				}
				else
				{
					OT_time_text.Text = "";
				}
			}
		}


		// Абонемент \\
		// Автоматический подсчёт цены \\
		private async void PR_total_sum()
		{
			while (true)
			{				
				await Task.Delay(1);
				if (PR_date_start.Text != "" && PR_date_end.Text != "" &&
					PR_price.Text != "")
				{
					if (PR_sale.Text != "")
					{
						PR_total_price.Text = Convert.ToString(
							Convert.ToInt32(PR_price.Text) * CL_count_day_of_week.total_days * 
							CL_count_day_time.total_time / 100 * (100 - Convert.ToInt32(PR_sale.Text)));
					}
					else
					{
						PR_total_price.Text = Convert.ToString(
							Convert.ToInt32(PR_price.Text) * CL_count_day_of_week.total_days * CL_count_day_time.total_time);
					}
				}
			}
		}
		// Часы по дням \\
		private async void PR_day_time()
		{
			while (true)
			{
				await Task.Delay(1);

				monday_check = PR_monday.IsChecked;

				monday_start_hour = PR_monday_start_hour.Text;
				monday_end_hour = PR_monday_end_hour.Text;
				monday_start_min = PR_monday_start_min.Text;
				monday_end_min = PR_monday_end_min.Text;

				tuesday_check = PR_tuesday.IsChecked;

				tuesday_start_hour = PR_tuesday_start_hour.Text;
				tuesday_end_hour = PR_tuesday_end_hour.Text;
				tuesday_start_min = PR_tuesday_start_min.Text;
				tuesday_end_min = PR_tuesday_end_min.Text;

				wednesday_check = PR_wednesday.IsChecked;

				wednesday_start_hour = PR_wednesday_start_hour.Text;
				wednesday_end_hour = PR_wednesday_end_hour.Text;
				wednesday_start_min = PR_wednesday_start_min.Text;
				wednesday_end_min = PR_wednesday_end_min.Text;

				thursday_check = PR_thursday.IsChecked;

				thursday_start_hour = PR_thursday_start_hour.Text;
				thursday_end_hour = PR_thursday_end_hour.Text;
				thursday_start_min = PR_thursday_start_min.Text;
				thursday_end_min = PR_thursday_end_min.Text;

				friday_check = PR_friday.IsChecked;

				friday_start_hour = PR_friday_start_hour.Text;
				friday_end_hour = PR_friday_end_hour.Text;
				friday_start_min = PR_friday_start_min.Text;
				friday_end_min = PR_friday_end_min.Text;

				saturday_check = PR_saturday.IsChecked;

				saturday_start_hour = PR_saturday_start_hour.Text;
				saturday_end_hour = PR_saturday_end_hour.Text;
				saturday_start_min = PR_saturday_start_min.Text;
				saturday_end_min = PR_saturday_end_min.Text;

				sunday_check = PR_sunday.IsChecked;

				sunday_start_hour = PR_sunday_start_hour.Text;
				sunday_end_hour = PR_sunday_end_hour.Text;
				sunday_start_min = PR_sunday_start_min.Text;
				sunday_end_min = PR_sunday_end_min.Text;

				CL_count_day_time.time_count();

				time_count.Text = Convert.ToString(CL_count_day_time.total_time * CL_count_day_of_week.total_days);
			}
		}
		// Кол-во дней \\
		private async void PR_day_count()
		{
			while (true)
			{
				await Task.Delay(1);
				if (PR_date_start.Text != "" && PR_date_end.Text != "")
				{
					date_start = PR_date_start.Text;
					date_end = PR_date_end.Text;

					monday_check = PR_monday.IsChecked;
					tuesday_check = PR_tuesday.IsChecked;
					wednesday_check = PR_wednesday.IsChecked;
					thursday_check = PR_thursday.IsChecked;
					friday_check = PR_friday.IsChecked;
					saturday_check = PR_saturday.IsChecked;
					sunday_check = PR_sunday.IsChecked;

					CL_count_day_of_week.day_count();

					day_count.Text = Convert.ToString(CL_count_day_of_week.total_days);
				}
				else
				{
					day_count.Text = "";
				}
			}
		}


		// Combobox \\
		// Заполнение \\
		private void CLT_search_Loaded(object sender, RoutedEventArgs e)
		{
			dt_clients_list = new DataTable();

			CL_bind_combobox.BindComboBox(CLT_search);
			CLT_search.ItemsSource = dt_clients_list.AsDataView();
			CLT_search.DisplayMemberPath = "fullname";
			CLT_search.SelectedValuePath = "id";
		}


		// Кнопки \\
		// Поиск клиента \\
		private async void CLT_check_Click(object sender, RoutedEventArgs e)
		{
			if (CLT_search.Text != "")
			{
				if (CLT_search.Text != "Вы не выбрали клиента")
				{
					fullname = CLT_search.Text;
					CL_tennis_clients_info.get_info();

					if (CL_tennis_clients_info.blacklist != "Да")
					{
						CLT_lastname.Text = CL_tennis_clients_info.lastname;
						CLT_name.Text = CL_tennis_clients_info.name;
						CLT_secondname.Text = CL_tennis_clients_info.secondname;
						CLT_passport_num.Text = CL_tennis_clients_info.passport;
						CLT_passport_date.Text = CL_tennis_clients_info.passport_date;
						CLT_passport_who.Text = CL_tennis_clients_info.passport_who;
						CLT_city.Text = CL_tennis_clients_info.city;
						CLT_street.Text = CL_tennis_clients_info.street;
						CLT_house.Text = Convert.ToString(CL_tennis_clients_info.house);
						CLT_subhouse.Text = CL_tennis_clients_info.subhouse;
						CLT_flat.Text = Convert.ToString(CL_tennis_clients_info.flat);
						CLT_phone.Text = CL_tennis_clients_info.phone;
						CLT_email.Text = CL_tennis_clients_info.email;
						CLT_birthday.Text = CL_tennis_clients_info.birthday;
					}
					else
					{
						CT_error_dialog.IsOpen = true;

						error_text.Text = "Данный пользователь в чёрном списке";

						await Task.Delay(3000);

						CT_error_dialog.IsOpen = false;
					}
				}
				else
				{
					// pass
				}
			}
			else
			{
				CT_error_dialog.IsOpen = true;

				error_text.Text = "Вы не выбрали клиента";

				await Task.Delay(3000);

				CT_error_dialog.IsOpen = false;
			}
		}
		// Создание нового клиента \\
		private async void CLT_write_Click(object sender, RoutedEventArgs e)
		{
			lastname_text = CLT_lastname.Text.Trim();
			name_text = CLT_name.Text.Trim();
			secondname_text = CLT_secondname.Text.Trim();
			fullname_text = CLT_lastname.Text.Trim() + " " +
				CLT_name.Text.Trim() + " " +
				CLT_secondname.Text.Trim();
			passport_num_text = CLT_passport_num.Text.Trim();
			passport_date_text = CLT_passport_date.Text.Trim();
			passport_who_text = CLT_passport_who.Text.Trim();
			city_text = CLT_city.Text.Trim();
			street_text = CLT_street.Text.Trim();
			house_text = CLT_house.Text.Trim();
			subhouse_text = CLT_subhouse.Text.Trim();
			flat_text = CLT_flat.Text.Trim();
			phone_text = CLT_phone.Text.Trim();
			email_text = CLT_email.Text.Trim();
			birthday_text = CLT_birthday.Text.Trim();

			if (lastname_text == "" || name_text == "" || secondname_text == "" ||
				fullname_text == "" || passport_num_text == "" || passport_date_text == "" ||
				passport_who_text == "" || city_text == "" || street_text == "" ||
				house_text == "" || subhouse_text == "" || flat_text == "" ||
				phone_text == "" || email_text == "" || birthday_text == "")
			{
				CT_error_dialog.IsOpen = true;

				error_text.Text = "Вы заполнили не все данные клиента";

				await Task.Delay(3000);

				CT_error_dialog.IsOpen = false;
			}
			else
			{
				CL_tennis_new_client.client_check();

				if (CL_tennis_new_client.error == true)
				{
					CT_error_dialog.IsOpen = true;

					error_text.Text = "Такой клиент уже есть";

					await Task.Delay(3000);

					CT_error_dialog.IsOpen = false;

					CL_tennis_new_client.error = false;
				}
				else
				{
					dt_clients_list = new DataTable();

					CL_bind_combobox.BindComboBox(CLT_search);
					CLT_search.ItemsSource = dt_clients_list.AsDataView();
					CLT_search.DisplayMemberPath = "fullname";
					CLT_search.SelectedValuePath = "id";
				}
			}
		}
		// Очитска данных клиента \\
		private void CLT_clear_Click(object sender, RoutedEventArgs e)
		{
			CLT_lastname.Text = "";
			CLT_name.Text = "";
			CLT_secondname.Text = "";
			CLT_passport_num.Text = "";
			CLT_passport_date.Text = "";
			CLT_passport_who.Text = "";
			CLT_city.Text = "";
			CLT_street.Text = "";
			CLT_house.Text = "";
			CLT_subhouse.Text = "";
			CLT_flat.Text = "";
			CLT_phone.Text = "";
			CLT_email.Text = "";
			CLT_birthday.Text = "";
		}
		// Закрытие окна \\
		private void CT_close_drawer_Click(object sender, RoutedEventArgs e)
		{
			MainWindow.drawer_close();
        }
		// Сохранение договора \\
		private async void CT_save_Click(object sender, RoutedEventArgs e)
		{
			lastname_text = CLT_lastname.Text.Trim();
			name_text = CLT_name.Text.Trim();
			secondname_text = CLT_secondname.Text.Trim();
			fullname_text = CLT_lastname.Text.Trim() + " " +
				CLT_name.Text.Trim() + " " +
				CLT_secondname.Text.Trim();
			passport_num_text = CLT_passport_num.Text.Trim();
			passport_date_text = CLT_passport_date.Text.Trim();
			passport_who_text = CLT_passport_who.Text.Trim();
			city_text = CLT_city.Text.Trim();
			street_text = CLT_street.Text.Trim();
			house_text = CLT_house.Text.Trim();
			subhouse_text = CLT_subhouse.Text.Trim();
			flat_text = CLT_flat.Text.Trim();
			phone_text = CLT_phone.Text.Trim();
			email_text = CLT_email.Text.Trim();
			birthday_text = CLT_birthday.Text.Trim();

			if (lastname_text == "" || name_text == "" || secondname_text == "" ||
				fullname_text == "" || passport_num_text == "" || passport_date_text == "" ||
				passport_who_text == "" || city_text == "" || street_text == "" ||
				house_text == "" || subhouse_text == "" || flat_text == "" ||
				phone_text == "" || email_text == "" || birthday_text == "")
			{
				CT_error_dialog.IsOpen = true;

				error_text.Text = "Вы заполнили не все данные клиента";

				await Task.Delay(3000);

				CT_error_dialog.IsOpen = false;
			}
			else
			{
				if (OT.IsSelected == true)
				{
					if (OT_date.Text == "" || OT_time_start_hour.Text == "" || OT_time_start_min.Text == "" ||
						OT_time_end_hour.Text == "" || OT_time_end_min.Text == "" || OT_court.Text == "" ||
						OT_price.Text == "" || OT_sale.Text == "")
					{
						CT_error_dialog.IsOpen = true;

						error_text.Text = "Вы заполнили не все данные разовой услуги";

						await Task.Delay(3000);

						CT_error_dialog.IsOpen = false;
					}
					else
					{
						CL_OT_contract_save.client_check();
					}
				}
			}
		}
		// Распечатка договора \\
		private void CT_print_Click(object sender, RoutedEventArgs e)
		{

		}
		// Откртиые договора в WORD \\
		private void CT_open_Click(object sender, RoutedEventArgs e)
		{

		}


		// Чекбоксы \\
		// Понедельник \\
		private void PR_monday_Click(object sender, RoutedEventArgs e)
		{
			if (PR_monday.IsChecked == true)
			{
				PR_monday_start_hour.IsEnabled = true;
				PR_monday_start_min.IsEnabled = true;
				PR_monday_end_hour.IsEnabled = true;
				PR_monday_end_min.IsEnabled = true;
			}
			else
			{
				PR_monday_start_hour.IsEnabled = false;
				PR_monday_start_hour.Text = "";
				PR_monday_start_min.IsEnabled = false;
				PR_monday_start_min.Text = "";
				PR_monday_end_hour.IsEnabled = false;
				PR_monday_end_hour.Text = "";
				PR_monday_end_min.IsEnabled = false;
				PR_monday_end_min.Text = "";
			}
		}
		// Вторник \\
		private void PR_tuesday_Click(object sender, RoutedEventArgs e)
		{
			if (PR_tuesday.IsChecked == true)
			{
				PR_tuesday_start_hour.IsEnabled = true;
				PR_tuesday_start_min.IsEnabled = true;
				PR_tuesday_end_hour.IsEnabled = true;
				PR_tuesday_end_min.IsEnabled = true;
			}
			else
			{
				PR_tuesday_start_hour.IsEnabled = false;
				PR_tuesday_start_hour.Text = "";
				PR_tuesday_start_min.IsEnabled = false;
				PR_tuesday_start_min.Text = "";
				PR_tuesday_end_hour.IsEnabled = false;
				PR_tuesday_end_hour.Text = "";
				PR_tuesday_end_min.IsEnabled = false;
				PR_tuesday_end_min.Text = "";
			}
		}
		// Среда \\
		private void PR_wednesday_Click(object sender, RoutedEventArgs e)
		{
			if (PR_wednesday.IsChecked == true)
			{
				PR_wednesday_start_hour.IsEnabled = true;
				PR_wednesday_start_min.IsEnabled = true;
				PR_wednesday_end_hour.IsEnabled = true;
				PR_wednesday_end_min.IsEnabled = true;
			}
			else
			{
				PR_wednesday_start_hour.IsEnabled = false;
				PR_wednesday_start_hour.Text = "";
				PR_wednesday_start_min.IsEnabled = false;
				PR_wednesday_start_min.Text = "";
				PR_wednesday_end_hour.IsEnabled = false;
				PR_wednesday_end_hour.Text = "";
				PR_wednesday_end_min.IsEnabled = false;
				PR_wednesday_end_min.Text = "";
			}
		}
		// Четверг \\
		private void PR_thursday_Click(object sender, RoutedEventArgs e)
		{
			if (PR_thursday.IsChecked == true)
			{
				PR_thursday_start_hour.IsEnabled = true;
				PR_thursday_start_min.IsEnabled = true;
				PR_thursday_end_hour.IsEnabled = true;
				PR_thursday_end_min.IsEnabled = true;
			}
			else
			{
				PR_thursday_start_hour.IsEnabled = false;
				PR_thursday_start_hour.Text = "";
				PR_thursday_start_min.IsEnabled = false;
				PR_thursday_start_min.Text = "";
				PR_thursday_end_hour.IsEnabled = false;
				PR_thursday_end_hour.Text = "";
				PR_thursday_end_min.IsEnabled = false;
				PR_thursday_end_min.Text = "";
			}
		}
		// Пятница \\
		private void PR_friday_Click(object sender, RoutedEventArgs e)
		{
			if (PR_friday.IsChecked == true)
			{
				PR_friday_start_hour.IsEnabled = true;
				PR_friday_start_min.IsEnabled = true;
				PR_friday_end_hour.IsEnabled = true;
				PR_friday_end_min.IsEnabled = true;
			}
			else
			{
				PR_friday_start_hour.IsEnabled = false;
				PR_friday_start_hour.Text = "";
				PR_friday_start_min.IsEnabled = false;
				PR_friday_start_min.Text = "";
				PR_friday_end_hour.IsEnabled = false;
				PR_friday_end_hour.Text = "";
				PR_friday_end_min.IsEnabled = false;
				PR_friday_end_min.Text = "";
			}
		}
		// Суббота \\
		private void PR_saturday_Click(object sender, RoutedEventArgs e)
		{
			if (PR_saturday.IsChecked == true)
			{
				PR_saturday_start_hour.IsEnabled = true;
				PR_saturday_start_min.IsEnabled = true;
				PR_saturday_end_hour.IsEnabled = true;
				PR_saturday_end_min.IsEnabled = true;
			}
			else
			{
				PR_saturday_start_hour.IsEnabled = false;
				PR_saturday_start_hour.Text = "";
				PR_saturday_start_min.IsEnabled = false;
				PR_saturday_start_min.Text = "";
				PR_saturday_end_hour.IsEnabled = false;
				PR_saturday_end_hour.Text = "";
				PR_saturday_end_min.IsEnabled = false;
				PR_saturday_end_min.Text = "";
			}
		}
		// Воскресенье \\
		private void PR_sunday_Click(object sender, RoutedEventArgs e)
		{
			if (PR_sunday.IsChecked == true)
			{
				PR_sunday_start_hour.IsEnabled = true;
				PR_sunday_start_min.IsEnabled = true;
				PR_sunday_end_hour.IsEnabled = true;
				PR_sunday_end_min.IsEnabled = true;
			}
			else
			{
				PR_sunday_start_hour.IsEnabled = false;
				PR_sunday_start_hour.Text = "";
				PR_sunday_start_min.IsEnabled = false;
				PR_sunday_start_min.Text = "";
				PR_sunday_end_hour.IsEnabled = false;
				PR_sunday_end_hour.Text = "";
				PR_sunday_end_min.IsEnabled = false;
				PR_sunday_end_min.Text = "";
			}
		}


		// Переключени вкладок \\
		private void CT_TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (OT.IsSelected == true)
			{
				PR_date_start.Text = "";
				PR_date_end.Text = "";
				PR_court.Text = "";
				PR_price.Text = "";
				PR_sale.Text = "";

				PR_monday.IsChecked = false;
				PR_monday_start_hour.IsEnabled = false;
				PR_monday_start_hour.Text = "";
				PR_monday_start_min.IsEnabled = false;
				PR_monday_start_min.Text = "";
				PR_monday_end_hour.IsEnabled = false;
				PR_monday_end_hour.Text = "";
				PR_monday_end_min.IsEnabled = false;
				PR_monday_end_min.Text = "";

				PR_tuesday.IsChecked = false;
				PR_tuesday_start_hour.IsEnabled = false;
				PR_tuesday_start_hour.Text = "";
				PR_tuesday_start_min.IsEnabled = false;
				PR_tuesday_start_min.Text = "";
				PR_tuesday_end_hour.IsEnabled = false;
				PR_tuesday_end_hour.Text = "";
				PR_tuesday_end_min.IsEnabled = false;
				PR_tuesday_end_min.Text = "";

				PR_wednesday.IsChecked = false;
				PR_wednesday_start_hour.IsEnabled = false;
				PR_wednesday_start_hour.Text = "";
				PR_wednesday_start_min.IsEnabled = false;
				PR_wednesday_start_min.Text = "";
				PR_wednesday_end_hour.IsEnabled = false;
				PR_wednesday_end_hour.Text = "";
				PR_wednesday_end_min.IsEnabled = false;
				PR_wednesday_end_min.Text = "";

				PR_thursday.IsChecked = false;
				PR_thursday_start_hour.IsEnabled = false;
				PR_thursday_start_hour.Text = "";
				PR_thursday_start_min.IsEnabled = false;
				PR_thursday_start_min.Text = "";
				PR_thursday_end_hour.IsEnabled = false;
				PR_thursday_end_hour.Text = "";
				PR_thursday_end_min.IsEnabled = false;
				PR_thursday_end_min.Text = "";

				PR_friday.IsChecked = false;
				PR_friday_start_hour.IsEnabled = false;
				PR_friday_start_hour.Text = "";
				PR_friday_start_min.IsEnabled = false;
				PR_friday_start_min.Text = "";
				PR_friday_end_hour.IsEnabled = false;
				PR_friday_end_hour.Text = "";
				PR_friday_end_min.IsEnabled = false;
				PR_friday_end_min.Text = "";

				PR_saturday.IsChecked = false;
				PR_saturday_start_hour.IsEnabled = false;
				PR_saturday_start_hour.Text = "";
				PR_saturday_start_min.IsEnabled = false;
				PR_saturday_start_min.Text = "";
				PR_saturday_end_hour.IsEnabled = false;
				PR_saturday_end_hour.Text = "";
				PR_saturday_end_min.IsEnabled = false;
				PR_saturday_end_min.Text = "";

				PR_sunday.IsChecked = false;
				PR_sunday_start_hour.IsEnabled = false;
				PR_sunday_start_hour.Text = "";
				PR_sunday_start_min.IsEnabled = false;
				PR_sunday_start_min.Text = "";
				PR_sunday_end_hour.IsEnabled = false;
				PR_sunday_end_hour.Text = "";
				PR_sunday_end_min.IsEnabled = false;
				PR_sunday_end_min.Text = "";
			}
			else if (PR.IsSelected == true)
			{
				OT_date.Text = "";
				OT_time_start_hour.Text = "";
				OT_time_start_min.Text = "";
				OT_time_end_hour.Text = "";
				OT_time_end_min.Text = "";
				OT_court.Text = "";
				OT_price.Text = "";
				OT_sale.Text = "";
			}
		}


		// Ограничения TextBox \\
		private void digital_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}
	}
}
