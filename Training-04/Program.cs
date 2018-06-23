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
			Write("Training by KeenMate \t\t\t\t\t Done by Damien Clément", ConsoleColor.Green, true);
			Matrix();
		}

		public static void Write(string text, ConsoleColor color = ConsoleColor.White, bool backToDefault = false, ConsoleColor backColor = ConsoleColor.Black)
		{
			Console.ForegroundColor = color;
			Console.BackgroundColor = backColor;
			Console.WriteLine(text);
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
			for (int x = 0; x <= bound0; x++)
			{
				for (int y = 0; y <= bound1; y++)
				{
					array[x,y] = r.Next(0, 20);
#if DEBUG
					Write("Number in array - [" + x + ";" + y + "] is = " + array[x, y],ConsoleColor.Blue,true);
#endif
					Console.WriteLine(String.Join(" ", array.Cast<int>()));
				}
			}
			Console.ReadKey();
		}
	}
}
