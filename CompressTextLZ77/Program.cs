using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompressTextLZ77
{
	class Program
	{
		public static int lastPosCompare = 0;
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

		static void Main(string[] args)
		{
			Start();
			Console.ReadKey();
		}

		public static void Start()
		{
			string pathDefault = Path.Combine(Directory.GetCurrentDirectory(), "Default.txt");
			string text = string.Empty;
			if (!File.Exists(pathDefault))
			{
				File.Create(pathDefault);
			}
			text = File.ReadAllText(pathDefault, Encoding.UTF8);
			if (string.IsNullOrEmpty(text))
			{
				PasteText(pathDefault);
			}
			List<string> wordList = GetAllWords(text);
			List<string> specifyWordList = GetAllSpecificWords(wordList);
			CompressingText(wordList, specifyWordList, Path.Combine(Directory.GetCurrentDirectory(), "Compress.txt"),text);
		}

		public static void PasteText(string path)
		{
			WriteLine("Paste text to " + path);
			WriteLine("After paste the text press any key to continue");
			Console.ReadKey();
			Start();
		}

		public static List<string> GetAllWords(string text)
		{
			List<string> newList = new List<string>();
			char[] textChar = text.ToCharArray();
			string wordText = string.Empty;
			int lastPos = 0;
			for (int i = 0; i < textChar.Length; i++)
			{
				if (char.IsWhiteSpace(textChar[i]))
				{
					for (int y = lastPos + 1; y < i; y++)
					{
						wordText += textChar[y];
					}
					lastPos = i;
					newList.Add(wordText);
					wordText = string.Empty;
				}
			}
			return newList;
		}

		public static List<string> GetAllSpecificWords(List<string> oldList)
		{
			List<string> newList = new List<string>();
			foreach (var item in oldList)
			{
				char[] charX = item.ToCharArray();
				string newWord = string.Empty;
				foreach (var item2 in charX)
				{
					if (!char.IsWhiteSpace(item2) && !char.IsNumber(item2)
					&& !char.IsPunctuation(item2))
					{
						newWord += item2;
					}
				}
				if (newWord.Length < 4)
				{
					newWord = string.Empty;
				}
				else
				{
					newList.Add(newWord);
					newWord = string.Empty;
				}
			}
			return newList;
		}

		public static void CompareWords(List<string> allWords, List<string> allSpecifyWords, ref string text,int index)
		{
			string word = string.Empty;
			for (int i = 0; i < allWords.Count; i++)
			{
				char[] charX = allWords[i].ToCharArray();
				char[] charY = allSpecifyWords[index].ToCharArray();
				for (int a = 0; a < allWords[i].Length; a++)
				{
					if(charY.Length >= allWords[i].Length)
					{
						if (charX[a] == charY[a])
						{
							word += charY;
						}
					}
					lastPosCompare++;
				}
				if (word.Length > 3)
				{
					string remove = text.Remove(lastPosCompare - allWords[i].Length + 2, allWords[i].Length - 2);
					string textLeft = text.Remove(lastPosCompare - allWords[i].Length + 2, text.Length - (lastPosCompare - allWords[i].Length + 2));
					string textRight = text.Remove(0, lastPosCompare);
				}
			}

		}

		public static void CompressingText(List<string> allWords,List<string> allSpecifyWords,string pathCompress,string text)
		{
			Console.WriteLine("Allwords - " + allWords.Count + " | allspecifywords - " + allSpecifyWords.Count);
			string newText = text;
			if (!File.Exists(pathCompress))
			{
				File.Create(pathCompress);
			}
			for (int i = 0; i < allSpecifyWords.Count; i++)
			{
				CompareWords(allWords, allSpecifyWords, ref newText,i);
			}
		}
	}
}
