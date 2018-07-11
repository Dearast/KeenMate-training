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
			CompressingText(wordList, specifyWordList, Path.Combine(Directory.GetCurrentDirectory(), "Compress.txt"), text);
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

		public static void CompareWords(List<string> allSpecifyWords, string text)
		{
			List<string> firstWord = allSpecifyWords;
			Dictionary<string, List<int>> contain = new Dictionary<string, List<int>>();
			int minLengthWord = 4;
			int currentLengthWord = 0;
			int replaced = 0;
			string checkWord = string.Empty;
			for (int i = 0; i < allSpecifyWords.Count; i++) //pro kazde specificke slovo
			{
				char[] charSpecificWord = allSpecifyWords[i].ToCharArray();
				for (int y = 0; y < text.Length; y++) //pro cely text
				{
					char[] charText = text.ToCharArray();
					for (int z = 0; z < charSpecificWord.Length; z++) //pro kazdy znak ve specifickem slove
					{
						if(charText[y] == charSpecificWord[z])
						{
							currentLengthWord++;
							checkWord += charSpecificWord[z];
						}
						if (char.IsWhiteSpace(charText[y]))
						{
							if (currentLengthWord >= minLengthWord)
							{
								if(firstWord.Contains(checkWord) && contain.ContainsKey(checkWord))
								{
									contain.TryGetValue(checkWord, out List<int> pos);
									bool isSamePos = false;
									foreach (var item in pos)
									{
										if(item == y)
										{
											isSamePos = true;
										}
									}
									if (!isSamePos)
									{
										pos.Add(y);
										contain[checkWord] = pos;
										replaced++;
									}
								}
								else if (firstWord.Contains(checkWord))
								{
									List<int> pos = new List<int>();
									pos.Add(y);
									contain.Add(checkWord, pos);
								}
								//else if (string.Compare(checkWord, allSpecifyWords[i]) <= 0)
								//{
								//	//Console.WriteLine("replace");
								//}
								currentLengthWord = 0;
								checkWord = string.Empty;
							}
							else
							{
								currentLengthWord = 0;
								checkWord = string.Empty;
							}
						}
					}
				}
			}
			Console.WriteLine(replaced);
			WriteCompress(text);
		}

		public static void WriteCompress(string text)
		{
			if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Compress.txt")))
			{
				File.Create(Path.Combine(Directory.GetCurrentDirectory(), "Compress.txt"));
			}

			File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "Compress.txt"), text);
		}

		public static void CompressingText(List<string> allWords,List<string> allSpecifyWords,string pathCompress,string text)
		{
			Console.WriteLine("Allwords - " + allWords.Count + " | allspecifywords - " + allSpecifyWords.Count);
			string newText = text;
			if (!File.Exists(pathCompress))
			{
				File.Create(pathCompress);
			}
			CompareWords(allSpecifyWords, newText);
			WriteCompress(newText);
		}
	}
}
