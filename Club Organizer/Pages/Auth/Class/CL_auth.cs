﻿using System;
using System.Data.SQLite;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Windows;

namespace Club_Organizer.Pages.Auth.Class
{
    class CL_auth
    {
		static string db_path = Path.GetDirectoryName(System.Reflection.
			Assembly.GetExecutingAssembly().Location) + @"\DB";

		static string conn = @"Data Source=" + db_path + "/users.db;Version=3;";
		static string query = "SELECT * FROM userdata WHERE Логин=@login AND Пароль=@pass";

		static string login = "";
		static string pass = "";
		public static int id = 0;
		public static bool ok;

		public static void auth()
		{
			login = PG_auth.login_text;
			pass = hashPass(PG_auth.pass_text);

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			cmd.Parameters.AddWithValue("@login", login);
			cmd.Parameters.AddWithValue("@pass", pass);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			if (dt.Rows.Count > 0)
			{
				SQLiteDataReader? dr = null;
				dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					id = dr.GetInt32(dr.GetOrdinal("id"));
				}

				ok = true;
				dt.Rows.Clear();
				db_conn.Close();
			}
		}

		private static string hashPass(string password)
		{
			MD5 md5 = MD5.Create();

			byte[] b = Encoding.ASCII.GetBytes(password);
			byte[] hash = md5.ComputeHash(b);

			StringBuilder? sb = new StringBuilder();
			foreach (var a in hash)
			{
				sb.Append(a.ToString("X2"));
			}

			return Convert.ToString(sb);
		}
	}
}
