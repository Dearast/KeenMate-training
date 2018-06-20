using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipSport
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Title = "Training by KeenMate                                   Done by Damien Clément";
			MainMenu();
		}

		public static void MainMenu()
		{
			#region Console
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("press key for call function");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("1 = tip sport");
			#endregion
			#region Functions
			string checkPress = Console.ReadLine();
			if (checkPress == "1")
			{
				tipSport();
			}
			#endregion
		}

		public static void tipSport()
		{
			Random r = new Random();
			int[] random = new int[10];
			int succes = 0;
			for (int i = 0; i < random.Length; i++)
			{
				random[i] = r.Next(0, 100);
			}
			string[] player = new string[3];
			for (int i = 0; i < player.Length; i++)
			{
				player[i] = Console.ReadLine();
			}
			int[] tips = new int[player.Length];
			for (int i = 0; i < tips.Length; i++)
			{
				tips[i] = int.Parse(player[i]);
				for (int y = 0; y < random.Length; y++)
				{
					if (tips[i] == random[y])
					{
						succes++;
					}
				}
			}
			float value = succes / player.Length;
			Console.WriteLine("succes tips " + value);
			Console.WriteLine("if you want to show all number then push 0");
			string check = Console.ReadLine();
			if (check == "0")
			{
				for (int i = 0; i < random.Length; i++)
				{
					Console.WriteLine("number " + (i + 1) + " - " + random[i]);
				}
				BackSelect();
			}
			else
			{
				BackSelect();
			}
		}

		public static void BackSelect()
		{
			Console.WriteLine("press key for call function" + "\n" + "0 = go back");
			string checkPress = Console.ReadLine();
			if (checkPress == "0")
			{
				MainMenu();
			}
		}
	}
}
