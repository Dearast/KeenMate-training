using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_04
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Training by KeenMate";
			Write("Training by KeenMate | Done by Damien Clément", ConsoleColor.Green, true, true);
			Matrix();
		}

		public static void Write(string text, ConsoleColor color = ConsoleColor.White, bool center = false, bool backToDefault = false, ConsoleColor backColor = ConsoleColor.Black)
		{
			Console.ForegroundColor = color;
			Console.BackgroundColor = backColor;
			if (center)
			{
				int screenWidth = Console.WindowWidth;
				int stringWidth = text.Length;
				int spaces = (screenWidth / 2) + (stringWidth / 2);
				Console.WriteLine(text.PadLeft(spaces));
			}
			else
			{
				Console.WriteLine(text);
			}
			if (backToDefault)
			{
				Console.ForegroundColor = ConsoleColor.White;
			}
		}

		public static void Matrix()
		{
			Write("Write count rows");
			int rows = int.Parse(Console.ReadLine());
			Write("Write count collumn");
			Random r = new Random();
			int Collumn = int.Parse(Console.ReadLine());
			int[,] array = new int[Collumn, rows];
			int bound0 = array.GetUpperBound(0);
			int bound1 = array.GetUpperBound(1);
			string text = string.Empty;
			for (int x = 0; x <= bound0; x++)
			{
				for (int y = 0; y <= bound1; y++)
				{
					array[x,y] = r.Next(0, 20);
#if DEBUG
					Write("Number in array - [" + x + ";" + y + "] is = " + array[x, y],ConsoleColor.Blue,true);
#endif
					text += array[x, y].ToString();
					if(array[x, y] < 10)
					{
						text += "  ";
					}
					else
					{
						text += " ";
					}
				}
				Write(text, ConsoleColor.Green, true, true);
				text = string.Empty;
			}
			Console.ReadKey();
		}
	}
}
