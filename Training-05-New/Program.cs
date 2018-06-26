using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_05_New
{
	class Program
	{
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

		static void Main(string[] args)
		{
			Console.SetWindowSize(100, 35);
			Start();
			Console.ReadKey();
		}

		public static void Start()
		{
			WriteLine("Write maximum size trunk");
			string trunkStr = Console.ReadLine();
			int trunk = 0;
			CheckString(trunkStr,out trunk);
			WriteLine("Write maximum size branch");
			string branchStr = Console.ReadLine();
			int branch = 0;
			CheckString(branchStr, out branch);
			Console.Clear();
			MakeTop();
			int row = 2;
			int index = 0;
			for (int i = 0; i < (trunk / 2); i++)
			{
				index = i;
				MakePartOfTree(2 + (i*2), branch, ref row, 0);
			}
			MakeTrunk(trunk, 2 + (index * 2), ref row);
		}

		public static void CheckString(string check, out int doneCheck)
		{
			doneCheck = int.Parse(check);
			if(check == string.Empty)
			{
				doneCheck = 2;
			}
		}

		public static void MakeTop()
		{
			string text = string.Empty;
			int lastPos = 0;
			for (int i = 0; i < 2; i++)
			{
				for (int y = 0; y < 2 + (i*2); y++)
				{
					text += "*";
					WriteTextWithUseMouse(text,i,0,lastPos,(2 + (i * 2)));
					lastPos++;
					text = string.Empty;
				}
				lastPos = 0;
			}
		}

		public static void MakePartOfTree(int currentMaxSizeTrunk,int currentMaxSizeBranch,ref int addRow,int addSpace)
		{
			string text = string.Empty;
			int lastPos = 0;
			for (int i = 0; i < ((currentMaxSizeTrunk / 2) * 5); i++)
			{
				int textLenght = (1 + i) + (1 + i) + currentMaxSizeTrunk;
				for (int x = 0; x < addSpace; x++)
				{
					text += " ";
					WriteTextWithUseMouse(text, i + addRow, 0, lastPos, textLenght);
					text = string.Empty;
					lastPos++;
				}
				for (int a = 0; a < (1 + i); a++)
				{
					if(a == 0)
					{
						text += "*";
						WriteTextWithUseMouse(text, i + addRow, 0, lastPos, textLenght);
						text = string.Empty;
						lastPos++;
					}
					else if(a == 1)
					{
						text += "/";
						WriteTextWithUseMouse(text, i + addRow, 1, lastPos, textLenght);
						text = string.Empty;
						lastPos++;
					}
					else if(a % 2 == 0)
					{
						text += "/";
						WriteTextWithUseMouse(text, i + addRow, 1, lastPos, textLenght);
						text = string.Empty;
						lastPos++;
					}
					else
					{
						text += @"\";
						WriteTextWithUseMouse(text, i + addRow, 1, lastPos, textLenght);
						text = string.Empty;
						lastPos++;
					}
				}

				for (int b = 0; b < currentMaxSizeTrunk; b++)
				{
					text += "I";
					WriteTextWithUseMouse(text, i + addRow, 2, lastPos, textLenght);
					text = string.Empty;
					lastPos++;
				}

				for (int c = 0; c < (1 + i); c++)
				{
					if(c == ((1 + i) - 1))
					{
						text += "*";
						WriteTextWithUseMouse(text, i + addRow, 0, lastPos, textLenght);
						text = string.Empty;
						lastPos++;
					}
					else if(c == ((1 + i) - 2))
					{
						text += @"\";
						WriteTextWithUseMouse(text, i + addRow, 1, lastPos, textLenght);
						text = string.Empty;
						lastPos++;
					}
					else if (c % 2 != 0)
					{
						text += @"\";
						WriteTextWithUseMouse(text, i + addRow, 1, lastPos, textLenght);
						text = string.Empty;
						lastPos++;
					}
					else
					{
						text += "/";
						WriteTextWithUseMouse(text, i + addRow, 1, lastPos, textLenght);
						text = string.Empty;
						lastPos++;
					}
				}
				lastPos = 0;
			}
			addRow += ((currentMaxSizeTrunk / 2) * 5);
		}

		public static void MakeTrunk(int maxSizeTrunk, int currentMaxSizeTrunk, ref int addRow)
		{
			for (int i = 0; i < (((maxSizeTrunk / 2) * 5)/3); i++)
			{
				int lastPos = 0;
				for (int b = 0; b < currentMaxSizeTrunk; b++)
				{
					string text = string.Empty;
					text += "I";
					WriteTextWithUseMouse(text, i + addRow, 2, lastPos, currentMaxSizeTrunk);
					text = string.Empty;
					lastPos++;
				}
				lastPos = 0;
			}
		}
	}
}
