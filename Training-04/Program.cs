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
			WriteLine("Training by KeenMate | Done by Damien Clément", ConsoleColor.Green, true, true);
			FirstMatrix();
		}

		public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White, bool center = false, bool backToDefault = false, ConsoleColor backColor = ConsoleColor.Black)
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

		public static void Write(string text, int divided,bool center = false, bool backToDefault = false, ConsoleColor backColor = ConsoleColor.Black)
		{
			float number = 20 / divided;
			int[] max = new int[(int)number];
			int[] min = new int[(int)number];
			int dividedNumber = Math.DivRem(20, divided, out dividedNumber);
			if(dividedNumber == 0)
			{
				for (int i = 0; i < number; i++)
				{
					max[i] = (int)(number * i);
					min[i] = (int)((number * i) - 4);
				}
			}
			else
			{

			}
			for (int i = 0; i < number; i++)
			{
				if (int.Parse(text) >= min[i] && int.Parse(text) <= max[i])
				{
					if(i == 0)
					{
						Console.ForegroundColor = ConsoleColor.Red;
					}
					else if(i == 1)
					{
						Console.ForegroundColor = ConsoleColor.Blue;
					}
					else if(i == 2)
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
					}
					else if(i == 3)
					{
						Console.ForegroundColor = ConsoleColor.Green;
					}
					else if(i == 4)
					{
						Console.ForegroundColor = ConsoleColor.Magenta;
					}
					else if(i == 5)
					{
						Console.ForegroundColor = ConsoleColor.Cyan;
					}
				}
			}

			Console.BackgroundColor = backColor;
			if (center)
			{
				int screenWidth = Console.WindowWidth;
				int stringWidth = text.Length;
				int spaces = (screenWidth / 2) + (stringWidth / 2);
				Console.Write(text.PadLeft(spaces));
			}
			else
			{
				Console.Write(text);
			}
			if (backToDefault)
			{
				Console.ForegroundColor = ConsoleColor.White;
			}
		}

		public static void FirstMatrix()
		{
			WriteLine("Write count rows");
			int rows = int.Parse(Console.ReadLine());
			WriteLine("Write count collumn");
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
					WriteLine("Number in array - [" + x + ";" + y + "] is = " + array[x, y],ConsoleColor.Blue,true);
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
				WriteLine(text, ConsoleColor.Green, true, true);
				text = string.Empty;
			}
			SecondMatrix();
		}

		public static void SecondMatrix()
		{
			WriteLine("Write how much the number will divided");
			int check = int.Parse(Console.ReadLine());

		}
	}
}
