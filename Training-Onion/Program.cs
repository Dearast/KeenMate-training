using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Onion
{
	class Program
	{
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

		public static void Check(string)

		static void Main(string[] args)
		{
			Write("Now a go check if a have onion in my storage");
			CheckIsAvaiableOnionInStorage(true);
			CheckHowMuchIsHaveOnionInStorage(5)
			CheckIsNotCorrupted()
		}

		public static void CheckIsAvaiableOnionInStorage(bool isAble = false)
		{
			if (isAble)
			{
				Write("Oh yeah i have onion");
			}
			else
			{
				Write("Oh no i must go buy some onion");

			}
		}

		public static void BuyOnion()
		{

		}

		public static void CheckHowMuchIsHaveOnionInStorage(int inStorage = 0)
		{

		}

		public static void CheckIsNotCorrupted()
	}
}
