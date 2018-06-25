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
			Create2DArray();
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

		public static void Write(string text, ConsoleColor color = ConsoleColor.White,bool center = false, bool backToDefault = false, ConsoleColor backColor = ConsoleColor.Black)
		{
			Console.ForegroundColor = color;
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

		public static void Create2DArray()
		{
			WriteLine("Write count rows");
			int rows = int.Parse(Console.ReadLine());
			WriteLine("Write count collumn");
			Random r = new Random();
			int Collumn = int.Parse(Console.ReadLine());
			int[,] array = new int[Collumn, rows];
			int bound0 = array.GetUpperBound(0);
			int bound1 = array.GetUpperBound(1);
#if DEBUG
			WriteLine("Debug log have blue color", ConsoleColor.Blue);
#endif
			for (int x = 0; x <= bound0; x++)
			{
				for (int y = 0; y <= bound1; y++)
				{
					array[x, y] = r.Next(0, 20);
#if DEBUG
					WriteLine("Number in array - [" + x + ";" + y + "] is = " + array[x, y], ConsoleColor.Blue, false);
#endif
				}
			}
			WriteLine("Press enter to show matrix");
			Console.ReadKey();
			Write2DArray(array,bound0,bound1);
		}

		public static void Write2DArray(int[,] array_, int bound0_, int bound1_)
		{
			string text = string.Empty;
			for (int x = 0; x <= bound0_; x++)
			{
				for (int y = 0; y <= bound1_; y++)
				{
					text += array_[x, y].ToString();
					if (array_[x, y] < 10)
					{
						text += "  ";
					}
					else
					{
						text += " ";
					}
				}
				WriteLine(text, ConsoleColor.Green, true, true);
				if(x != bound0_)
				{
					text = string.Empty;
				}
			}
			WriteLine("Press enter to continue");
			DivideToGroupForColor(array_, bound0_, bound1_,text);
			Console.ReadKey();
		}

		public static void DivideToGroupForColor(int[,] array_, int bound0_, int bound1_,string text)
		{
			WriteLine("Write how much the number will divided");
			int check = int.Parse(Console.ReadLine());
			int group = 0;
			int[] maxNumber;
			if (20 % check == 0)
			{
				group = 20 / check;
				maxNumber = new int[group];
				for (int i = 0; i < group; i++)
				{
					maxNumber[i] = check * (i + 1);
#if DEBUG
					WriteLine("Number " + i + " is max - " + maxNumber[i], ConsoleColor.Blue);
#endif
				}
			}
			else
			{
				group = Convert.ToInt32(20 / check);
				maxNumber = new int[group + 1];
				int remaind = 0;
				int remNumber = Math.DivRem(20, check, out remaind);
				maxNumber[0] = remaind;
#if DEBUG
				WriteLine("Number " + 0 + " is max - " + maxNumber[0], ConsoleColor.Blue);
#endif
				for (int i = 1; i < group; i++)
				{
					maxNumber[i] = check * (i + 1);
#if DEBUG
					WriteLine("Number " + i + " is max - " + maxNumber[i], ConsoleColor.Blue);
#endif
				}
			}
			Write2DArrayDifferentColor(array_, bound0_, bound1_,maxNumber,text);
		}

		public static void Write2DArrayDifferentColor(int[,] array_, int bound0_, int bound1_,int[] maxNumber_,string lastText)
		{
			string text = string.Empty;
			for (int x = 0; x <= bound0_; x++)
			{
				if(x == 0)
				{
					//CenterText(lastText);
				}
				for (int y = 0; y <= bound1_; y++)
				{
					text += array_[x, y].ToString();
					if (array_[x, y] < 10)
					{
						text += "  ";
					}
					else
					{
						text += " ";
					}
					int index = 0;
					for (int i = 0; i < maxNumber_.Length; i++)
					{
						if(array_[x, y] >= maxNumber_[i])
						{
							index = i;
						}
					}
					ConsoleColor color = ConsoleColor.White;
					Color(index, out color);
					Write(text, color, false, true);
					text = string.Empty;
				}
				WriteLine("");
				//CenterText(lastText);
			}
			WriteLine("Press enter to end");
			Console.ReadKey();
		}

		public static void CenterText(string text)
		{
			int screenWidth = Console.WindowWidth;
			int stringWidth = text.Length;
			int spaces = ((screenWidth / 2) + (stringWidth / 2))-(((screenWidth / 2) + (stringWidth / 2))/5);
			for (int i = 0; i < spaces; i++)
			{
				Console.Write(" ");
			}
		}

		public static void Color(int colorID, out ConsoleColor color)
		{
			color = ConsoleColor.White;
			switch (colorID)
			{
				case 0:
					color = ConsoleColor.Red;
					break;
				case 1:
					color = ConsoleColor.Blue;
					break;
				case 2:
					color = ConsoleColor.Yellow;
					break;
				case 3:
					color = ConsoleColor.Cyan;
					break;
				case 4:
					color = ConsoleColor.Magenta;
					break;
				case 5:
					color = ConsoleColor.Green;
					break;
				case 6:
					color = ConsoleColor.DarkRed;
					break;
				default:
					color = ConsoleColor.White;
					break;
			}
		}
	}
}
