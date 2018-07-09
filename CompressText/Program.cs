using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CompressText
{
	class Program
	{
		public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White, bool center = false, bool backToDefault = false, ConsoleColor backColor = ConsoleColor.Black)
		{
			Console.ForegroundColor = color;
			Console.BackgroundColor = backColor;
			if (center)
			{
				int screenWidth = Console.WindowWidth;
				int stringWidth = text.Length;
				int spaces = (screenWidth / 2) + (stringWidth / 2);
				Console.WriteLine(text.PadLeft(spaces));
			}
			else
			{
				Console.WriteLine(text);
			}

			if (backToDefault)
			{
				Console.ForegroundColor = ConsoleColor.White;
			}
		}

		public static void WriteTextWithCursorPosition(string text,bool isInMiddle, int row, ConsoleColor color = ConsoleColor.White)
		{
			int screenWidth = Console.WindowWidth;
			if (isInMiddle)
			{
				System.Console.SetCursorPosition(((screenWidth / 2) - (text.Length / 2)), row);
			}
			else
			{
				System.Console.SetCursorPosition(0, row);
			}
			Console.ForegroundColor = color;
			Console.WriteLine(text);
		}

		static void Main(string[] args)
		{
			Start();
			Console.ReadKey();
		}

		public static void Start()
		{
			Console.Clear();
			string path = @"C:\Git\CompressText\bin\Debug\Default.txt";
			CompressingText(path);
		}

		public static void DeCompress()
		{

		}

		public static void FindDuplicate()
		{

		}

		public static void CompressingText(string path)
		{
			File.Create(@"C:\Git\CompressText\bin\Debug\Compress.txt");
			string text = File.ReadAllText(path,Encoding.UTF8);
			char[] charText = text.ToCharArray();
			int lastPosText = 0;
			List<string> words = new List<string>();
			string newWord = string.Empty;
			for (int i = 0; i < charText.Length; i++)
			{
				if (char.IsWhiteSpace(charText[i]))
				{
					for (int a = lastPosText; a < i; a++)
					{
						if (!char.IsWhiteSpace(charText[a]) && !char.IsNumber(charText[a]) 
							&& !char.IsPunctuation(charText[a]))
						{
							newWord += charText[a];
						}
					}
					words.Add(newWord);
					lastPosText = i;
					newWord = string.Empty;
				}
			}

			for

			for (int i = 0; i < words.Count; i++)
			{
				WriteLine(words[i], ConsoleColor.Green);
			}
		}

		public static List<string> WordsList(ref List<string> word,int index,int maxWord)
		{
			if(index != maxWord)
			{
				List<string> newList = word;
				for (int i = 0; i < length; i++)
				{

					if (string.IsNullOrEmpty(word[i]) || string.IsNullOrWhiteSpace(word[i]))
					{
						word.RemoveAt(i);
					}
					else if (charTextX[a] == (char)13)
					{
						word.RemoveAt(i);
					}
					else if (word[i].Length < 5)
					{
						word.RemoveAt(i);
					}

				}
			}
			else
			{

			}
		}
	}
}
