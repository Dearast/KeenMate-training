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

		public static void CountTips(out int check, int max)
		{
			while (true)
			{
				Write("Write count your tipes");
				check = int.Parse(Console.ReadLine());
				if (check > max)
				{
					Write("Your count tipes must be lower then generated number", ConsoleColor.Red);
				}
				else
				{
					break;
				}
			}
		}

		public static void Tip(ref string[] player,int min, int max, int currentTip = 0)
		{
			int index = 0;
			int i = 0;
			if(currentTip > 0)
			{
				index = currentTip;
				Write("index - " + index, ConsoleColor.Blue);
			}

			for (i = index; i < player.Length; i++)
			{
				Write("Write tip - " + i);
				player[i] = Console.ReadLine();
				if (i >= 1)
				{
					Write("is after second", ConsoleColor.Blue);
					for (int a = 0; a < i; a++)
					{
						Write("check if have same number", ConsoleColor.Blue);
						if (int.Parse(player[i]) == int.Parse(player[a]))
						{
							Write("Your current tips is same as before please repeat tip", ConsoleColor.Red);
							Tip(ref player, min, max, i);
						}
					}
				}
				if (int.Parse(player[i]) > max || int.Parse(player[i]) < min)
				{
					Write("Your current tip is out",ConsoleColor.Red);
					Tip(ref player,min,max, i);
				}
			}
		}

		public static void TipGame()
		{
			Write("Write count for generate number");
			int checkA = int.Parse(Console.ReadLine());
			Write("Write minimum generate number");
			int checkB = int.Parse(Console.ReadLine());
			Write("Write maximum generate number");
			int checkC = int.Parse(Console.ReadLine());
			int checkD;
			CountTips(out checkD,checkA);
			Random r = new Random();
			int[] random = new int[checkA];
			int succes = 0;
			for (int i = 0; i < random.Length; i++)
			{
				random[i] = r.Next(checkB, checkC);
			}
			string[] player = new string[checkD];
			Tip(ref player,checkB,checkC);
			int[] tips = new int[player.Length];
			for (int i = 0; i < tips.Length; i++)
			{
				tips[i] = int.Parse(player[i]);
				for (int y = 0; y < random.Length; y++)
				{
					if (tips[i] == random[y])
					{
						succes++;
					}
				}
			}
			float value = succes / player.Length;
			Write("succes tips " + value);
			Write("if you want to show all number then push 0");
			Write("if you want restart game then write 1");
			Write("if you want exit then write anything else");
			string check = Console.ReadLine();
			switch (check)
			{
				case "0":
					int index = 0;
					foreach (var item in random)
					{
						Write("number " + (index + 1) + " - " + random[index], ConsoleColor.Yellow);
						index++;
					}
					int minimum = checkC;
					int maximum = checkB;
					for (int i = 0; i < random.Length; i++)
					{
						if(random[i] > maximum)
						{
							maximum = random[i];
						}

						if(random[i] < minimum)
						{
							minimum = random[i];
						}
					}
					Write("Maximum is - " + maximum);
					Write("Minimum is - " + minimum);
					Write("if you want restart game then write 0");
					Write("if you want exit then write anything else");
					string check2 = Console.ReadLine();
					switch (check2)
					{
						case "0":
							TipGame();
							break;
						default:
							Environment.Exit(0);
							break;
					}
					break;
				case "1":
					TipGame();
					break;
				default:
					Environment.Exit(0);
					break;
			}
		}
	}
}
