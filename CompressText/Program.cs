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
			CompressingText();
		}

		public static void DeCompress()
		{

		}

		public static void FindDuplicate()
		{

		}

		public static void PasteText(string path)
		{
			WriteLine("Paste text to " + path);
			WriteLine("After paste the text press any key to continue");
			Console.ReadKey();
			CompressingText();
		}

		public static void CompressingText()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "Default.txt");
			string text = string.Empty;
			if (!File.Exists(path))
			{
				File.Create(path);
			}
			text = File.ReadAllText(path, Encoding.UTF8);
			if (string.IsNullOrEmpty(text))
			{
				PasteText(path);
			}
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

			words = WordsList(words, words.Count);
			Console.Clear();
			for (int i = 0; i < words.Count; i++)
			{
				WriteLine(words[i], ConsoleColor.Green);
			}

			for (int i = 0; i < words.Count; i++)
			{
				if(i > 0)
				{
					for (int a = 0; a < i; a++)
					{
						if(words[i] == words[a])
						{

						}
					}
				}
				else
				{

				}
			}
		}

		public static List<string> WordsList(List<string> word,int maxWord)
		{
			List<string> removeWord = new List<string>();
			for (int i = 0; i < word.Count; i++)
			{
				char[] wordChar = word[i].ToCharArray();
				if(string.IsNullOrEmpty(word[i]) || string.IsNullOrWhiteSpace(word[i]) || word[i].Length <= 3)
				{
					removeWord.Add(word[i]);
				}

				for (int a = 0; a < wordChar.Length; a++)
				{
					if (char.IsDigit(wordChar[a]) || char.IsSymbol(wordChar[a]))
					{
						removeWord.Add(word[i]);
					}
				}
			}
			for (int i = 0; i < removeWord.Count; i++)
			{
				DeletingWord(ref word, i, removeWord);
			}
			return word;
		}

		public static void DeletingWord(ref List<string> word,int index,List<string> removeWord)
		{
			WriteLine("remove this - " + removeWord[index]);
			word.Remove(removeWord[index]);
		}
	}
}
