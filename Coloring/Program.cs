using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coloring
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

		public static void BackSelect()
		{
			Console.WriteLine("press key for call function" + "\n" + "0 = go back");
			string checkPress = Console.ReadLine();
			if (checkPress == "0")
			{
				MainMenu();
			}
		}

		public static void MainMenu()
		{
			#region Console
			Console.Clear();
			WriteText("press key for call function", "blue");
			WriteText("1 = change color by month and years");
			#endregion
			#region Functions
			string checkPress = Console.ReadLine();
			if (checkPress == "1")
			{
				changeColor();
			}
			#endregion
		}

		public static void WriteText(string text, string colorStr = "white")
		{
			switch (colorStr)
			{
				case "red":
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case "blue":
					Console.ForegroundColor = ConsoleColor.Blue;
					break;
				case "yellow":
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case "green":
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				default:
					Console.ForegroundColor = ConsoleColor.White;
					break;
			}
			Console.WriteLine(text);
		}

		public static void changeColor()
		{
			if (DateTime.Now.Month < 4.5f && DateTime.Now.Month > 1.5f)
			{
				Console.BackgroundColor = ConsoleColor.DarkGreen;
			}
			else if (DateTime.Now.Month > 4.5f && DateTime.Now.Month < 7.5f)
			{
				Console.BackgroundColor = ConsoleColor.DarkRed;
			}
			else if (DateTime.Now.Month > 7.5f && DateTime.Now.Month < 10.5f)
			{
				Console.BackgroundColor = ConsoleColor.DarkMagenta;
			}
			else
			{
				Console.BackgroundColor = ConsoleColor.DarkBlue;
			}

			if (DateTime.Now.Year % 4 == 0)
			{
				if (DateTime.Now.Month == 2)
				{
					Console.BackgroundColor = ConsoleColor.DarkBlue;
				}
				else
				{
					Console.BackgroundColor = ConsoleColor.DarkYellow;
				}
			}
			BackSelect();
		}
	}
}
