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
			selectFunction();
		}

		public static void Write(string text, ConsoleColor color = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
		{
			Console.ForegroundColor = color;
			Console.BackgroundColor = backColor;
			Console.WriteLine(text);
		}

		public static void selectFunction()
		{
			Write("Select funciton");
			Write("0 = Create folder");
			Write("1 = Create file");
			Write("2 = Find all files in direction");
			Write("3 = Delete file");
			string check = Console.ReadLine();
			if(check == "0")
			{
				createFolder();
			}
			else if(check == "1")
			{
				fileCreator();
			}
			else if(check == "2")
			{
				findAllFilesInDirection();
			}
			else if (check == "3")
			{
				deletingFile();
			}
		}

		public static void createFolder()
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
				if(check == "0")
				{
					createFolder();
				}
				else if(check == "1")
				{
					System.IO.Directory.CreateDirectory(@path);
				}
				else
				{
					selectFunction();
				}
			}
			else
			{
				Write("The folder exist in this path: " + path);
			}
			Write("Press enter to back");
			Console.ReadKey();
			selectFunction();
		}

		public static void fileCreator()
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
			selectFunction();
		}

		public static void findAllFilesInDirection()
		{
			Write("enter path for find files");
			string path = Console.ReadLine();
			DirectoryInfo d = new DirectoryInfo(@path);
			FileInfo[] Files = d.GetFiles("*.txt");
			string str = "";
			foreach (FileInfo file in Files)
			{
				str = str+ file.Name + "|" + file.CreationTime + "|" + file.Extension 
				+ "|" + file.Attributes + "|" + file.Length + "|" + file.Directory + " ; ";
				Write(str, ConsoleColor.Red);
			}
			Write("Press enter to back");
			Console.ReadKey();
			selectFunction();
		}

		public static void deletingFile()
		{
			Write("enter path to delete file");
			string path = Console.ReadLine();
			File.Delete(@path);
			Write("Press enter to back");
			Console.ReadKey();
			selectFunction();
		}
	}
}
