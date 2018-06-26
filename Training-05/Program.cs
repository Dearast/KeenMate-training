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
			string trunkStr = Console.ReadLine();
			if(trunkStr == string.Empty)
			{
				trunkStr = "3";
			}
			int trunk = int.Parse(trunkStr);
			if(trunk < 3)
			{
				trunk = 3;
			}
			else if(trunk > 12)
			{
				trunk = 12;
			}
			string branchStr = Console.ReadLine();
			if(branchStr == string.Empty)
			{
				trunkStr = "4";
			}
			int branch = int.Parse(branchStr);
			if(branch < 2)
			{
				branch = 2;
			}
			else if(branch > 16)
			{
				branch = 12;
			}
			CreateTree(trunk,branch);
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

		public static void CreateTree(int trunk,int branch)
		{
			WriteLine("**", ConsoleColor.Green, true);
			WriteLine("****", ConsoleColor.Green, true);
			WriteLine("II", ConsoleColor.DarkYellow, true);
			for (int i = 0; i < trunk; i++)
			{
				for (int y = 0; y < branch; y++)
				{
					CreateTextForPartOfTree(y, i + 1,y + i);
				}
			}
			//CreateWood(branch, trunk);
		}

		public static void CreateTop()
		{

		}

		public static void CreateTextForPartOfTreeSecond(int consoleRow,int sizeTrun,int sizeBranch)
		{
			string text = string.Empty;
			int lastPos = 0;
			int column = 2 + sizeTrun + sizeBranch;
			text += "*";
			WriteTextWithUseMouse(text, consoleRow + 6, 0, lastPos, column);
			lastPos++;
			text = string.Empty;
			for (int a = 0; a < sizeBranch; a++)
			{
				text += "/";
				//WriteTextWithUseMouse(text, consoleRow + 6, 1, lastPos, column);
				//lastPos++;
				//text = string.Empty;
			}
			for (int b = 0; b < sizeTrun; b++)
			{
				text += "I";
				//WriteTextWithUseMouse(text, consoleRow + 6, 2, lastPos, column);
				//lastPos++;
				//text = string.Empty;
			}
			for (int c = 0; c < sizeBranch; c++)
			{
				text += @"\";
				//WriteTextWithUseMouse(text, consoleRow + 6, 1, lastPos, column);
				//lastPos++;
				//text = string.Empty;
			}
			text += "*";
			//WriteTextWithUseMouse(text, consoleRow + 6, 0, lastPos, column);
			//lastPos = 0;
			//text = string.Empty;
		}

		public static void CreateTextForPartOfTree(int index,int level,int row,bool start = false)
		{
			string text = string.Empty;
			int lastPos = 0;
			int column = 2 + (2 * level) + ((1 * index) * 2);
			//WriteLine("Column - " + column + " level - " + level + " index - " + index);
			text += "*";
			WriteTextWithUseMouse(text, row + 6, 0, lastPos, 2);
			lastPos++;
			text = string.Empty;
			//if (start)
			//{
			//	for (int b = 0; b < (2 * level); b++)
			//	{
			//		text += "I";
			//		WriteTextWithUseMouse(text, index + 6, 2, lastPos, column);
			//		lastPos++;
			//		text = string.Empty;
			//	}
			//}
			//else
			//{
			//	for (int a = 0; a < (1 * index); a++)
			//	{
			//		text += "/";
			//		WriteTextWithUseMouse(text, index + 6, 1, lastPos, column);
			//		lastPos++;
			//		text = string.Empty;
			//	}
			//	for (int b = 0; b < (2 * level); b++)
			//	{
			//		text += "I";
			//		WriteTextWithUseMouse(text, index + 6, 2, lastPos, column);
			//		lastPos++;
			//		text = string.Empty;
			//	}
			//	for (int c = 0; c < (1 * index); c++)
			//	{
			//		text += @"\";
			//		WriteTextWithUseMouse(text, index + 6, 1, lastPos, column);
			//		lastPos++;
			//		text = string.Empty;
			//	}
			//}
			text += "*";
			WriteTextWithUseMouse(text, row + 6, 0, lastPos, column);
			lastPos = 0;
			text = string.Empty;
			column = 0;
			//WriteLine(text, ConsoleColor.White, true);
			//text = string.Empty;
		}

		public static void CreateWood(int index,int level)
		{
			string text = string.Empty;
			for (int i = 0; i < index; i++)
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
