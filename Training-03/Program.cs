using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PathCreator
{
	class Program
	{
		static void Main(string[] args)
		{
			Write("Training by KeenMate \t\t\t\t\t\t\t Done by Damien Clément", ConsoleColor.Green);
			WriteFunctions();
			SelectFunction();
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

		public static void WriteFunctions()
		{
			Console.Clear();
			Write("Select funciton");
			Write("0 = Create folder");
			Write("1 = Create file");
			Write("2 = Find all files in direction");
			Write("3 = Delete file");
			Write("4 = Browser");
			Write("exit = end application");
		}
		
		public static void SelectFunction()
		{
			string check = Console.ReadLine();
			switch (check)
			{
				case "0":
					CreateFolder();
					break;
				case "1":
					FileCreator();
					break;
				case "2":
					FindAllFilesInDirection();
					break;
				case "3":
					DeletingFile();
					break;
				case "4":
					FindAllDisk();
					break;
				case "exit":
					Environment.Exit(0);
					break;
				case "Exit":
					Environment.Exit(0);
					break;
				case "EXIT":
					Environment.Exit(0);
					break;
				default:
					Write("Bad select function please try again", ConsoleColor.Red,true);
					SelectFunction();
					break;
			}
		}

		public static void WriteAllSubFolder(string path, int AdressNumber)
		{
			Write("Current path - " + path, ConsoleColor.Red);
			int adressChange = AdressNumber;
			string directory = string.Empty;
			string[] dirs;
			if(AdressNumber > 0)
			{
				directory = System.IO.Directory.GetParent(path).ToString();
				string[] newDirs = Directory.GetDirectories(path, "*");
				dirs = new string[(Directory.GetDirectories(path, "*")).Length + 1];
				for (int i = 0; i < newDirs.Length; i++)
				{
					dirs[i] = newDirs[i];
				}
				int length = dirs.Length;
				dirs[dirs.Length - 1] = directory;
			}
			else
			{
				dirs = new string[(Directory.GetDirectories(path, "*")).Length];
				dirs = Directory.GetDirectories(path, "*");
			}
			int index = 0;
			foreach (var item in dirs)
			{
				Write((index) + " - " + item);
				index++;
			}
			string check = Console.ReadLine();
			int checkInt = int.Parse(check);
			if(checkInt == (dirs.Length - 1) && AdressNumber > 0)
			{
				adressChange -= 1;
				Write("Down", ConsoleColor.Blue);
			}
			else
			{
				adressChange += 1;
				Write("Up", ConsoleColor.Blue);
			}
			Browser(dirs, checkInt,adressChange);
		}

		public static void FindAllDisk()
		{
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			string[] DisksName = new string[allDrives.Length];
			int index = 0;
			foreach (var item in allDrives)
			{
				DisksName[index] = item.Name;
				Write("index: " + index + " - " + DisksName[index]);
				index++;
			}
			Write("Select funcion");
			Write("anything else = go to menu");
			Write("Select adress");
			string check = Console.ReadLine();
			int checkInt = int.Parse(check);
			Browser(DisksName,checkInt);
		}

		public static void Browser(string[] adress, int checkNumber = 0, int AdressNumber = 0)
		{
			Write("Adress number - " + AdressNumber, ConsoleColor.Blue);

			WriteAllSubFolder(adress[checkNumber], AdressNumber);
		}

		public static void CreateFolder()
		{
			Write("enter path");
			string path = Console.ReadLine();
			if (!System.IO.Directory.Exists(@path))
			{
				//System.IO.Directory.CreateDirectory(@path + @"\" + i);
				Write("path not exist", ConsoleColor.Red);
				Write("if you want repeat enter path then you write 0");
				Write("if you want create path then you write 1");
				string check = Console.ReadLine();
				if (check == "0")
				{
					CreateFolder();
				}
				else if (check == "1")
				{
					System.IO.Directory.CreateDirectory(@path);
				}
				else
				{
					SelectFunction();
				}
			}
			else
			{
				Write("The folder exist in this path: " + path);
			}
			Write("Press enter to back");
			Console.ReadKey();
			SelectFunction();
		}

		public static void FileCreator()
		{
			Write("enter path for create files and type file");
			string path = Console.ReadLine();
			Write("how many file you want create");
			string countFolderStr = Console.ReadLine();
			int countFolder = int.Parse(countFolderStr);
			for (int i = 0; i < countFolder; i++)
			{
				File.Create(path + i + @".txt");
			}
			Write("Press enter to back");
			Console.ReadKey();
			SelectFunction();
		}

		public static void FindAllFilesInDirection()
		{
			Write("enter path for find files");
			string path = Console.ReadLine();
			DirectoryInfo d = new DirectoryInfo(@path);
			//FileInfo[] Files = d.GetFiles("*.txt");
			FileInfo[] Files = d.GetFiles();
			string str = "";
			foreach (FileInfo file in Files)
			{
				str = str + file.Name + "|" + file.CreationTime + "|" + file.Extension
				+ "|" + file.Attributes + "|" + file.Length + "|" + file.Directory + " ; ";
				Write(str, ConsoleColor.Red);
			}
			Write("Press enter to back");
			Console.ReadKey();
			SelectFunction();
		}

		public static void DeletingFile()
		{
			Write("enter path to delete file");
			string path = Console.ReadLine();
			File.Delete(@path);
			Write("Press enter to back");
			Console.ReadKey();
			SelectFunction();
		}
	}
}
