using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_06
{
	class Program
	{
		public static void WriteTextWithUseMouse(string text, int row, int color, int lastPos, int textLength)
		{
			char[] charx = text.ToCharArray();
			int screenWidth = Console.WindowWidth;
			ConsoleColor colorC = ConsoleColor.White;
			System.Console.SetCursorPosition(((screenWidth / 2) - (textLength / 2)) + lastPos, row);
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

		static void Main(string[] args)
		{
			int width = 100;
			int height = 30;
			Console.SetWindowSize(width, height);
			Console.SetBufferSize(width, height);
			Console.Read();
			List<int>[,] list;
			CreateArrayMap(width, height,out list);
			Debug(list, width, height);
			Console.ReadKey();
			//DrawGPU(list, width, height);
		}

		public static void CreateArrayMap(int x,int y, out List<int>[,] list_)
		{
			Random r = new Random();
			List<int>[,] list = new List<int>[x, y];
			for (int i = 0; i < x; i++)
			{
				for (int a = 0; a < y; a++)
				{
					//int random = r.Next(0, 100);
					//if(random >= )
					//list[i, a].Add(5);
					if(i == 0 || i >= (x - 1))
					{
						list[i, a].Add(1);		// the write this -
					}

					if(a == 0 || a >= (y - 1))
					{
						list[i, a].Add(2);    // the write this |
					}
				}
			}
			list_ = list;
		}

		public static void Debug(List<int>[,] list, int width, int height)
		{
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					Console.WriteLine(list[x,y]);
				}
			}
		}

		public static void DrawGPU(List<int>[,] list,int width,int height)
		{
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					//int check = list[x, y];
					//if ( != 0)
					//{

					//}
				}
			}
		}
	}
}
