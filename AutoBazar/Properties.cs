﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace AutoBazar
{
	class Properties
	{

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

		public static void CheckStringSelectEnum(out string motorType, out string colorType, out string gearBoxType,
	out string typeCar, out string fuelType,int selectMotorType,int selectColorType,int selectGearBoxType,
	int selectTypeCar,int selectFuelType)
		{
			motorType = Enum.GetName(typeof(DataCar.MotorTypeEnum), selectMotorType);
			colorType = Enum.GetName(typeof(DataCar.ColorTypeEnum), selectColorType);
			gearBoxType = Enum.GetName(typeof(DataCar.GearBoxTypeEnum), selectGearBoxType);
			typeCar = Enum.GetName(typeof(DataCar.TypeCarEnum), selectTypeCar);
			fuelType = Enum.GetName(typeof(DataCar.FuelTypeEnum), selectFuelType);
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

		public static void SaveDataBus(List<DataBus> car)
		{
			string jsonCar = JsonConvert.SerializeObject(car);
			File.WriteAllText(Environment.ExpandEnvironmentVariables("%AppData%\\MyProjects\\SaveBus.txt"), jsonCar);
		}
	}
}
