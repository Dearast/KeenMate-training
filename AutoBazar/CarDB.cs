using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace AutoBazar
{
	public class CarDB : MenuProperties
	{
		public static List<DataCar> car = new List<DataCar>();
		public static int selectMotorType = 0;
		public static int maxMotorType = Enum.GetNames(typeof(DataCar.MotorTypeEnum)).Length;
		public static int selectColorType = 0;
		public static int maxColorType = Enum.GetNames(typeof(DataCar.ColorTypeEnum)).Length;
		public static int selectGearBoxType = 0;
		public static int maxGearBoxType = Enum.GetNames(typeof(DataCar.GearBoxTypeEnum)).Length;
		public static int selectTypeCar = 0;
		public static int maxTypeCar = Enum.GetNames(typeof(DataCar.TypeCarEnum)).Length;
		public static int selectFuelType = 0;
		public static int maxFuelType = Enum.GetNames(typeof(DataCar.FuelTypeEnum)).Length;

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
				CheckStringSelectEnum(out string motorType, out string colorType, out string gearBoxType,
			out string typeCar, out string fuelType,selectMotorType,selectColorType,selectGearBoxType,selectTypeCar,
			selectFuelType);
				Console.Clear();
				WriteTextWithCursorPosition("Osobní auta", 1, ConsoleColor.White, ConsoleColor.Black);
				WriteTextWithCursorPosition("Vytvoření nového vozidla", 2, ConsoleColor.White, ConsoleColor.Black);
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
				ConsoleTextSelect(0, 10, ans, ref selectItemID);
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
								FuelType = (DataCar.FuelTypeEnum)selectFuelType,
								NameText = name,
								CarType = (DataCar.TypeCarEnum)selectTypeCar,
								MotorPowerInKW = power,
								MotorValueInCm = valueInCm,
								GearType = (DataCar.GearBoxTypeEnum)selectGearBoxType,
								Color = (DataCar.ColorTypeEnum)selectColorType,
								MotorType = (DataCar.MotorTypeEnum)selectMotorType
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

					CheckStringSelectEnum(out string motorType, out string colorType, out string gearBoxType,
			out string typeCar, out string fuelType,selectMotorType,selectColorType,selectGearBoxType,selectColorType,selectFuelType);
					WriteTextWithCursorPosition("Osobní auta", 1, ConsoleColor.White, ConsoleColor.Black);
					WriteTextWithCursorPosition("Vykreslení seznamu", 2, ConsoleColor.White, ConsoleColor.Black);
					WriteButton("Jméno - " + car[selectCar].NameText, 0, 0, selectItemID);
					WriteButton("typ karoserie - " + car[selectCar].CarType, 1, 1, selectItemID);
					WriteButton("Síla motoru - " + car[selectCar].MotorPowerInKW + " KW|Koně - " + car[selectCar].MotorPowerInKW * 1.34102209f, 2, 2, selectItemID);
					WriteButton("Objem motoru v cm - " + car[selectCar].MotorValueInCm, 3, 3, selectItemID);
					WriteButton("Převodovka - " + car[selectCar].GearType, 4, 4, selectItemID);
					WriteButton("Barva - " + car[selectCar].Color, 5, 5, selectItemID);
					WriteButton("typ motoru - " + car[selectCar].MotorType, 6, 6, selectItemID);
					WriteButton("typ paliva - " + car[selectCar].FuelType, 7, 7, selectItemID);
					WriteButton("Odejít", 8, 8, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
					WriteButton("Vymazat", 9, 9, selectItemID, ConsoleColor.Red, ConsoleColor.DarkRed);
					ConsoleKeyInfo ans = Console.ReadKey(true);
					ConsoleTextSelect(0, 9, ans, ref selectItemID);
					switch (selectItemID)
					{
						case 1:
							ConsoleTypeSelect(0, maxTypeCar, ans, ref selectTypeCar, 1, selectItemID);
							car[selectCar].CarType = (DataCar.TypeCarEnum)selectTypeCar;
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
}
