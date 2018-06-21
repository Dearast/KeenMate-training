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
			Write("Training by KeenMate \t\t\t\t\t\t\t Done by Damien Clément");
			SelectFunction();
		}

		public static void Write(string text, ConsoleColor color = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
		{
			Console.ForegroundColor = color;
			Console.BackgroundColor = backColor;
			Console.WriteLine(text);
		}

		public static void SelectFunction()
		{
			Write("Select funciton");
			Write("0 = Create folder");
			Write("1 = Create file");
			Write("2 = Find all files in direction");
			Write("3 = Delete file");
			Write("4 = Browser");
			string check = Console.ReadLine();
			if (check == "0")
			{
				CreateFolder();
			}
			else if (check == "1")
			{
				FileCreator();
			}
			else if (check == "2")
			{
				FindAllFilesInDirection();
			}
			else if (check == "3")
			{
				DeletingFile();
			}
			else if (check == "4")
			{
				FindAllDisk();
			}
		}

		public static void IsDisk(ref bool isDisk,string path)
		{
			char[] charx = path.ToCharArray();
			int index = 0;
			foreach (var item in charx)
			{
				if(item.ToString() == @"\")
				{
					Write("this is disk", ConsoleColor.Blue);
					index++;
				}

				if(index > 1)
				{
					isDisk = true;
					break;
				}
			}
		}

		public static void WriteAllSubFolder(string @path)
		{
			Write("Current path - " + path,ConsoleColor.Red);
			string lastPath = System.IO.Directory.GetCurrentDirectory();
			string directory = string.Empty;
			bool isInDisk = false;
			IsDisk(ref isInDisk, path);
			if(!isInDisk)
			{
				directory = System.IO.Directory.GetParent(path).ToString();
				Write(directory + " Parent", ConsoleColor.Blue);
			}
			string[] dirs = Directory.GetDirectories(path, "*");
			int index = 0;
			foreach (var item in dirs)
			{
				index++;
				Write((index - 1) + " - " + item);
				if (index == (dirs.Length - 1) && !isInDisk)
				{
					Write(directory + " - for back");
				}
			}
			Write("Select function");
			Write("0 = Go to browser");
			string check = Console.ReadLine();
			switch (check)
			{
				case "0":
					if (!isInDisk)
					{
						Browser(dirs, directory);
					}
					else
					{
						Browser(dirs);
					}
					break;
				default:
					SelectFunction();
					break;
			}
		}

		public static void FindAllDisk()
		{
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			string[] DisksName = new string[allDrives.Length];
			int index = 0;
			foreach (var item in allDrives)
			{
				DisksName[index] = item.Name;
				Write(DisksName[index]);
				index++;
			}
			Write("Select funcion");
			Write("0 = select disk");
			Write("anything = go to menu");
			string check = Console.ReadLine();
			switch (check)
			{
				case "0":
					SelectDisk(DisksName);
					break;
				default:
					SelectFunction();
					break;
			}
			//Write("Current path - " + path);
			//string directory = string.Empty;
			//if (path != @"C:\")
			//{
			//	directory = System.IO.Directory.GetParent(path).ToString();
			//}
			//string[] dirs = Directory.GetDirectories(path, "*");
			//int index = 0;
			//foreach (var item in dirs)
			//{
			//	index++;
			//	Write(index + " - " + item);
			//	if (index == (dirs.Length - 1) && path != @"C:\")
			//	{
			//		Write((index + 1) + " - " + directory + " - for back");
			//	}
			//}
			//string check = Console.ReadLine();
			//int checkNumber = int.Parse(check);
			//switch (checkNumber)
			//{
			//	case 0:
			//		WriteAllSubFolder();
			//		break;
			//	case 1:
			//		Browser();
			//		break;
			//	default:
			//		SelectFunction();
			//		break;
			//}
		}

		public static void SelectDisk(string[] name)
		{
			Write("Select disk");
			int index = 0;
			foreach (var item in name)
			{
				Write(index + " = " + name[index]);
				index++;
			}
			string check = Console.ReadLine();
			if(int.Parse(check) <= name.Length)
			{
				WriteAllSubFolder(name[int.Parse(check)]);
			}
			else
			{
				SelectFunction();
			}
		}

		public static void Browser(string[] dirs,string directory = "")
		{
			Write("select path");
			string write = Console.ReadLine();
			int number = int.Parse(write);
			if (number < dirs.Length)
			{
				WriteAllSubFolder(dirs[number]);
			}
			else
			{
				WriteAllSubFolder(directory);
			}
			SelectFunction();
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
