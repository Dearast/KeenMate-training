using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimeBomb
{
	class Program
	{
		public static void WriteTextWithCursorPosition(string text, int row, ConsoleColor color = ConsoleColor.White)
		{
			int screenWidth = Console.WindowWidth;
			System.Console.SetCursorPosition(((screenWidth / 2) - (text.Length / 2)), row);
			Console.ForegroundColor = color;
			Console.WriteLine(text);
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

		public static void CheckString(string checkStr, out string checkedStr, bool isNumber, int number = 1)
		{
			checkedStr = string.Empty;
			if (checkStr == string.Empty && isNumber)
			{
				checkedStr = "" + number;
			}
			else
			{
				checkedStr = checkStr;
			}
		}

		public static void CheckInt(int checkInt, out int checkedInt, int minNumber, int maxNumber)
		{
			checkedInt = 0;
			if (checkInt > maxNumber)
			{
				checkedInt = maxNumber;
			}
			else if (checkInt < minNumber)
			{
				checkedInt = minNumber;
			}
			else
			{
				checkedInt = checkInt;
			}
		}

		static void Main(string[] args)
		{
			Console.Title = "Training by KeenMate";
			WriteLine("Training by KeenMate | Done by Damien Clément", ConsoleColor.Green, true, true);
			WriteLine("Press enter to start a game");
			Console.ReadKey();
			Start();
			Console.ReadKey();
		}

		public static int checkStat;
		public static int[] randomNumberStat;
		public static int lastPosStat;
		public static Timer newTimer;
		public static void Start()
		{
			WriteLine("Write difficult between 1-3");
			string checkStr = Console.ReadLine();
			CheckString(checkStr, out checkStr, true, 1);
			int check = int.Parse(checkStr);
			CheckInt(check, out check, 1, 3);
			Random r = new Random();
			int[] randomNumber = new int[check * 3];
			for (int i = 0; i < randomNumber.Length; i++)
			{
				randomNumber[i] = r.Next(0, 9 * check);
				WriteLine("Debug - RN = " + randomNumber[i], ConsoleColor.Red);
			}
			Console.ReadKey();
			int[] lockedNumber = new int[check * 3];
			randomNumberStat = randomNumber;
			int bombTimer = 90 - (10 * check);
			checkStat = bombTimer;
			Console.Clear();
			Timer timer = new Timer(1000);
			newTimer = timer;
			timer.Elapsed += new ElapsedEventHandler(HandleTimer);
			timer.Start();
			string checkStrR = Console.ReadLine();
			int key = int.Parse(checkStrR);
			int locked = randomNumber.Length;
			int currentLocked = 0;
			for (int i = 0; i < randomNumber.Length; i++)
			{
				if(key == randomNumber[i])
				{
					lockedNumber[i] = key;
					WriteTextWithCursorPosition("You find number", 3, 0);
					currentLocked++;
				}
			}
		}

		static void HandleTimer(object sender, ElapsedEventArgs e)
		{
			DrawBombTimer(ref checkStat,lastPosStat,newTimer);
		}

		public static void DrawBombTimer(ref int timer, int lastPos,Timer funcTimer)
		{
			timer--;
			ConsoleColor color = ConsoleColor.Green;
			if(timer < 30 && timer > 14)
			{
				color = ConsoleColor.Yellow;
			}
			else if(timer < 15 && timer > 0)
			{
				color = ConsoleColor.Red;
			}
			else if(timer <= 0)
			{
				funcTimer.Stop();
				Console.Clear();
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("");
				WriteLine("BOOM", ConsoleColor.Red, true);
			}
			lastPosStat = Console.CursorLeft;
			WriteTextWithCursorPosition("  ", 0, 0); 
			WriteTextWithCursorPosition(timer.ToString(), 0, color);
			WriteTextWithCursorPosition(lastPos.ToString(), 1, color);
			Console.SetCursorPosition(lastPosStat, 2);
		}
	}
}