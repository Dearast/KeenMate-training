using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_05
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Training by KeenMate";
			WriteLine("Training by KeenMate | Done by Damien Clément", ConsoleColor.Green, true, true);
			WriteLine("**", ConsoleColor.White, true);
			WriteLine("****", ConsoleColor.White, true);
			WriteLine("II", ConsoleColor.White, true);
			CreateTextForPartOfTree(0,1,true);
			CreateTextForPartOfTree(1, 1);
			CreateTextForPartOfTree(2, 1);
			CreateTextForPartOfTree(3, 1);
			CreateTextForPartOfTree(4, 1);
			CreateTextForPartOfTree(5, 1);
			CreateTextForPartOfTree(0, 2,true);
			CreateTextForPartOfTree(1, 2);
			CreateTextForPartOfTree(2, 2);
			CreateTextForPartOfTree(3, 2);
			CreateTextForPartOfTree(4, 2);
			CreateTextForPartOfTree(5, 2);
			CreateTextForPartOfTree(6, 2);
			CreateTextForPartOfTree(7, 2);
			CreateTextForPartOfTree(8, 2);
			CreateTextForPartOfTree(9, 2);
			CreateTextForPartOfTree(10, 2);
			CreateWood(12, 2);
			Console.ReadKey();
		}

		public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White, bool center = false,bool backToDefault = false,ConsoleColor backColor = ConsoleColor.Black)
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

		public static void Write(string text, int index)
		{
			char[] charx = text.ToCharArray();
			int screenWidth = Console.WindowWidth;
			System.Console.SetCursorPosition((screenWidth / 2) - (text.Length / 2), index);
			for (int i = 0; i < charx.Length; i++)
			{
				if (charx[i] == '*')
				{
					Console.ForegroundColor = ConsoleColor.Green;
				}
				else if (charx[i] == '/')
				{
					Console.ForegroundColor = ConsoleColor.DarkGreen;
				}
				Console.Write(charx[i].ToString());
			}
		}

		public static void WriteTextWithUseMouse(string text, int index, int color, int lastPos, int column)
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
					color = ConsoleColor.Green;
					break;
				case 1:
					color = ConsoleColor.DarkGreen;
					break;
				case 2:
					color = ConsoleColor.DarkYellow;
					break;
				default:
					color = ConsoleColor.White;
					break;
			}
		}

		public static void TreeProperties()
		{
			WriteLine("Write size trunk");
			int trunk = int.Parse(Console.ReadLine());
			WriteLine("Write size branch");
			int branch = int.Parse(Console.ReadLine());
			DrawTree(trunk, branch);
		}

		public static void DrawTree(int trunk,int branch)
		{
			Console.Clear();
			WriteLine("**",ConsoleColor.Green,true);
			WriteLine("****", ConsoleColor.Green, true);
			if(trunk % 2 == 0)
			{
				for (int i = 0; i < (trunk / 2); i++)
				{
					DrawPartTree((i + 1));
				}
			}
			else
			{

			}
			Console.ReadKey();
		}

		public static void DrawPartTree(int multiply)
		{
			int lastPosText = 0;
			for (int i = 0; i < (5 * multiply); i++)
			{
				WriteTextWithUseMouse("*", multiply + 1, 0, lastPosText, 10);
				lastPosText++;
				for (int a = 0; a < (i+1); a++)
				{
					lastPosText++;
				}
				for (int b = 0; b < (multiply); b++)
				{
					WriteTextWithUseMouse("I", multiply + 1, 2,lastPosText,10);
					lastPosText++;
				}
				for (int c = 0; c < (i+1); c++)
				{
					lastPosText++;
				}
				WriteTextWithUseMouse("*", multiply + 1, 0, lastPosText, 10);
				lastPosText = 0;
			}
		}
		public static void CreateTextForPartOfTree(int index,int level,bool start = false)
		{
			string text = string.Empty;
			text += "*";
			if(start)
			{
				for (int b = 0; b < (2 * level); b++)
				{
					text += "I";
				}
			}
			else
			{
				for (int a = 0; a < (1 * index); a++)
				{

					text += "/";

				}

				for (int b = 0; b < (2 * level); b++)
				{
					text += "I";
				}

				for (int c = 0; c < (1 * index); c++)
				{
					text += @"\";
				}
			}
			text += "*";
			WriteLine(text, ConsoleColor.White, true);
			text = string.Empty;
		}

		public static void CreateWood(int index,int level)
		{
			string text = string.Empty;
			for (int i = 0; i < (index / 3); i++)
			{
				for (int b = 0; b < (2 * level); b++)
				{
					text += "I";
				}
				WriteLine(text, ConsoleColor.White, true);
				text = string.Empty;
			}
		}
	}
}
