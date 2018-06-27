using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_06
{
	class Program
	{
		public static void WriteAsWriteLine(string text, int color)
		{
			char[] charx = text.ToCharArray();
			ConsoleColor colorC = ConsoleColor.White;
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
					color = ConsoleColor.DarkYellow;
					break;
				default:
					color = ConsoleColor.White;
					break;
			}
		}

		public static void CheckString(ref string text)
		{
			if(text == string.Empty)
			{
				text = "0";
			}
		}

		static void Main(string[] args)
		{
			int width = 100;
			int height = 30;
			Console.SetWindowSize(width, height);
			Console.SetBufferSize(width, height);
			width -= 10;
			height -= 5;
			CollisionCount(0, width);
			string selectLevelStr = Console.ReadLine();
			CheckString(ref selectLevelStr);
			int alcoholic = 0;
			int profesionalAlcoholic = 0;
			int berserker = 0;
			SetDifficultLevel(int.Parse(selectLevelStr), out alcoholic, out profesionalAlcoholic, out berserker);
			int[,] array;
			Create2DArray(out array, width, height);
			AddArrayID(ref array, width, height, alcoholic, profesionalAlcoholic, berserker);
			CleanPeople(ref array,width,height);
			Console.Clear();
			DrawMap(array, width, height);
			System.Console.SetCursorPosition(1,1);
			Console.ReadKey();
		}

		public static void CleanPeople(ref int[,] array,int width, int height)
		{
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if(x != 0 || y != 0 || x != (width - 1) || y != (height - 1))
					{
						if(x == 1 && y == 1)
						{
							if(array[1,2] != 3 || array[1, 2] != 4 || array[1, 2] != 5)
							{
								array[1, 1] = 0;
							}

							if(array[2, 1] != 3 || array[2, 1] != 4 || array[2, 1] != 5)
							{
								array[1, 1] = 0;
							}
						}
					}
				}
			}
		}

		public static void DrawMap(int[,] array,int width, int height)
		{
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if(array[x,y] == 1)
					{
						Console.Write("-");
					}
					else if(array[x,y] == 2)
					{
						Console.Write("|");
					}
					else if (array[x, y] == 3)
					{
						Console.Write("ß");
					}
					else if (array[x, y] == 4)
					{
						Console.Write("ß");
					}
					else if (array[x, y] == 5)
					{
						Console.Write("ß");
					}
					else
					{
						Console.Write(" ");
					}
				}
				Console.WriteLine("");
			}
		}

		public static void AddArrayID(ref int[,] array,int width,int height,int alcoholic, int profesionalAlcoholic,
			int berserker)
		{
			Random r = new Random();
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					int random = r.Next(0, 100);
					if(y == 0 || y == (height - 1))
					{
						array[x, y] = 1;
					}
					else if(x == 0 || x == (width - 1))
					{
						array[x, y] = 2;
					}
					else
					{
						if(random > alcoholic)
						{
							array[x, y] = 3;
						}
						else if(random > profesionalAlcoholic)
						{
							array[x, y] = 4;
						}
						else if(random > berserker)
						{
							array[x, y] = 5;
						}
					}
				}
			}
		}

		public static void Create2DArray(out int[,] array,int width, int height)
		{
			array = new int[width, height];
		}

		public static void SetDifficultLevel(int selectLevel,out int alcoholic, out int profesionalAlcoholic,
			out int berserker)
		{
			alcoholic = 0;
			profesionalAlcoholic = 0;
			berserker = 0;
			switch (selectLevel)
			{
				case 1:
					alcoholic = 25;
					profesionalAlcoholic = 36;
					berserker = 55;
					break;
				case 2:
					alcoholic = 30;
					profesionalAlcoholic = 42;
					berserker = 50;
					break;
				case 3:
					alcoholic = 35;
					profesionalAlcoholic = 50;
					berserker = 65;
					break;
				default:

					break;
			}
		}

		public static void CollisionCount(int count,int widthScreen)
		{
			string text = string.Empty;
			int length = (widthScreen - 20) * 2;
			for (int i = 0; i < length; i++)
			{
				text += " ";
			}
			Console.Title = text + "Current collision - " + count;
		}
	}
}
