using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace AutoBazar
{
	public class FindInDBCar : MenuProperties
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

		public FindInDBCar()
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

				Console.Clear();
				WriteTextWithCursorPosition("Osobní auta", 1, ConsoleColor.White, ConsoleColor.Black);
				WriteButton("Jméno - " + name, 0, 0, selectItemID);
				//WriteButton("typ karoserie - " + typeCar, 1, 1, selectItemID);
				//WriteButton("Síla motoru - " + minPower + "-" + maxPower, 2, 2, selectItemID);
				//WriteButton("Objem motoru v cm - " + minValueInCm + "-" + maxValueInCm, 3, 3, selectItemID);
				//WriteButton("Převodovka - " + gearBoxType, 4, 4, selectItemID);
				//WriteButton("Barva - " + colorType, 5, 5, selectItemID);
				//WriteButton("typ motoru - " + motorType, 6, 6, selectItemID);
				//WriteButton("typ motoru - " + fuelType, 7, 7, selectItemID);
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
							//WriteFindedCar(typeCar, minPower, maxPower, minValueInCm, maxValueInCm, gearBoxType, colorType, motorType, fuelType);
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

		//public static void WriteFindedCar(string typeCar, int minPower, int maxPower, int minValueInCm,
		//	int maxValueInCm, string gearBoxType, string colorType, string motorType, string fuelType)
		//{
		//	Console.Clear();
		//	List<DataCar> typeCarList = car.FindAll(item => item.TypeCarString == typeCar);
		//	List<DataCar> powerCarList = car.FindAll(item => item.MotorPowerInKW >= minPower && item.MotorPowerInKW <= maxPower);
		//	List<DataCar> valueInCmCarList = car.FindAll(item => item.MotorValueInCm >= minValueInCm && item.MotorValueInCm <= maxValueInCm);
		//	List<DataCar> gearBoxTypeCarList = car.FindAll(item => item.GearBoxString == gearBoxType);
		//	List<DataCar> colorCarList = car.FindAll(item => item.ColorString == colorType);
		//	List<DataCar> motorCarList = car.FindAll(item => item.MotorTypeString == motorType);
		//	List<DataCar> fuelCarList = car.FindAll(item => item.FuelTypeString == fuelType);
		//	List<DataCar> CarList = new List<DataCar>();

		//	if (typeCarList.Count > 0 || powerCarList.Count > 0 || valueInCmCarList.Count > 0 ||
		//		gearBoxTypeCarList.Count > 0 || colorCarList.Count > 0 || motorCarList.Count > 0 ||
		//		fuelCarList.Count > 0)
		//	{
		//		if (typeCarList.Count > 0)
		//		{

		//		}
		//	}
		//	else
		//	{
		//		WriteTextWithCursorPosition("is empty", 1);
		//	}
		//	Console.ReadKey();
		//}
	}
}
