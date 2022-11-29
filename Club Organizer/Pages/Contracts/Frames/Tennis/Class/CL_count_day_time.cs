using System;

namespace Club_Organizer.Pages.Contracts.Frames.Tennis.Class
{
    class CL_count_day_time
    {
		public static double total_time = 0;

		public static void time_count()
		{
			double monday_int = 0;
			double tuesday_int = 0;
			double wednesday_int = 0;
			double thursday_int = 0;
			double friday_int = 0;
			double saturday_int = 0;
			double sunday_int = 0;

			if (FR_tennis.monday_check == true)
			{
				if (FR_tennis.monday_end_min != "" &&
					FR_tennis.monday_start_min != "" &&
					FR_tennis.monday_end_hour != "" &&
					FR_tennis.monday_start_hour != "")
				{
					if ((FR_tennis.monday_end_min == "30" || FR_tennis.monday_start_min == "30") 
						|| (FR_tennis.monday_end_min == "30" && FR_tennis.monday_start_min == "30"))
					{
						if (FR_tennis.monday_end_min == "30" && FR_tennis.monday_start_min == "30")
						{
							monday_int = Convert.ToInt32(FR_tennis.monday_end_hour) -
								Convert.ToInt32(FR_tennis.monday_start_hour);
						}
						else if (FR_tennis.monday_end_min != "30" && FR_tennis.monday_start_min == "30")
						{
							monday_int = Convert.ToInt32(FR_tennis.monday_end_hour) -
								Convert.ToInt32(FR_tennis.monday_start_hour) - 0.5;
						}
						else
						{
							monday_int = Convert.ToInt32(FR_tennis.monday_end_hour) -
								Convert.ToInt32(FR_tennis.monday_start_hour) + 0.5;
						}
					}
					else
					{
						monday_int = Convert.ToInt32(FR_tennis.monday_end_hour) -
								Convert.ToInt32(FR_tennis.monday_start_hour);
					}
				}
			}
			else
			{
				monday_int = 0;
			}

			if (FR_tennis.tuesday_check == true)
			{
				if (FR_tennis.tuesday_end_min != "" &&
					FR_tennis.tuesday_start_min != "" &&
					FR_tennis.tuesday_end_hour != "" &&
					FR_tennis.tuesday_start_hour != "")
				{
					if ((FR_tennis.tuesday_end_min == "30" || FR_tennis.tuesday_start_min == "30") 
						|| (FR_tennis.tuesday_end_min == "30" && FR_tennis.tuesday_start_min == "30"))
					{
						if (FR_tennis.tuesday_end_min == "30" && FR_tennis.tuesday_start_min == "30")
						{
							tuesday_int = Convert.ToInt32(FR_tennis.tuesday_end_hour) -
								Convert.ToInt32(FR_tennis.tuesday_start_hour);
						}
						else if (FR_tennis.tuesday_end_min != "30" && FR_tennis.tuesday_start_min == "30")
						{
							tuesday_int = Convert.ToInt32(FR_tennis.tuesday_end_hour) -
								Convert.ToInt32(FR_tennis.tuesday_start_hour) - 0.5;
						}
						else
						{
							tuesday_int = Convert.ToInt32(FR_tennis.tuesday_end_hour) -
								Convert.ToInt32(FR_tennis.tuesday_start_hour) + 0.5;
						}
					}
					else
					{
						tuesday_int = Convert.ToInt32(FR_tennis.tuesday_end_hour) -
							Convert.ToInt32(FR_tennis.tuesday_start_hour);
					}
				}
			}
			else
			{
				tuesday_int = 0;
			}

			if (FR_tennis.wednesday_check == true)
			{
				if (FR_tennis.wednesday_end_min != "" &&
					FR_tennis.wednesday_start_min != "" &&
					FR_tennis.wednesday_end_hour != "" &&
					FR_tennis.wednesday_start_hour != "")
				{
					if ((FR_tennis.wednesday_end_min == "30" || FR_tennis.wednesday_start_min == "30")
						|| (FR_tennis.wednesday_end_min == "30" && FR_tennis.wednesday_start_min == "30"))
					{
						if (FR_tennis.wednesday_end_min == "30" && FR_tennis.wednesday_start_min == "30")
						{
							wednesday_int = Convert.ToInt32(FR_tennis.wednesday_end_hour) -
								Convert.ToInt32(FR_tennis.wednesday_start_hour);
						}
						else if (FR_tennis.wednesday_end_min != "30" && FR_tennis.wednesday_start_min == "30")
						{
							wednesday_int = Convert.ToInt32(FR_tennis.wednesday_end_hour) -
								Convert.ToInt32(FR_tennis.wednesday_start_hour) - 0.5;
						}
						else
						{
							wednesday_int = Convert.ToInt32(FR_tennis.wednesday_end_hour) -
								Convert.ToInt32(FR_tennis.wednesday_start_hour) + 0.5;
						}
					}
					else
					{
						wednesday_int = Convert.ToInt32(FR_tennis.wednesday_end_hour) -
							Convert.ToInt32(FR_tennis.wednesday_start_hour);
					}
				}
			}
			else
			{
				wednesday_int = 0;
			}

			if (FR_tennis.thursday_check == true)
			{
				if (FR_tennis.thursday_end_min != "" &&
					FR_tennis.thursday_start_min != "" &&
					FR_tennis.thursday_end_hour != "" &&
					FR_tennis.thursday_start_hour != "")
				{
					if ((FR_tennis.thursday_end_min == "30" || FR_tennis.thursday_start_min == "30")
						|| (FR_tennis.thursday_end_min == "30" && FR_tennis.thursday_start_min == "30"))
					{
						if (FR_tennis.thursday_end_min == "30" && FR_tennis.thursday_start_min == "30")
						{
							thursday_int = Convert.ToInt32(FR_tennis.thursday_end_hour) -
								Convert.ToInt32(FR_tennis.thursday_start_hour);
						}
						else if (FR_tennis.thursday_end_min != "30" && FR_tennis.thursday_start_min == "30")
						{
							thursday_int = Convert.ToInt32(FR_tennis.thursday_end_hour) -
								Convert.ToInt32(FR_tennis.thursday_start_hour) - 0.5;
						}
						else
						{
							thursday_int = Convert.ToInt32(FR_tennis.thursday_end_hour) -
								Convert.ToInt32(FR_tennis.thursday_start_hour) + 0.5;
						}
					}
					else
					{
						thursday_int = Convert.ToInt32(FR_tennis.thursday_end_hour) -
							Convert.ToInt32(FR_tennis.thursday_start_hour);
					}
				}
			}
			else
			{
				thursday_int = 0;
			}

			if (FR_tennis.friday_check == true)
			{
				if (FR_tennis.friday_end_min != "" &&
					FR_tennis.friday_start_min != "" &&
					FR_tennis.friday_end_hour != "" &&
					FR_tennis.friday_start_hour != "")
				{
					if ((FR_tennis.friday_end_min == "30" || FR_tennis.friday_start_min == "30")
						|| (FR_tennis.friday_end_min == "30" && FR_tennis.friday_start_min == "30"))
					{
						if (FR_tennis.friday_end_min == "30" && FR_tennis.friday_start_min == "30")
						{
							friday_int = Convert.ToInt32(FR_tennis.friday_end_hour) -
								Convert.ToInt32(FR_tennis.friday_start_hour);
						}
						else if (FR_tennis.friday_end_min != "30" && FR_tennis.friday_start_min == "30")
						{
							friday_int = Convert.ToInt32(FR_tennis.friday_end_hour) -
								Convert.ToInt32(FR_tennis.friday_start_hour) - 0.5;
						}
						else
						{
							friday_int = Convert.ToInt32(FR_tennis.friday_end_hour) -
								Convert.ToInt32(FR_tennis.friday_start_hour) + 0.5;
						}
					}
					else
					{
						friday_int = Convert.ToInt32(FR_tennis.friday_end_hour) -
							Convert.ToInt32(FR_tennis.friday_start_hour);
					}
				}
			}
			else
			{
				friday_int = 0;
			}

			if (FR_tennis.saturday_check == true)
			{
				if (FR_tennis.saturday_end_min != "" &&
					FR_tennis.saturday_start_min != "" &&
					FR_tennis.saturday_end_hour != "" &&
					FR_tennis.saturday_start_hour != "")
				{
					if ((FR_tennis.saturday_end_min == "30" || FR_tennis.saturday_start_min == "30")
						|| (FR_tennis.saturday_end_min == "30" && FR_tennis.saturday_start_min == "30"))
					{
						if (FR_tennis.saturday_end_min == "30" && FR_tennis.saturday_start_min == "30")
						{
							saturday_int = Convert.ToInt32(FR_tennis.saturday_end_hour) -
								Convert.ToInt32(FR_tennis.saturday_start_hour);
						}
						else if (FR_tennis.saturday_end_min != "30" && FR_tennis.saturday_start_min == "30")
						{
							saturday_int = Convert.ToInt32(FR_tennis.saturday_end_hour) -
								Convert.ToInt32(FR_tennis.saturday_start_hour) - 0.5;
						}
						else
						{
							saturday_int = Convert.ToInt32(FR_tennis.saturday_end_hour) -
								Convert.ToInt32(FR_tennis.saturday_start_hour) + 0.5;
						}
					}
					else
					{
						saturday_int = Convert.ToInt32(FR_tennis.saturday_end_hour) -
							Convert.ToInt32(FR_tennis.saturday_start_hour);
					}
				}
			}
			else
			{
				saturday_int = 0;
			}

			if (FR_tennis.sunday_check == true)
			{
				if (FR_tennis.sunday_end_min != "" &&
					FR_tennis.sunday_start_min != "" &&
					FR_tennis.sunday_end_hour != "" &&
					FR_tennis.sunday_start_hour != "")
				{
					if ((FR_tennis.sunday_end_min == "30" || FR_tennis.sunday_start_min == "30")
						|| (FR_tennis.sunday_end_min == "30" && FR_tennis.sunday_start_min == "30"))
					{
						if (FR_tennis.sunday_end_min == "30" && FR_tennis.sunday_start_min == "30")
						{
							sunday_int = Convert.ToInt32(FR_tennis.sunday_end_hour) -
								Convert.ToInt32(FR_tennis.sunday_start_hour);
						}
						else if (FR_tennis.sunday_end_min != "30" && FR_tennis.saturday_start_min == "30")
						{
							sunday_int = Convert.ToInt32(FR_tennis.sunday_end_hour) -
								Convert.ToInt32(FR_tennis.sunday_start_hour) - 0.5;
						}
						else
						{
							sunday_int = Convert.ToInt32(FR_tennis.sunday_end_hour) -
								Convert.ToInt32(FR_tennis.sunday_start_hour) + 0.5;
						}
					}
					else
					{
						sunday_int = Convert.ToInt32(FR_tennis.sunday_end_hour) -
							Convert.ToInt32(FR_tennis.sunday_start_hour);
					}
				}
			}
			else
			{
				sunday_int = 0;
			}

			total_time = monday_int + tuesday_int + wednesday_int + thursday_int + friday_int + saturday_int + sunday_int;
		}
	}
}
