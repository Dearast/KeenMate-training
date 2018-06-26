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
			Console.SetWindowSize(100, 35);
			Console.Title = "Training by KeenMate";
			WriteLine("Training by KeenMate | Done by Damien Clément", ConsoleColor.Green, true, true);
			WriteLine("Write count rows");
			string rowsStr = Console.ReadLine();
			if(rowsStr == string.Empty)
			{
				rowsStr = "10";
			}
			else if(rowsStr.Length > 9)
			{
				int pos = 9;
				int lenght = rowsStr.Length - 9;
				rowsStr = rowsStr.Remove(pos, lenght);
			}
			int rows = int.Parse(rowsStr);
			if(rows >= (100 / 3))
			{
				rows = (100 / 3)-1;
			}
			else if(rows < 2)
			{
				rows = 2;
			}
			WriteLine("Write count collumn");
			string columnStr = Console.ReadLine();
			if(columnStr == string.Empty)
			{
				columnStr = "10";
			}
			else if (columnStr.Length > 9)
			{
				int pos = 9;
				int lenght = columnStr.Length - 9;
				columnStr = columnStr.Remove(pos, lenght);
			}
			int column = int.Parse(columnStr);
			if(column >= 30)
			{
				column = 30;
			}
			else if(column < 2)
			{
				column = 2;
			}
			int[,] array = new int[rows, column];
			int bound0 = array.GetUpperBound(0);		//get end number from array[x,]
			int bound1 = array.GetUpperBound(1);		//get end number from array[,y]
			Create2DArray(bound0,bound1,array);
			Write2DArray(array, bound0, bound1);
			int[] maxNumber;
			ColorMatrix(array, bound0, bound1, column, out maxNumber);
			WriteLine("Press enter to end");
			Console.ReadKey();
		}

		public static void ColorMatrix(int[,] array,int bound0,int bound1,int column,out int[] maxNumber)
		{
			WriteLine("Write how much the number will divided or write enter for end");
			string checkStr = Console.ReadLine();
			if(checkStr == string.Empty)
			{
				Environment.Exit(0);
			}
			else if (checkStr.Length > 9)
			{
				int pos = 9;
				int lenght = checkStr.Length - 9;
				checkStr = checkStr.Remove(pos, lenght);
			}
			int check = int.Parse(checkStr);
			if(check > 10)
			{
				check = 10;
			}
			else if(check == 0)
			{
				check = 1;
			}
			DivideToGroupForColor(check, out maxNumber);
			Write2DArrayDifferentColor(array, bound0, bound1, maxNumber, column);
			ColorMatrix(array, bound0, bound1, column, out maxNumber);
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

		public static void Create2DArray(int bound0,int bound1,int[,] array)
		{
			Random r = new Random();
			for (int x = 0; x <= bound0; x++)
			{
				for (int y = 0; y <= bound1; y++)
				{
					array[x, y] = r.Next(0, 20);
				}
			}
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
				text = string.Empty;
			}
		}

		public static void DivideToGroupForColor(int check, out int[] maxNumber)
		{
			int group = 0;
			if (20 % check == 0)
			{
				group = 20 / check;
				maxNumber = new int[group];
				for (int i = 0; i < group; i++)
				{
					maxNumber[i] = check * (i + 1);
				}
			}
			else
			{
				group = Convert.ToInt32(20 / check);
				maxNumber = new int[group + 1];
				int remaind = 0;
				int remNumber = Math.DivRem(20, check, out remaind);
				maxNumber[0] = remaind;
				for (int i = 1; i < group; i++)
				{
					maxNumber[i] = check * (i + 1);
				}
			}
		}

		public static void Write2DArrayDifferentColor(int[,] array_, int bound0_, int bound1_,int[] maxNumber_,int column)
		{
			Console.Clear();
			string text = string.Empty;
			int index = 0;
			int lastMousePos = 0;
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

					for (int i = 0; i < maxNumber_.Length; i++)
					{
						if(i < (maxNumber_.Length - 1))
						{
							if (array_[x, y] >= maxNumber_[i] && array_[x, y] < maxNumber_[i + 1])
							{
								index = i;
								break;
							}
						}
						else
						{
							index = i;
							break;
						}
					}
					WriteTextWithUseMouse(text, x, index, lastMousePos,column);
					lastMousePos += text.ToCharArray().Length;
					text = string.Empty;
				}
				lastMousePos = 0;
				WriteLine("");
			}
		}

		public static void WriteTextWithUseMouse(string text, int index, int color,int lastPos,int column)
		{
			char[] charx = text.ToCharArray();
			int screenWidth = Console.WindowWidth;
			ConsoleColor colorC = ConsoleColor.White;
			System.Console.SetCursorPosition(((screenWidth / 2) - (column + 2 + (int)(column * 0.5))) + lastPos, index);
			Color(color, out colorC);
			for (int i = 0; i < charx.Length; i++)
			{
				Console.ForegroundColor = colorC;
				Console.Write(charx[i].ToString());
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
				case 7:
					color = ConsoleColor.DarkBlue;
					break;
				case 8:
					color = ConsoleColor.DarkYellow;
					break;
				case 9:
					color = ConsoleColor.DarkCyan;
					break;
				case 10:
					color = ConsoleColor.DarkMagenta;
					break;
				default:
					color = ConsoleColor.White;
					break;
			}
		}
	}
}
