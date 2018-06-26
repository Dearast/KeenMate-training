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

		static void Main(string[] args)
		{
			Start(false, true, true,false);
			Console.ReadKey();
		}

		public static void Start(bool isEnableOnionInStorage, bool isItRotten, bool isItDirty,bool breakThem)
		{
			Write("Now i go check if a have onion in my storage");
			if (isEnableOnionInStorage)
			{
				Write("Oh yeah i have onion in storage");
				Write("Now i must check if is rotten");
				if (isItRotten)
				{
					Write("Oh no all onion is rotten");
					BuyOnion();
				}
				else
				{
					Write("It is clean or dirty");
					if (isItDirty)
					{
						Write("Oh its look as ***");
						CleanOnion();
					}
					else
					{
						Write("ehmm break them?");
						if (breakThem)
						{
							Write("Ehmm yeah i have to");
							BreakOnion();
						}
						else
						{
							Write("Now i will cut the onions");
							CutOnion();
						}
					}
				}
			}
			else
			{
				Write("Oh no i must buy some Onion");
				BuyOnion();
			}
		}

		public static void BuyOnion()
		{
			Start(true, false, true,false);
		}

		public static void CleanOnion()
		{
			Start(true, false, false,false);
		}

		public static void BreakOnion()
		{
			Start(true, true, false, true);
		}

		public static void CutOnion()
		{
			Write("I do it :D");
		}
	}
}
