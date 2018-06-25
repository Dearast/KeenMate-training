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
			TreeProperties();
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
			Write("**",0);
			Write("****",1);
			if(trunk % 2 == 0)
			{
				for (int i = 0; i < ((trunk / 2) * 5); i++)
				{

				}
			}
			else
			{

			}
			Console.ReadKey();
		}
	}
}
