using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteToWindows
{
	class Program
	{
		public static void WriteTextWithUseMouse(string text, int row, int lastPos, int textLength)
		{
			int screenWidth = Console.WindowWidth;
			System.Console.SetCursorPosition(((screenWidth / 2) - (textLength / 2)) + lastPos, row);
		  Console.WriteLine(text);
		}

		static void Main(string[] args)
		{
			Console.SetWindowSize(100, 30);
			Console.SetBufferSize(100, 30);
			Start();
			Console.ReadKey();
		}

		static void Start()
		{

		}

		static void GenerateWindow()
		{
			int[] posWindowsXX;
			int[] posWindowsYZ;
			int window = 0;
			do
			{
				GenerateOneWindow(ref window,ref posWindowsXX, ref posWindowsYZ);
			} while (window == 2);
		}

		static void GenerateOneWindow(ref int window, ref int[] posWindowsX, ref int[] posWindowsY)
		{

			Random r = new Random();
			int randomSquare = r.Next(0, 100);
			bool notSquare = false;
			int sizeX = 0;
			int sizeY = 0;
			if (randomSquare > 50)
			{
				notSquare = true;
			}

			if (!notSquare)
			{
				sizeX = r.Next(5,15);
			}
			else
			{
				sizeX = r.Next(5, 15);
				sizeY = r.Next(5, 15);
			}

			if(window == 0)
			{
				int randomPosX = r.Next(sizeX / 2, 100 - (sizeX / 2));
				int randomPosY = r.Next(sizeY / 2, 30 - (sizeY / 2));
				posWindowsX[window] = randomPosX;
				posWindowsY[window] = randomPosY;
				window++;
			}
			else if(window == 1)
			{
				int randomPosX = r.Next(sizeX / 2, 100 - (sizeX / 2));
				int randomPosY = r.Next(sizeY / 2, 30 - (sizeY / 2));
				if(randomPosX >= posWindowsX[window - 1] && randomPosX <= posWindowsX[window - 1]
				&& randomPosY >= posWindowsY[window - 1] && randomPosY <= posWindowsY[window - 1])
				{
					posWindowsX[window] = randomPosX;
					posWindowsY[window] = randomPosY;
					window++;
				}
			}
			else if (window == 2)
			{
				int randomPosX = r.Next(sizeX / 2, 100 - (sizeX / 2));
				int randomPosY = r.Next(sizeY / 2, 30 - (sizeY / 2));
				if (randomPosX >= posWindowsX[window - 1] && randomPosX <= posWindowsX[window - 1]
				&& randomPosY >= posWindowsY[window - 1] && randomPosY <= posWindowsY[window - 1]
				&& randomPosX >= posWindowsX[window - 2] && randomPosX <= posWindowsX[window - 2]
				&& randomPosY >= posWindowsY[window - 2] && randomPosY <= posWindowsY[window - 2])
				{
					posWindowsX[window] = randomPosX;
					posWindowsY[window] = randomPosY;
					window++;
				}
			}
		}
	}
}
