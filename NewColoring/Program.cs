using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewColoring
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Training by KeenMate";
			WriteConsole("Training by KeenMate \t\t\t\t\t\t\t Done by Damien Clément");
			changeColor();
		}

		public static void BackSelect()
		{
			WriteConsole("Write 0 for reset");
			string checkPress = Console.ReadLine();
			if (checkPress == "0")
			{
				changeColor();
			}
		}

		public static void WriteConsole(string write)
		{
			Console.WriteLine(write);
		}

		public static void changeColor()
		{
			Console.WriteLine("Write year");
			string check = Console.ReadLine();
			int year = int.Parse(check);
			int b = -5;
			for (int i = 0; i < 10; i++)
			{
				int newYear = year + b;
				Console.WriteLine("year - " + newYear);
				b++;
				for (int y = 0; y < 12; y++)
				{
					if (y < 4.5f && y > 1.5f)
					{
						Console.ForegroundColor = ConsoleColor.DarkGreen;
					}
					else if (y > 4.5f && y < 7.5f)
					{
						Console.ForegroundColor = ConsoleColor.DarkRed;
					}
					else if (y > 7.5f && y < 10.5f)
					{
						Console.ForegroundColor = ConsoleColor.DarkMagenta;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.DarkBlue;
					}

					if (newYear % 4 == 0)
					{
						if (y == 2)
						{
							Console.BackgroundColor = ConsoleColor.DarkBlue;
						}
						else
						{
							Console.BackgroundColor = ConsoleColor.DarkYellow;
						}
					}
					else
					{
						Console.BackgroundColor = ConsoleColor.Black;
					}

					Console.WriteLine("month - " + (y + 1));
					for (int a = 0; a < 30; a++)
					{
						Console.WriteLine("day - " + (a + 1));
					}
				}
				if(i <= 8)
				{
					Console.WriteLine("-------------------------------------------------------------");
				}
			}
			b = -5;
			BackSelect();
		}
	}
}
