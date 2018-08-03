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
			Test newTest = new Test(1);
			Console.CursorVisible = false;
			List<int> intList = new List<int>();
			intList.Add(5);
			Start();
		}

		static void Start()
		{
			Console.Clear();
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
			Console.Clear();
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
		File.WriteAllText(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCar.txt"), jsonCar);
	}

	public static void SaveDataCargoCar(List<DataCargoCar> car)
	{
		string jsonCar = JsonConvert.SerializeObject(car);
		File.WriteAllText(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCargoCar.txt"), jsonCar);
	}
}

public class AnotherOptions : MenuProperties
{
	public AnotherOptions()
	{
		Console.Clear();
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
						FindInDB go = new FindInDB();
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

public class FindInDB : MenuProperties
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

	public FindInDB()
	{
		Console.Clear();
		//select find
		//in car,cargo,bus,...
		FindInCarDB();
	}

	public static void FindInCarDB()
	{
		Console.Clear();
		string jsonCar = File.ReadAllText(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCar.txt"));
		List<DataCar> deserializedCar = JsonConvert.DeserializeObject<List<DataCar>>(jsonCar);
		car = deserializedCar;
		if (car == null)
		{
			//car = new List<DataCar>();
			WriteTextWithCursorPosition("Nelze vyhledavat v prazdnem seznamu", 1);
			Console.ReadKey();
			return;
		}
		int selectItemID = 0;
		string name = string.Empty;
		string textPref = string.Empty;
		string fuel = string.Empty;
		int minPower = 0;
		int maxPower = 0;
		int minValueInCm = 0;
		int maxValueInCm = 0;
		int height = Console.WindowHeight;
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
			WriteButton("Síla motoru - " + minPower + "-" + maxPower, 2, 2, selectItemID);
			WriteButton("Objem motoru v cm - " + minValueInCm + "-" + maxValueInCm, 3, 3, selectItemID);
			WriteButton("Převodovka - " + gearBoxType, 4, 4, selectItemID);
			WriteButton("Barva - " + colorType, 5, 5, selectItemID);
			WriteButton("typ motoru - " + motorType, 6, 6, selectItemID);
			WriteButton("typ motoru - " + fuelType, 7, 7, selectItemID);
			WriteButton("Najít", 8, 8, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
			WriteButton("Odejít", 9, 9, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
			ConsoleKeyInfo ans = Console.ReadKey(true);
			ConsoleTextSelect(0, 9, ans, ref selectItemID);
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
						minPower = int.Parse(Console.ReadLine());
						maxPower = int.Parse(Console.ReadLine());
						break;
					case 3:
						WriteToButton(3, "Objem motoru v cm - ");
						minValueInCm = int.Parse(Console.ReadLine());
						maxValueInCm = int.Parse(Console.ReadLine());
						break;
					case 8:
						Console.Clear();
						WriteFindedCar(typeCar,minPower,maxPower,minValueInCm,maxValueInCm,gearBoxType,colorType,motorType,fuelType);
						break;
					case 9:
						Console.Clear();
						return;
					default:
						break;
				}
			}
		} while (true);
	}

	public static void WriteFindedCar(string typeCar,int minPower,int maxPower,int minValueInCm,
		int maxValueInCm,string gearBoxType,string colorType,string motorType,string fuelType)
	{
		Console.Clear();
		List<DataCar> typeCarList = car.FindAll(item => item.TypeCarString == typeCar);
		List<DataCar> powerCarList = car.FindAll(item => item.MotorPowerInKW >= minPower && item.MotorPowerInKW <= maxPower);
		List<DataCar> valueInCmCarList = car.FindAll(item => item.MotorValueInCm >= minValueInCm && item.MotorValueInCm <= maxValueInCm);
		List<DataCar> gearBoxTypeCarList = car.FindAll(item => item.GearBoxString == gearBoxType);
		List<DataCar> colorCarList = car.FindAll(item => item.ColorString == colorType);
		List<DataCar> motorCarList = car.FindAll(item => item.MotorTypeString == motorType);
		List<DataCar> fuelCarList = car.FindAll(item => item.FuelTypeString == fuelType);
		List<DataCar> CarList = new List<DataCar>();
		
		if (typeCarList.Count > 0 || powerCarList.Count > 0 || valueInCmCarList.Count > 0 ||
			gearBoxTypeCarList.Count > 0 || colorCarList.Count > 0 || motorCarList.Count > 0 ||
			fuelCarList.Count > 0)
		{
			if(typeCarList.Count > 0)
			{

			}
		}
		else
		{
			WriteTextWithCursorPosition("is empty", 1);
		}
		Console.ReadKey();
	}
}

public class CarDB : MenuProperties
{
	public static List<DataCar> car = new List<DataCar>();
	public static int selectMotorType = 0;
	public static int maxMotorType = Enum.GetNames(typeof(DataCar.MotorType)).Length;
	public static int selectColorType = 0;
	public static int maxColorType = Enum.GetNames(typeof(DataCar.ColorType)).Length;
	public static int selectGearBoxType = 0;
	public static int maxGearBoxType = Enum.GetNames(typeof(DataCar.GearBoxType)).Length;
	public static int selectTypeCar = 0;
	public static int maxTypeCar = Enum.GetNames(typeof(DataCar.TypeCar)).Length;
	public static int selectFuelType = 0;
	public static int maxFuelType = Enum.GetNames(typeof(DataCar.FuelType)).Length;

	public CarDB()
	{
		Console.Clear();
		DrawDataCar();
	}

	public static void CreateNewCar()
	{
		Console.Clear();
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
			WriteButton("typ paliva - " + fuelType, 7, 7, selectItemID);
			WriteButton("Uložit", 8, 8, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
			WriteButton("Odejít bez uložení", 9, 9, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
			ConsoleKeyInfo ans = Console.ReadKey(true);
			ConsoleTextSelect(0, 9, ans, ref selectItemID);
			ConsoleTypeSelect(0, maxMotorType, ans, ref selectMotorType, 6, selectItemID);
			ConsoleTypeSelect(0, maxColorType, ans, ref selectColorType, 5, selectItemID);
			ConsoleTypeSelect(0, maxGearBoxType, ans, ref selectGearBoxType, 4, selectItemID);
			ConsoleTypeSelect(0, maxTypeCar, ans, ref selectTypeCar, 1, selectItemID);
			ConsoleTypeSelect(0, maxFuelType, ans, ref selectFuelType, 7, selectItemID);
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
		bool enableArrow = true;
		Console.Clear();
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
		if(car == null || car.Count == 0)
		{
			CreateNewCar();
		}
		else
		{
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

				WriteTextWithCursorPosition("Osobní auta", 1, ConsoleColor.White, ConsoleColor.Black);
				WriteButton("Jméno - " + car[selectCar].NameText, 0, 0, selectItemID);
				WriteButton("typ karoserie - " + car[selectCar].TypeCarString, 1, 1, selectItemID);
				WriteButton("Síla motoru - " + car[selectCar].MotorPowerInKW + " KW|Koně - " + car[selectCar].MotorPowerInKW * 1.34102209f, 2, 2, selectItemID);
				WriteButton("Objem motoru v cm - " + car[selectCar].MotorValueInCm, 3, 3, selectItemID);
				WriteButton("Převodovka - " + car[selectCar].GearBoxString, 4, 4, selectItemID);
				WriteButton("Barva - " + car[selectCar].ColorString, 5, 5, selectItemID);
				WriteButton("typ motoru - " + car[selectCar].MotorTypeString, 6, 6, selectItemID);
				WriteButton("typ paliva - " + car[selectCar].FuelTypeString, 7, 7, selectItemID);
				WriteButton("Odejít", 8, 8, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
				WriteButton("Vymazat", 9, 9, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
				ConsoleKeyInfo ans = Console.ReadKey(true);
				ConsoleTextSelect(0, 9, ans, ref selectItemID);
				switch (selectItemID)
				{
					case 1:
						ConsoleTypeSelect(0, maxTypeCar, ans, ref selectTypeCar, 1, selectItemID);
						car[selectCar].TypeCarString = typeCar;
						SaveDataCar(car);
						enableArrow = false;
						break;
					case 4:
						ConsoleTypeSelect(0, maxGearBoxType, ans, ref selectGearBoxType, 4, selectItemID);
						enableArrow = false;
						break;
					case 5:
						ConsoleTypeSelect(0, maxColorType, ans, ref selectColorType, 5, selectItemID);
						enableArrow = false;
						break;
					case 6:
						ConsoleTypeSelect(0, maxMotorType, ans, ref selectMotorType, 6, selectItemID);
						enableArrow = false;
						break;
					case 7:
						ConsoleTypeSelect(0, maxFuelType, ans, ref selectFuelType, 7, selectItemID);
						enableArrow = false;
						break;
					default:
						enableArrow = true;
						break;
				}
				if (ans.Key == ConsoleKey.Enter)
				{
					switch (selectItemID)
					{
						case 0:
							WriteToButton(0, "Jméno - ");
							car[selectCar].NameText = Console.ReadLine();
							SaveDataCar(car);
							break;
						case 8:
							Console.Clear();
							return;
						case 9:
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
				else if (ans.Key == ConsoleKey.RightArrow && enableArrow)
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
				else if (ans.Key == ConsoleKey.LeftArrow && enableArrow)
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

public class CargoCarDB : MenuProperties
{
	public static List<DataCargoCar> car = new List<DataCargoCar>();
	public static int selectMotorType = 0;
	public static int maxMotorType = Enum.GetNames(typeof(DataCar.MotorType)).Length;
	public static int selectColorType = 0;
	public static int maxColorType = Enum.GetNames(typeof(DataCar.ColorType)).Length;
	public static int selectGearBoxType = 0;
	public static int maxGearBoxType = Enum.GetNames(typeof(DataCar.GearBoxType)).Length;
	public static int selectTypeCar = 0;
	public static int maxTypeCar = Enum.GetNames(typeof(DataCar.TypeCar)).Length;
	public static int selectFuelType = 0;
	public static int maxFuelType = Enum.GetNames(typeof(DataCar.FuelType)).Length;

	public CargoCarDB()
	{
		Console.Clear();
		DrawDataCar();
	}

	public static void CreateNewCar()
	{
		Console.Clear();
		if (car == null)
		{
			car = new List<DataCargoCar>();
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

			string motorType = Enum.GetName(typeof(DataCargoCar.MotorType), selectMotorType);
			string colorType = Enum.GetName(typeof(DataCargoCar.ColorType), selectColorType);
			string gearBoxType = Enum.GetName(typeof(DataCargoCar.GearBoxType), selectGearBoxType);
			string typeCar = Enum.GetName(typeof(DataCargoCar.TypeCar), selectTypeCar);
			string fuelType = Enum.GetName(typeof(DataCargoCar.FuelType), selectFuelType);
			Console.Clear();
			WriteTextWithCursorPosition("Osobní auta", 1, ConsoleColor.White, ConsoleColor.Black);
			WriteButton("Jméno - " + name, 0, 0, selectItemID);
			WriteButton("typ karoserie - " + typeCar, 1, 1, selectItemID);
			WriteButton("Síla motoru - " + power, 2, 2, selectItemID);
			WriteButton("Objem motoru v cm - " + valueInCm, 3, 3, selectItemID);
			WriteButton("Převodovka - " + gearBoxType, 4, 4, selectItemID);
			WriteButton("Barva - " + colorType, 5, 5, selectItemID);
			WriteButton("typ motoru - " + motorType, 6, 6, selectItemID);
			WriteButton("typ paliva - " + fuelType, 7, 7, selectItemID);
			WriteButton("Uložit", 8, 8, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
			WriteButton("Odejít bez uložení", 9, 9, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
			ConsoleKeyInfo ans = Console.ReadKey(true);
			ConsoleTextSelect(0, 9, ans, ref selectItemID);
			ConsoleTypeSelect(0, maxMotorType, ans, ref selectMotorType, 6, selectItemID);
			ConsoleTypeSelect(0, maxColorType, ans, ref selectColorType, 5, selectItemID);
			ConsoleTypeSelect(0, maxGearBoxType, ans, ref selectGearBoxType, 4, selectItemID);
			ConsoleTypeSelect(0, maxTypeCar, ans, ref selectTypeCar, 1, selectItemID);
			ConsoleTypeSelect(0, maxFuelType, ans, ref selectFuelType, 7, selectItemID);
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
						DataCargoCar addCar = new DataCargoCar
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
						File.WriteAllText(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCargoCar.txt"), jsonCar);
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
		bool enableArrow = true;
		Console.Clear();
		if (!File.Exists(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCargoCar.txt")))
		{
			Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects"));
			File.Create(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCargoCar.txt"));
			DataCargoCar newCar = new DataCargoCar();
			string jsonCarNew = JsonConvert.SerializeObject(newCar);
			File.WriteAllText(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCargoCar.txt"), jsonCarNew);
			CreateNewCar();
		}
		else
		{
			string jsonCar = File.ReadAllText(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveCargoCar.txt"));
			List<DataCargoCar> deserializedCar = JsonConvert.DeserializeObject<List<DataCargoCar>>(jsonCar);
			car = deserializedCar;
		}
		int selectItemID = 0;
		int selectCar = 0;
		if (car == null || car.Count == 0)
		{
			CreateNewCar();
		}
		else
		{
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

				WriteTextWithCursorPosition("Osobní auta", 1, ConsoleColor.White, ConsoleColor.Black);
				WriteButton("Jméno - " + car[selectCar].NameText, 0, 0, selectItemID);
				WriteButton("typ karoserie - " + car[selectCar].TypeCarString, 1, 1, selectItemID);
				WriteButton("Síla motoru - " + car[selectCar].MotorPowerInKW + " KW|Koně - " + car[selectCar].MotorPowerInKW * 1.34102209f, 2, 2, selectItemID);
				WriteButton("Objem motoru v cm - " + car[selectCar].MotorValueInCm, 3, 3, selectItemID);
				WriteButton("Převodovka - " + car[selectCar].GearBoxString, 4, 4, selectItemID);
				WriteButton("Barva - " + car[selectCar].ColorString, 5, 5, selectItemID);
				WriteButton("typ motoru - " + car[selectCar].MotorTypeString, 6, 6, selectItemID);
				WriteButton("typ paliva - " + car[selectCar].FuelTypeString, 7, 7, selectItemID);
				WriteButton("Kapacita - " + car[selectCar].LoadCapacity, 8, 8, selectItemID);
				WriteButton("Odejít", 9, 9, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
				WriteButton("Vymazat", 10, 10, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
				ConsoleKeyInfo ans = Console.ReadKey(true);
				ConsoleTextSelect(0, 10, ans, ref selectItemID);
				switch (selectItemID)
				{
					case 1:
						ConsoleTypeSelect(0, maxTypeCar, ans, ref selectTypeCar, 1, selectItemID);
						car[selectCar].TypeCarString = typeCar;
						SaveDataCargoCar(car);
						enableArrow = false;
						break;
					case 4:
						ConsoleTypeSelect(0, maxGearBoxType, ans, ref selectGearBoxType, 4, selectItemID);
						enableArrow = false;
						break;
					case 5:
						ConsoleTypeSelect(0, maxColorType, ans, ref selectColorType, 5, selectItemID);
						enableArrow = false;
						break;
					case 6:
						ConsoleTypeSelect(0, maxMotorType, ans, ref selectMotorType, 6, selectItemID);
						enableArrow = false;
						break;
					case 7:
						ConsoleTypeSelect(0, maxFuelType, ans, ref selectFuelType, 7, selectItemID);
						enableArrow = false;
						break;
					default:
						enableArrow = true;
						break;
				}
				if (ans.Key == ConsoleKey.Enter)
				{
					switch (selectItemID)
					{
						case 0:
							WriteToButton(0, "Jméno - ");
							car[selectCar].NameText = Console.ReadLine();
							SaveDataCargoCar(car);
							break;
						case 8:
							WriteToButton(8, "Kapacita - ");
							car[selectCar].LoadCapacity = int.Parse(Console.ReadLine());
							SaveDataCargoCar(car);
							break;
						case 9:
							Console.Clear();
							return;
						case 10:
							if (car.Count == 1)
							{
								car.RemoveAt(selectCar);
								SaveDataCargoCar(car);
								return;
							}
							else
							{
								car.RemoveAt(selectCar);
								SaveDataCargoCar(car);
								Console.Clear();
								break;
							}
						default:
							break;
					}
				}
				else if (ans.Key == ConsoleKey.RightArrow && enableArrow)
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
				else if (ans.Key == ConsoleKey.LeftArrow && enableArrow)
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

public abstract class Base
{
	public enum ColorType { modrá, červená, zelená, žlutá, hnědá, oranžová, šedá, bíla, černá }
	public string ColorString { get; set; }
	public string NameText { get; set; }
	public int MotorValueInCm { get; set; }
	public int MotorPowerInKW { get; set; }
	public enum FuelType { electricity, benzine, oil, biofuel, gas }
	public string FuelTypeString { get; set; }
	public enum MotorType { electric, burner }
	public string MotorTypeString { get; set; }
}

public class Test : MenuProperties
{
	private Test()
	{
		DataCar newCar = new DataCar { GearType = DataCar.GearBoxType.Automatická };
		WriteTextWithCursorPosition("automaticka prevodovka", 5);
		Console.ReadKey();
	}

	public Test(int var)
	{
		DataCar newCar = new DataCar();
		switch (var)
		{
			case 0:
				newCar = new DataCar { GearType = DataCar.GearBoxType.Poloautomatická };
				WriteTextWithCursorPosition("poloautomaticka prevodovka", 5);
				Console.ReadKey();
				break;
			case 1:
				newCar = new DataCar { GearType = DataCar.GearBoxType.Variátor };
				WriteTextWithCursorPosition("variatorova prevodovka", 5);
				Console.ReadKey();
				break;
			default:
				break;
		}
	}
}

public class DataCar : Base
{
	public enum GearBoxType { Automatická, Poloautomatická, Manuální, Variátor }
	public string GearBoxString { get; set; }
	public GearBoxType GearType { get; set; }
	public enum TypeCar { sedan, liftback, hatchback, limuzína, kombi, MPV, SUV, crossover, terénní, pick_up, kabriolet, roadster, kupé }
	public string TypeCarString { get; set; }
	public TypeCar CarType { get; set; }
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