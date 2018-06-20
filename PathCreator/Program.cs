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
			fileCreator();
		}

		public static void Write(string write)
		{
			Console.WriteLine(write);
		}

		public static void fileCreator()
		{
			Write("enter path");
			string path = Console.ReadLine();
			Write("how many folder you want create");
			string countFolderStr = Console.ReadLine();
			Write("how many file you want create");
			string countFileStr = Console.ReadLine();

			int countFolder = int.Parse(countFolderStr);
			int countFile = int.Parse(countFileStr);

			for (int i = 0; i < countFolder; i++)
			{
				if (!System.IO.Directory.Exists(@path + i))
				{
					System.IO.Directory.CreateDirectory(@path + i);
					for (int a = 0; a < countFile; a++)
					{
						File.Create(@path + i + @"\file" + a + ".txt");
					}
				}
				else
				{
					for (int a = 0; a < countFile; a++)
					{
						File.Create(@path + i + @"\file" + a + ".txt");
					}
				}
			}
			Console.ReadLine();
		}
	}
}
