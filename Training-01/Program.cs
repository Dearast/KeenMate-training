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
			WriteText("Training by KeenMate \t\t\t\t\t\t\t Done by Damien Clément" , ConsoleColor.Green);
			changeColor();
		}

		public static void BackSelect()
		{
			WriteText("Write 0 for reset");
			string checkPress = Console.ReadLine();
			if (checkPress == "0")
			{
				changeColor();
			}
		}

		public static void changeColor()
		{
			WriteText("Write year");
			string check = Console.ReadLine();
			int year = int.Parse(check);
			ConsoleColor BackMonth;
			ConsoleColor Month;
			for (int i = -5; i < 5; i++)
			{
				int newYear = year + i;
				WriteText("year - " + newYear);
				for (int y = 0; y < 12; y++)
				{
					if (y < 4.5f && y > 1.5f)
					{
						Month = ConsoleColor.DarkGreen;
					}
					else if (y > 4.5f && y < 7.5f)
					{
						Month = ConsoleColor.DarkRed;
					}
					else if (y > 7.5f && y < 10.5f)
					{
						Month = ConsoleColor.DarkMagenta;
					}
					else
					{
						Month = ConsoleColor.DarkBlue;
					}

					if (newYear % 4 == 0)
					{
						BackMonth = y == 2 ? ConsoleColor.DarkBlue: ConsoleColor.DarkYellow;

						//if (y == 2)
						//{
						//	Console.BackgroundColor = ConsoleColor.DarkBlue;
						//}
						//else
						//{
						//	Console.BackgroundColor = ConsoleColor.DarkYellow;
						//}
					}
					else
					{
						BackMonth = ConsoleColor.Black;
					}

					WriteText("month - " + (y + 1), Month,BackMonth);
					for (int a = 0; a < 30; a++)
					{
						WriteText("day - " + (a + 1),Month,BackMonth);
					}
				}
				if(i <= 8)
				{
					WriteText("-------------------------------------------------------------");
				}
			}
			BackSelect();
		}
		public static void WriteText(string text, ConsoleColor color = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
		{
			Console.ForegroundColor = color;
			Console.BackgroundColor = backColor;
			Console.WriteLine(text);
		}
	}
}
