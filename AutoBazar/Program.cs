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
		//public static List<DataCargoCar> cargoCar = new List<DataCargoCar>();

		static void Main(string[] args)
		{
			Console.CursorVisible = false;
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
							CargoCarDB secondObj = new CargoCarDB();
							break;
						case 2:
							Console.Clear();
							BusDB thirdObj = new BusDB();
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

		static void AnotherOptions()
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
							FindInDBCar go = new FindInDBCar();
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
}