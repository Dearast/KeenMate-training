﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

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
        public static string CarDBPath = Environment.ExpandEnvironmentVariables(ConfigurationSettings.AppSettings["CarDBPath"]);
        public static string DefaultPath = Environment.ExpandEnvironmentVariables(ConfigurationSettings.AppSettings["Path"]);

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
                CheckMaxSizeCarDB(maxMotorType, maxColorType, maxGearBoxType, maxTypeCar, maxFuelType, ref selectMotorType,
                ref selectColorType, ref selectGearBoxType, ref selectTypeCar, ref selectFuelType);
                CheckStringSelectEnum(out string motorType, out string colorType, out string gearBoxType,
                out string typeCar, out string fuelType, selectMotorType, selectColorType, selectGearBoxType,
                selectFuelType, selectTypeCar);
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
                            int.TryParse(Console.ReadLine(), out power);
                            break;
                        case 3:
                            WriteToButton(3, "Objem motoru v cm - ");
                            int.TryParse(Console.ReadLine(), out valueInCm);
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
                            File.WriteAllText(CarDBPath, jsonCar);
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
            if (!Directory.Exists(DefaultPath))
            {
                Directory.CreateDirectory(DefaultPath);
            }
            if (!File.Exists(CarDBPath))
            {
                FileStream DB = new FileStream(CarDBPath, FileMode.Create);
                DB.Close();
                DataCar newCar = new DataCar();
                string jsonCarNew = JsonConvert.SerializeObject(newCar);
                File.WriteAllText(CarDBPath, jsonCarNew);
                CreateNewCar();
            }
            else
            {
                if (File.ReadAllText(CarDBPath) != string.Empty)
                {
                    try
                    {
                        string jsonCar = File.ReadAllText(CarDBPath);
                        List<DataCar> deserializedCar = JsonConvert.DeserializeObject<List<DataCar>>(jsonCar);
                        car = deserializedCar;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        WriteTextWithCursorPosition("Database is not compatible with this version \n Database will be removed \n Press any key to continue", 1);
                        Console.WriteLine(ex.Message);
                        Console.ReadKey();
                        File.Delete(CarDBPath);
                        Console.Clear();
                        return;
                    }
                }
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
                    CheckMaxSizeCarDB(maxMotorType, maxColorType, maxGearBoxType, maxTypeCar, maxFuelType, ref selectMotorType,
                    ref selectColorType, ref selectGearBoxType, ref selectTypeCar, ref selectFuelType);
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
