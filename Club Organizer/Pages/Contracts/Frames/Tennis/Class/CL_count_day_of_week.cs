using System;

namespace Club_Organizer.Pages.Contracts.Frames.Tennis.Class
{
    class CL_count_day_of_week
    {
		// Дни недели \\
		public static int monday = 0;
		public static int tuesday = 0;
		public static int wednesday = 0;
		public static int thursday = 0;
		public static int friday = 0;
		public static int saturday = 0;
		public static int sunday = 0;

		public static int total_days = 0;

		public static void day_count()
		{
			string date_start = FR_tennis.date_start;
			string date_end = FR_tennis.date_end;

			bool? monday_check = FR_tennis.monday_check;
			bool? tuesday_check = FR_tennis.tuesday_check;
			bool? wednesday_check = FR_tennis.wednesday_check;
			bool? thursday_check = FR_tennis.thursday_check;
			bool? friday_check = FR_tennis.friday_check;
			bool? saturday_check = FR_tennis.saturday_check;
			bool? sunday_check = FR_tennis.sunday_check;

			if (monday_check == true)
			{
				DayOfWeek day = DayOfWeek.Monday;
				DateTime start = Convert.ToDateTime(date_start);
				DateTime end = Convert.ToDateTime(date_end);
				monday = CountDays(day, start, end);
			}
			else
			{
				monday = 0;
			}

			if (tuesday_check == true)
			{
				DayOfWeek day = DayOfWeek.Tuesday;
				DateTime start = Convert.ToDateTime(date_start);
				DateTime end = Convert.ToDateTime(date_end);
				tuesday = CountDays(day, start, end);
			}
			else
			{
				tuesday = 0;
			}

			if (wednesday_check == true)
			{
				DayOfWeek day = DayOfWeek.Wednesday;
				DateTime start = Convert.ToDateTime(date_start);
				DateTime end = Convert.ToDateTime(date_end);
				wednesday = CountDays(day, start, end);
			}
			else
			{
				wednesday = 0;
			}

			if (thursday_check == true)
			{
				DayOfWeek day = DayOfWeek.Thursday;
				DateTime start = Convert.ToDateTime(date_start);
				DateTime end = Convert.ToDateTime(date_end);
				thursday = CountDays(day, start, end);
			}
			else
			{
				thursday = 0;
			}

			if (friday_check == true)
			{
				DayOfWeek day = DayOfWeek.Friday;
				DateTime start = Convert.ToDateTime(date_start);
				DateTime end = Convert.ToDateTime(date_end);
				friday = CountDays(day, start, end);
			}
			else
			{
				friday = 0;
			}

			if (saturday_check == true)
			{
				DayOfWeek day = DayOfWeek.Saturday;
				DateTime start = Convert.ToDateTime(date_start);
				DateTime end = Convert.ToDateTime(date_end);
				saturday = CountDays(day, start, end);
			}
			else
			{
				saturday = 0;
			}

			if (sunday_check == true)
			{
				DayOfWeek day = DayOfWeek.Sunday;
				DateTime start = Convert.ToDateTime(date_start);
				DateTime end = Convert.ToDateTime(date_end);
				sunday = CountDays(day, start, end);
			}
			else
			{
				sunday = 0;
			}

			total_days = monday + tuesday + wednesday + thursday + friday + saturday + sunday;
		}

		static int CountDays(DayOfWeek day, DateTime start, DateTime end)
		{
			TimeSpan ts = end - start;                       
			int count = (int)Math.Floor(ts.TotalDays / 7);   
			int remainder = (int)(ts.TotalDays % 7);         
			int sinceLastDay = (int)(end.DayOfWeek - day);   
			if (sinceLastDay < 0) sinceLastDay += 7;         

			if (remainder >= sinceLastDay) count++;

			return count;
		}
	}
}
