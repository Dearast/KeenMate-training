using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipSport
{
	class Program
	{
		static void Main(string[] args)
		{
			Write("Training by KeenMate \t\t\t\t\t\t\t Done by Damien Clément");
			TipGame();
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

		public static void ParseString(string text, out int outInt)
		{
			outInt = int.Parse(text);
		}

		public static void WriteTip(out string check)
		{
			check = Console.ReadLine();
		}

		public static void TipGame(int count = 0)
		{
			int i = 0;
			i += count;
			Random r = new Random();
			//int max = sett
			int rNumber = r.Next(0, 10);
			Write("Guess number between 0-10");
			string check;
			WriteTip(out check);
			int checkNumber;
			ParseString(check, out checkNumber);
			if(checkNumber == rNumber)
			{
				EndTip(i);
			}
			else
			{
				i++;
				TipGame(i);
			}
		}

		public static void EndTip(int count)
		{
			Write("yout tip count to hit success number is - " + count);
			if(count > 20)
			{
				Write("little bit more");
			}
			else if(count > 40)
			{
				Write("far more");
			}
			Console.ReadKey();
		}
	}
}
