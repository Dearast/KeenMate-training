using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace AutoBazar
{
	class Program
	{
		public static List<DataCar> car = new List<DataCar>();
		public static List<DataCargoCar> cargoCar = new List<DataCargoCar>();

		public static void WriteTextWithCursorPosition(string text, int row, ConsoleColor color = ConsoleColor.White,ConsoleColor background = ConsoleColor.Black)
		{
			int screenWidth = Console.WindowWidth;
			System.Console.SetCursorPosition(((screenWidth / 2) - (text.Length / 2)), row);
			Console.ForegroundColor = color;
			Console.BackgroundColor = background;
			Console.WriteLine(text);
			Console.BackgroundColor = ConsoleColor.Black;
		}

		public static void WriteButton(string text, int ID, int row, int selectButton, ConsoleColor FColor = ConsoleColor.White,
		ConsoleColor BColor = ConsoleColor.Gray)
		{
			int height = Console.WindowHeight;
			if (ID == selectButton)
			{
				WriteTextWithCursorPosition(text, (height / 2) - 3 + row, ConsoleColor.Black, BColor);
			}
			else
			{
				WriteTextWithCursorPosition(text, (height / 2) - 3 + row, FColor, ConsoleColor.Black);
			}
		}

		public static void ConsoleTextSelect(int min,int max,ConsoleKeyInfo ans,ref int selectItemID)
		{
			//Console.Clear();
			if (ans.Key == ConsoleKey.UpArrow)
			{
				selectItemID--;
				if (selectItemID < min)
				{
					selectItemID = min;
				}
			}
			else if (ans.Key == ConsoleKey.DownArrow)
			{
				selectItemID++;
				if (selectItemID > max)
				{
					selectItemID = max;
				}
			}
		}

		public static void WriteToButton(int addRow,string text)
		{
			int screenWidth = Console.WindowWidth;
			int height = Console.WindowHeight;
			int row = (height / 2) - 3 + addRow;
			WriteTextWithCursorPosition("                                                                     ", row);
			System.Console.SetCursorPosition(((screenWidth / 2) - (text.Length / 2)), row);
			Console.ForegroundColor = ConsoleColor.White;
		}

		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			Start();
		}

		static void Start()
		{
			int selectItemID = 0;
			do
			{
				WriteTextWithCursorPosition("Auto bazar", 1, ConsoleColor.White, ConsoleColor.Black);
				WriteButton("Administrace", 0, 0, selectItemID);
				WriteButton("Další možnosti", 1, 1, selectItemID);
				WriteButton("Odejít", 2, 2, selectItemID);
				WriteButton("Debug save", 3, 5, selectItemID,ConsoleColor.Green,ConsoleColor.DarkGreen);
				ConsoleKeyInfo ans = Console.ReadKey(true);
				ConsoleTextSelect(0, 3, ans, ref selectItemID);
				if(ans.Key == ConsoleKey.Enter)
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
						case 3:
							DebugSave();
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
			do
			{
				WriteTextWithCursorPosition("Administrace", 1, ConsoleColor.White, ConsoleColor.Black);
				WriteButton("Osobní auta", 0, 0, selectItemID);
				WriteButton("Nákladní auta", 1, 1, selectItemID);
				WriteButton("Autobusy", 2, 2, selectItemID);
				WriteButton("Motorky", 3, 3, selectItemID);
				WriteButton("Kola", 4, 4, selectItemID);
				WriteButton("Odejít", 5, 5, selectItemID,ConsoleColor.Red,ConsoleColor.DarkRed);
				ConsoleKeyInfo ans = Console.ReadKey(true);
				ConsoleTextSelect(0, 5, ans, ref selectItemID);
				if (ans.Key == ConsoleKey.Enter)
				{
					switch (selectItemID)
					{
						case 0:
							Console.Clear();
							DrawDataCar();
							break;
						case 1:
							Console.Clear();

							break;
						case 2:
							Console.Clear();

							break;
						case 3:
							Console.Clear();

							break;
						case 4:
							Console.Clear();

							break;
						case 5:
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
			Environment.Exit(0);
		}

		static void DebugSave()
		{
			for (int i = 0; i < 5; i++)
			{
				car.Add(new DataCar
				{
					Id = i,
					Type = "Combi",
					Color = "",
					Text = "test",
					MotorPowerInKW = 0,
					MotorValueInCm = 0,
					FuelType = "",
					GearBoxType = "",
					NameText = "Auto_" + i
				});
			}
			string jsonCar = JsonConvert.SerializeObject(car);
			string jsonCargoCar = JsonConvert.SerializeObject(cargoCar);
			File.WriteAllText(@"C:\Git\AutoBazar\DataSave\SaveCar.txt", jsonCar);
			File.WriteAllText(@"C:\Git\AutoBazar\DataSave\SaveCargoCar.txt", jsonCargoCar);
		}

		static void DrawDataCar()
		{
			if (!File.Exists(@"C:\Git\AutoBazar\DataSave\SaveCar.txt"))
			{
				DataCar newCar = new DataCar();
				string jsonCarNew = JsonConvert.SerializeObject(newCar);
				File.WriteAllText(@"C:\Git\AutoBazar\DataSave\SaveCar.txt", jsonCarNew);
				CreateNewCar(0);
			}
			else
			{
				string jsonCar = File.ReadAllText(@"C:\Git\AutoBazar\DataSave\SaveCar.txt");
				List<DataCar> deserializedCar = JsonConvert.DeserializeObject<List<DataCar>>(jsonCar);
				car = deserializedCar;
			}
			int selectItemID = 0;
			int selectCar = 0;
			do
			{
				WriteTextWithCursorPosition("Osobní auta", 1, ConsoleColor.White, ConsoleColor.Black);
				WriteButton("Jméno - " + car[selectCar].NameText, 0, 0, selectItemID);
				WriteButton("typ karoserie - " + car[selectCar].Type, 1, 1, selectItemID);
				WriteButton("Síla motoru - " + car[selectCar].MotorPowerInKW + " KW|Koně - " + car[selectCar].MotorPowerInKW * 1.34102209f, 2, 2, selectItemID);
				WriteButton("Objem motoru v cm - " + car[selectCar].MotorValueInCm, 3, 3, selectItemID);
				WriteButton("Převodovka - " + car[selectCar].GearBoxType, 4, 4, selectItemID);
				WriteButton("Barva - " + car[selectCar].Color, 5, 5, selectItemID);
				WriteButton("Odejít", 6, 6, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
				ConsoleKeyInfo ans = Console.ReadKey(true);
				ConsoleTextSelect(0, 6, ans, ref selectItemID);
				if (ans.Key == ConsoleKey.Enter)
				{
					switch (selectItemID)
					{
						case 0:
							Console.Clear();

							break;
						case 1:
							Console.Clear();

							break;
						case 2:
							Console.Clear();

							break;
						case 3:
							Console.Clear();

							break;
						case 4:
							Console.Clear();

							break;
						case 5:
							Console.Clear();

							break;
						case 6:
							Console.Clear();
							Administrations();
							break;
						default:
							break;
					}
				}
				else if(ans.Key == ConsoleKey.RightArrow)
				{
					if(selectCar == car.Count)
					{
						CreateNewCar(selectCar);
						Console.Clear();
					}
					else
					{
						selectCar++;
						if (selectCar == car.Count)
						{
							Console.Clear();
							CreateNewCar(selectCar);
						}
						Console.Clear();
					}
				}
				else if (ans.Key == ConsoleKey.LeftArrow)
				{
					if (selectCar != 0)
					{
						selectCar--;
						Console.Clear();
					}
				}
			} while (true);
		}

		static void CreateNewCar(int lastCar)
		{
			int selectItemID = 0;
			string name = string.Empty;
			string type = string.Empty;
			string color = string.Empty;
			string textPref = string.Empty;
			string fuel = string.Empty;
			string gearBox = string.Empty;
			int power = 0;
			int valueInCm = 0;
			do
			{
				WriteTextWithCursorPosition("Osobní auta", 1, ConsoleColor.White, ConsoleColor.Black);
				WriteButton("Jméno - " + name, 0, 0, selectItemID);
				WriteButton("typ karoserie - " + type, 1, 1, selectItemID);
				WriteButton("Síla motoru - " + power, 2, 2, selectItemID);
				WriteButton("Objem motoru v cm - " + valueInCm, 3, 3, selectItemID);
				WriteButton("Převodovka - " + gearBox, 4, 4, selectItemID);
				WriteButton("Barva - " + color, 5, 5, selectItemID);
				WriteButton("Uložit", 6, 6, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
				WriteButton("Odejít bez uložení", 7, 7, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
				ConsoleKeyInfo ans = Console.ReadKey(true);
				ConsoleTextSelect(0, 7, ans, ref selectItemID);
				if (ans.Key == ConsoleKey.Enter)
				{
					switch (selectItemID)
					{
						case 0:
							WriteToButton(0, "Jméno - ");
							name = Console.ReadLine();
							break;
						case 1:
							WriteToButton(1, "typ karoserie - ");
							type = Console.ReadLine();
							break;
						case 2:
							WriteToButton(2, "Síla motoru - ");
							power = int.Parse(Console.ReadLine());
							break;
						case 3:
							WriteToButton(3, "Objem motoru v cm - ");
							valueInCm = int.Parse(Console.ReadLine());
							break;
						case 4:
							WriteToButton(4, "Převodovka - ");
							gearBox = Console.ReadLine();
							break;
						case 5:
							WriteToButton(5, "Barva - ");
							color = Console.ReadLine();
							break;
						case 6:
							car.Add(new DataCar
							{
								Id = lastCar,
								NameText = name,
								Type = type,
								MotorPowerInKW = power,
								MotorValueInCm = valueInCm,
								GearBoxType = gearBox,
								Color = color
							});
							Console.Clear();
							string jsonCar = JsonConvert.SerializeObject(car);
							File.WriteAllText(@"C:\Git\AutoBazar\DataSave\SaveCar.txt", jsonCar);
							DrawDataCar();
							break;
						case 7:
							Console.Clear();
							DrawDataCar();
							break;
						default:
							break;
					}
				}
			} while (true);
		}
	}
}

public class BaseCar
{
	public int Id { get; set; }
	public string Type { get; set; }
	public int MotorValueInCm { get; set; }
	public int MotorPowerInKW { get; set; }
	public string FuelType { get; set; }
	public string Color { get; set; }
	public string Text { get; set; }
	public string NameText { get; set; }
}

public class DataCar : BaseCar
{
	public string GearBoxType { get; set; }
}

public class DataCargoCar : BaseCar
{
	public int GearBoxType { get; set; }
	public int LoadCapacity { get; set; }
}

public class DataBus : BaseCar
{
	public int GearBoxType { get; set; }
	public int LoadCapacity { get; set; }
	public int Capacity { get; set; }
}

public class DataMotocykle : BaseCar
{

}

public class DataCykle
{
	public int Id { get; set; }
	public int Type { get; set; }
	public int Color { get; set; }
	public string Text { get; set; }
}

public class DataCykleWithMotor : BaseCar
{

}