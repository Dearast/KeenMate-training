using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace AutoBazar
{
	class Program : MenuProperties
	{
		public static List<DataCargoCar> cargoCar = new List<DataCargoCar>();

		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			List<int> intList = new List<int>();
			intList.Add(5);
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
				ConsoleKeyInfo ans = Console.ReadKey(true);
				ConsoleTextSelect(0, 2, ans, ref selectItemID);
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
							AnotherOptions objExample = new AnotherOptions();
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
							CarDB objExample = new CarDB();
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

		static void EndApp()
		{
			Environment.Exit(0);
		}
	}
}

public class MenuProperties
{
	public static void WriteToButton(int addRow, string text)
	{
		int screenWidth = Console.WindowWidth;
		int height = Console.WindowHeight;
		int row = (height / 2) - 3 + addRow;
		WriteTextWithCursorPosition("                                                                     ", row);
		System.Console.SetCursorPosition(((screenWidth / 2) - (text.Length / 2)), row);
		Console.ForegroundColor = ConsoleColor.White;
	}

	public static void WriteTextWithCursorPosition(string text, int row, ConsoleColor color = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
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

	public static void ConsoleTextSelect(int min, int max, ConsoleKeyInfo ans, ref int selectItemID)
	{
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

	public static void ConsoleTypeSelect(int min, int max, ConsoleKeyInfo ans, ref int selectItemID, int IDItem, int selectItem)
	{
		if (selectItem == IDItem)
		{
			if (ans.Key == ConsoleKey.LeftArrow)
			{
				selectItemID--;
				if (selectItemID < min)
				{
					selectItemID = min;
				}
			}
			else if (ans.Key == ConsoleKey.RightArrow)
			{
				selectItemID++;
				if (selectItemID > max)
				{
					selectItemID = max;
				}
			}
		}
	}

	public static void SaveDataCar(List<DataCar> car)
	{
		string jsonCar = JsonConvert.SerializeObject(car);
		File.WriteAllText("%AppData%\\MyProjects\\SaveCar.txt", jsonCar);
	}
}

public class AnotherOptions : MenuProperties
{
	public AnotherOptions()
	{
		int selectItemID = 0;
		int height = Console.WindowHeight;
		do
		{
			WriteTextWithCursorPosition("Další možnosti", 1, ConsoleColor.White, ConsoleColor.Black);
			WriteButton("Najít", 0, 0, selectItemID);
			WriteButton("Odejít", 1, 1, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
			ConsoleKeyInfo ans = Console.ReadKey(true);
			ConsoleTextSelect(0, 8, ans, ref selectItemID);
			if (ans.Key == ConsoleKey.Enter)
			{
				switch (selectItemID)
				{
					case 0:
						
						break;
					case 1:
						return;
					default:
						break;
				}
			}
		} while (true);
	}
}

public class CarDB : MenuProperties
{
	public static List<DataCar> car = new List<DataCar>();
	public static int selectMotorType = 0;
	public static int maxMotorType = 2;
	public static int selectColorType = 0;
	public static int maxColorType = 9;
	public static int selectGearBoxType = 0;
	public static int maxGearBoxType = 9;
	public static int selectTypeCar = 0;
	public static int maxTypeCar = 13;
	public static int selectFuelType = 0;
	public static int maxFuelType = 5;

	public CarDB()
	{
		DrawDataCar();
		//string ID = "kappa";
		//var namecar = car.Where(item => item.NameText == ID);
	}

	public static void CreateNewCar()
	{
		if (car == null)
		{
			car = new List<DataCar>();
		}
		int selectItemID = 0;
		string name = string.Empty;
		string textPref = string.Empty;
		string fuel = string.Empty;
		int power = 0;
		int valueInCm = 0;
		do
		{
			if (selectMotorType > maxMotorType)
			{
				selectMotorType = maxMotorType;
			}
			if (selectColorType > maxColorType)
			{
				selectColorType = maxColorType;
			}
			if (selectGearBoxType > maxGearBoxType)
			{
				selectGearBoxType = maxGearBoxType;
			}
			if (selectTypeCar > maxTypeCar)
			{
				selectTypeCar = maxTypeCar;
			}
			if (selectFuelType > maxFuelType)
			{
				selectFuelType = maxFuelType;
			}

			string motorType = Enum.GetName(typeof(DataCar.MotorType), selectMotorType);
			string colorType = Enum.GetName(typeof(DataCar.ColorType), selectColorType);
			string gearBoxType = Enum.GetName(typeof(DataCar.GearBoxType), selectGearBoxType);
			string typeCar = Enum.GetName(typeof(DataCar.TypeCar), selectTypeCar);
			string fuelType = Enum.GetName(typeof(DataCar.FuelType), selectFuelType);
			Console.Clear();
			WriteTextWithCursorPosition("Osobní auta", 1, ConsoleColor.White, ConsoleColor.Black);
			WriteButton("Jméno - " + name, 0, 0, selectItemID);
			WriteButton("typ karoserie - " + typeCar, 1, 1, selectItemID);
			WriteButton("Síla motoru - " + power, 2, 2, selectItemID);
			WriteButton("Objem motoru v cm - " + valueInCm, 3, 3, selectItemID);
			WriteButton("Převodovka - " + gearBoxType, 4, 4, selectItemID);
			WriteButton("Barva - " + colorType, 5, 5, selectItemID);
			WriteButton("typ motoru - " + motorType, 6, 6, selectItemID);
			WriteButton("typ motoru - " + fuelType, 7, 7, selectItemID);
			WriteButton("Uložit", 8, 8, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
			WriteButton("Odejít bez uložení", 9, 9, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
			ConsoleKeyInfo ans = Console.ReadKey(true);
			ConsoleTextSelect(0, 8, ans, ref selectItemID);
			ConsoleTypeSelect(0, maxMotorType, ans, ref selectMotorType, 6, selectItemID);
			ConsoleTypeSelect(0, maxColorType, ans, ref selectColorType, 5, selectItemID);
			ConsoleTypeSelect(0, maxGearBoxType, ans, ref selectGearBoxType, 4, selectItemID);
			ConsoleTypeSelect(0, maxTypeCar, ans, ref selectTypeCar, 1, selectItemID);
			ConsoleTypeSelect(0, maxFuelType, ans, ref selectTypeCar, 7, selectItemID);
			if (ans.Key == ConsoleKey.Enter)
			{
				switch (selectItemID)
				{
					case 0:
						WriteToButton(0, "Jméno - ");
						name = Console.ReadLine();
						break;
					case 2:
						WriteToButton(2, "Síla motoru - ");
						power = int.Parse(Console.ReadLine());
						break;
					case 3:
						WriteToButton(3, "Objem motoru v cm - ");
						valueInCm = int.Parse(Console.ReadLine());
						break;
					case 8:
						DataCar addCar = new DataCar
						{
							FuelTypeString = fuelType,
							NameText = name,
							TypeCarString = typeCar,
							MotorPowerInKW = power,
							MotorValueInCm = valueInCm,
							GearBoxString = gearBoxType,
							ColorString = colorType,
							MotorTypeString = motorType
						};
						car.Add(addCar);
						Console.Clear();
						string jsonCar = JsonConvert.SerializeObject(car);
						File.WriteAllText(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCar.txt"), jsonCar);
						return;
					case 9:
						Console.Clear();
						return;
					default:
						break;
				}
			}
		} while (true);
	}

	static void DrawDataCar()
	{
		if (!File.Exists(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCar.txt")))
		{
			Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects"));
			File.Create(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCar.txt"));
			DataCar newCar = new DataCar();
			string jsonCarNew = JsonConvert.SerializeObject(newCar);
			File.WriteAllText(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCar.txt"), jsonCarNew);
			CreateNewCar();
		}
		else
		{
			string jsonCar = File.ReadAllText(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCar.txt"));
			List<DataCar> deserializedCar = JsonConvert.DeserializeObject<List<DataCar>>(jsonCar);
			car = deserializedCar;
		}
		int selectItemID = 0;
		int selectCar = 0;
		if(car == null)
		{
			CreateNewCar();
		}
		else
		{
			do
			{
				WriteTextWithCursorPosition("Osobní auta", 1, ConsoleColor.White, ConsoleColor.Black);
				WriteButton("Jméno - " + car[selectCar].NameText, 0, 0, selectItemID);
				WriteButton("typ karoserie - " + car[selectCar].TypeCarString, 1, 1, selectItemID);
				WriteButton("Síla motoru - " + car[selectCar].MotorPowerInKW + " KW|Koně - " + car[selectCar].MotorPowerInKW * 1.34102209f, 2, 2, selectItemID);
				WriteButton("Objem motoru v cm - " + car[selectCar].MotorValueInCm, 3, 3, selectItemID);
				WriteButton("Převodovka - " + car[selectCar].GearBoxString, 4, 4, selectItemID);
				WriteButton("Barva - " + car[selectCar].ColorString, 5, 5, selectItemID);
				WriteButton("typ motoru - " + car[selectCar].MotorTypeString, 6, 6, selectItemID);
				WriteButton("Odejít", 7, 7, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
				WriteButton("Vymazat", 8, 8, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
				ConsoleKeyInfo ans = Console.ReadKey(true);
				ConsoleTextSelect(0, 8, ans, ref selectItemID);
				if (ans.Key == ConsoleKey.Enter)
				{
					switch (selectItemID)
					{
						case 0:
							WriteToButton(0, "Jméno - ");
							car[selectCar].NameText = Console.ReadLine();
							SaveDataCar(car);
							break;
						case 1:
							WriteToButton(1, "typ karoserie - ");
							car[selectCar].TypeCarString = Console.ReadLine();
							SaveDataCar(car);
							break;
						case 2:
							WriteToButton(2, "Síla motoru - ");
							car[selectCar].MotorPowerInKW = int.Parse(Console.ReadLine());
							SaveDataCar(car);
							break;
						case 3:
							WriteToButton(3, "Objem motoru v cm - ");
							car[selectCar].MotorValueInCm = int.Parse(Console.ReadLine());
							SaveDataCar(car);
							break;
						case 4:
							WriteToButton(4, "Převodovka - ");
							car[selectCar].GearBoxString = Console.ReadLine();
							SaveDataCar(car);
							break;
						case 5:
							WriteToButton(5, "Barva - ");
							car[selectCar].ColorString = Console.ReadLine();
							SaveDataCar(car);
							break;
						case 7:
							Console.Clear();
							return;
						case 8:
							if (car.Count == 1)
							{
								car.RemoveAt(selectCar);
								SaveDataCar(car);
								return;
							}
							else
							{
								car.RemoveAt(selectCar);
								SaveDataCar(car);
								Console.Clear();
								break;
							}
						default:
							break;
					}
				}
				else if (ans.Key == ConsoleKey.RightArrow)
				{
					if (selectCar == car.Count)
					{
						CreateNewCar();
						Console.Clear();
					}
					else
					{
						selectCar++;
						if (selectCar == car.Count)
						{
							Console.Clear();
							CreateNewCar();
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
	}
}

public class Base
{
	public enum ColorType { modrá, červená, zelená, žlutá, hnědá, oranžová, šedá, bíla, černá}
	public string ColorString { get; set; }
	public string NameText { get; set; }
	public int MotorValueInCm { get; set; }
	public int MotorPowerInKW { get; set; }
	public enum FuelType { electricity, benzine, oil, biofuel, gas }
	public string FuelTypeString { get; set; }
	public enum MotorType { electric, burner }
	public string MotorTypeString { get; set; }
}

public class DataCar : Base
{
	public enum GearBoxType { Automatická, Diferenciál, Manuální, Nápravová, Planetová, Reduktor, Rozvodovka, Synchronizovaná, Variátor }
	public string GearBoxString { get; set; }
	public enum TypeCar { sedan, liftback, hatchback, limuzína, kombi, MPV, SUV, crossover, terénní, pick_up, kabriolet, roadster, kupé }
	public string TypeCarString { get; set; }
}

public class DataCargoCar : DataCar
{
	public int LoadCapacity { get; set; }
}

public class DataBus : DataCargoCar
{
	public int Capacity { get; set; }
}

public class DataMotorcykle : Base
{

}

public class DataBike
{
	public int Type { get; set; }
	public int Color { get; set; }
	public string Text { get; set; }
}

public class DataBikecykleWithMotor : Base
{

}