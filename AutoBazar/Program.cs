using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBazar
{
	class Program
	{
		public static void WriteTextWithCursorPosition(string text, int row, ConsoleColor color = ConsoleColor.White,ConsoleColor background = ConsoleColor.Black)
		{
			int screenWidth = Console.WindowWidth;
			System.Console.SetCursorPosition(((screenWidth / 2) - (text.Length / 2)), row);
			Console.ForegroundColor = color;
			Console.BackgroundColor = background;
			Console.WriteLine(text);
			Console.BackgroundColor = ConsoleColor.Black;
		}

		static void Main(string[] args)
		{
			Start();
		}

		static void Start()
		{
			int selectItemID = 0;
			int height = Console.WindowHeight;
			do
			{
				WriteTextWithCursorPosition("Auto bazar", 1, ConsoleColor.White, ConsoleColor.Black);
				if (selectItemID == 0)
				{
					WriteTextWithCursorPosition("Administrace",(height/2) - 3,ConsoleColor.Black,ConsoleColor.White);
				}
				else
				{
					WriteTextWithCursorPosition("Administrace", (height / 2) - 3, ConsoleColor.White, ConsoleColor.Black);
				}

				if (selectItemID == 1)
				{
					WriteTextWithCursorPosition("Další možnosti", (height / 2) - 2, ConsoleColor.Black, ConsoleColor.White);
				}
				else
				{
					WriteTextWithCursorPosition("Další možnosti", (height / 2) - 2, ConsoleColor.White, ConsoleColor.Black);
				}

				if (selectItemID == 2)
				{
					WriteTextWithCursorPosition("Odejít", (height / 2) - 1, ConsoleColor.Black, ConsoleColor.White);
				}
				else
				{
					WriteTextWithCursorPosition("Odejít", (height / 2) - 1, ConsoleColor.White, ConsoleColor.Black);
				}

				ConsoleKeyInfo ans = Console.ReadKey(true);
				Console.Clear();
				Console.BackgroundColor = ConsoleColor.Black;
				if (ans.Key == ConsoleKey.UpArrow)
				{
					selectItemID--;
					if(selectItemID < 0)
					{
						selectItemID = 0;
					}
				}
				else if (ans.Key == ConsoleKey.DownArrow)
				{
					selectItemID++;
					if(selectItemID > 3)
					{
						selectItemID = 3;
					}
				}
				else if(ans.Key == ConsoleKey.Enter)
				{
					switch (selectItemID)
					{
						case 0:
							Console.Clear();
							Administrations();
							break;
						case 1:
							Console.Clear();
							AnotherOptions();
							break;
						case 2:
							Console.Clear();
							EndApp();
							break;
						default:
							break;
					}
				}
			} while (true);
		}

		static void Administrations()
		{
			int selectItemID = 0;
			int height = Console.WindowHeight;
			do
			{
				WriteTextWithCursorPosition("Administrace", 1, ConsoleColor.White, ConsoleColor.Black);
				if (selectItemID == 0)
				{
					WriteTextWithCursorPosition("Další možnosti", (height / 2) - 2, ConsoleColor.Black, ConsoleColor.White);
				}
				else
				{
					WriteTextWithCursorPosition("Další možnosti", (height / 2) - 2, ConsoleColor.White, ConsoleColor.Black);
				}

				if (selectItemID == 1)
				{
					WriteTextWithCursorPosition("Odejít", (height / 2) - 1, ConsoleColor.Black, ConsoleColor.White);
				}
				else
				{
					WriteTextWithCursorPosition("Odejít", (height / 2) - 1, ConsoleColor.White, ConsoleColor.Black);
				}

				ConsoleKeyInfo ans = Console.ReadKey(true);
				Console.Clear();
				if (ans.Key == ConsoleKey.UpArrow)
				{
					selectItemID--;
					if (selectItemID < 0)
					{
						selectItemID = 0;
					}
				}
				else if (ans.Key == ConsoleKey.DownArrow)
				{
					selectItemID++;
					if (selectItemID > 2)
					{
						selectItemID = 2;
					}
				}
				else if (ans.Key == ConsoleKey.Enter)
				{
					switch (selectItemID)
					{
						case 0:
							Console.Clear();
							AnotherOptions();
							break;
						case 1:
							Console.Clear();
							Start();
							break;
						default:
							break;
					}
				}
			} while (true);
		}

		static void AnotherOptions()
		{
			int selectItemID = 0;
			int height = Console.WindowHeight;
			do
			{
				WriteTextWithCursorPosition("Další možnosti", 1, ConsoleColor.White, ConsoleColor.Black);
				if (selectItemID == 0)
				{
					WriteTextWithCursorPosition("Další možnosti", (height / 2) - 2, ConsoleColor.Black, ConsoleColor.White);
				}
				else
				{
					WriteTextWithCursorPosition("Další možnosti", (height / 2) - 2, ConsoleColor.White, ConsoleColor.Black);
				}

				if (selectItemID == 1)
				{
					WriteTextWithCursorPosition("Odejít", (height / 2) - 1, ConsoleColor.Black, ConsoleColor.White);
				}
				else
				{
					WriteTextWithCursorPosition("Odejít", (height / 2) - 1, ConsoleColor.White, ConsoleColor.Black);
				}

				ConsoleKeyInfo ans = Console.ReadKey(true);
				Console.Clear();
				if (ans.Key == ConsoleKey.UpArrow)
				{
					selectItemID--;
					if (selectItemID < 0)
					{
						selectItemID = 0;
					}
				}
				else if (ans.Key == ConsoleKey.DownArrow)
				{
					selectItemID++;
					if (selectItemID > 2)
					{
						selectItemID = 2;
					}
				}
				else if (ans.Key == ConsoleKey.Enter)
				{
					switch (selectItemID)
					{
						case 0:
							Console.Clear();
							AnotherOptions();
							break;
						case 1:
							Console.Clear();
							Start();
							break;
						default:
							break;
					}
				}
			} while (true);
		}

		static void EndApp()
		{
			List<DataCar> car = new List<DataCar>
			{
				new DataCar { Id = 0,Type = 0,Color = 0,Text = "test"}
			};
		}

		static void DrawDataCar()
		{

		}
	}
}

public class DataCar
{
	public int Id { get; set; }
	public int Type { get; set; }
	public int MotorValueInCm { get; set; }
	public int MotorPowerInKW { get; set; }
	public int GearBoxType { get; set; }
	public int FuelType { get; set; }
	public int Color { get; set; }
	public string Text { get; set; }
}

public class DataCargoCar
{
	public int Id { get; set; }
	public int Type { get; set; }
	public int MotorValueInCm { get; set; }
	public int MotorPowerInKW { get; set; }
	public int GearBoxType { get; set; }
	public int FuelType { get; set; }
	public int Color { get; set; }
	public string Text { get; set; }
}

public class DataBus
{
	public int Id { get; set; }
	public int Type { get; set; }
	public int MotorValueInCm { get; set; }
	public int MotorPowerInKW { get; set; }
	public int GearBoxType { get; set; }
	public int FuelType { get; set; }
	public int Color { get; set; }
	public string Text { get; set; }
}

public class DataMotocykle
{
	public int Id { get; set; }
	public int Type { get; set; }
	public int MotorValueInCm { get; set; }
	public int MotorPowerInKW { get; set; }
	public int FuelType { get; set; }
	public int Color { get; set; }
	public string Text { get; set; }
}

public class DataCykle
{
	public int Id { get; set; }
	public int Type { get; set; }
	public int Color { get; set; }
	public string Text { get; set; }
}

public class DataCykleWithMotor
{
	public int Id { get; set; }
	public int Type { get; set; }
	public int MotorValueInCm { get; set; }
	public int MotorPowerInKW { get; set; }
	public int FuelType { get; set; }
	public int Color { get; set; }
	public string Text { get; set; }
}

