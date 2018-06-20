using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Title = "Training by KeenMate                                   Done by Damien Clément";	
			MainMenu();
		}

		public static void MainMenu()
		{
			#region Console
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("press key for call function");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("0 = Lower and Upper text");
			Console.WriteLine("1 = sorting text");
			Console.WriteLine("2 = Trim text");
			Console.WriteLine("3 = Remove part of text");
			Console.WriteLine("4 = Find part of text");
			Console.WriteLine("5 = Copy text");
			Console.WriteLine("6 = Reverse text");
			Console.WriteLine("7 = 1st letter after space will be uppercase");
			Console.WriteLine("8 = last word will uppercase");
			Console.WriteLine("9 = every second word will uppercase");
			Console.WriteLine("10 = delet without trim");
			Console.WriteLine("11 = calculation");
			Console.WriteLine("12 = change color by month and years");
			Console.WriteLine("13 = tip sport");
			Console.WriteLine("14 = fileCreator");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("try evil number");
			Console.ForegroundColor = ConsoleColor.Green;
			#endregion
			#region Functions
			string checkPress = Console.ReadLine();
			if (checkPress == "0")
			{
				loverUpperText();
			}
			else if (checkPress == "1")
			{
				sortingText();
			}
			else if(checkPress == "2")
			{
				TrimText();
			}
			else if(checkPress == "3")
			{
				RemovePartOfText();
			}
			else if(checkPress == "4")
			{
				FindPartOfText();
			}
			else if(checkPress == "5")
			{
				CopyText();
			}
			else if(checkPress == "6")
			{
				ReverseString();
			}
			else if(checkPress == "7")
			{
				uppercase();
			}
			else if(checkPress == "8")
			{
				uppercaseLastWord();
			}
			else if(checkPress == "9")
			{
				everySecondWordWillUppercase();
			}
			else if(checkPress == "10")
			{
				deleteWithoutTrim();
			}
			else if(checkPress == "11")
			{
				Calculator();
			}
			else if(checkPress == "12")
			{
				changeColor();
			}
			else if(checkPress == "13")
			{
				tipSport();
			}
			else if(checkPress == "14")
			{
				fileCreator();
			}
			else if(checkPress == "666")
			{
				Matrix();
			}
			#endregion
		}

		public static void Matrix()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Random r = new Random();
			int[,] array2D = new int[50,70];
			string text = string.Empty;

			for (int i = 0; i < 50; i++)
			{
				for (int a = 0; a < 70; a++)
				{
					int random = r.Next(0, 10);
					if(random > 3)
					{
						array2D[i, a] = r.Next(0, 9);
						text += array2D[i, a].ToString();
					}
					else
					{
						text += " ";
					}
				}
				Console.WriteLine(text);
				text = "";
				System.Threading.Thread.Sleep(80);
			}
			BackSelect();
		}

		public static void fileCreator()
		{
			Console.Clear();
			Console.WriteLine("Write path");
			string path = Console.ReadLine();
		}

		public static void tipSport()
		{
			Random r = new Random();
			int[] random = new int[10];
			int succes = 0;
			for (int i = 0; i < random.Length; i++)
			{
				random[i] = r.Next(0, 100);
			}
			string[] player = new string[3];
			for (int i = 0; i < player.Length; i++)
			{
				player[i] = Console.ReadLine();
			}
			int[] tips = new int[player.Length];
			for (int i = 0; i < tips.Length; i++)
			{
				tips[i] = int.Parse(player[i]);
				for (int y = 0; y < random.Length; y++)
				{
					if(tips[i] == random[y])
					{
						succes++;
					}
				}
			}
			float value = succes / player.Length;
			Console.WriteLine("succes tips " + value);
			Console.WriteLine("if you want to show all number then push 0");
			string check = Console.ReadLine();
			if(check == "0")
			{
				for (int i = 0; i < random.Length; i++)
				{
					Console.WriteLine("number " + (i + 1) + " - " + random[i]);
				}
				BackSelect();
			}
			else
			{
				BackSelect();
			}
		}

		public static void changeColor()
		{
			if (DateTime.Now.Month < 4.5f && DateTime.Now.Month > 1.5f)
			{
				Console.BackgroundColor = ConsoleColor.DarkGreen;
			}
			else if (DateTime.Now.Month > 4.5f && DateTime.Now.Month < 7.5f)
			{
				Console.BackgroundColor = ConsoleColor.DarkRed;
			}
			else if (DateTime.Now.Month > 7.5f && DateTime.Now.Month < 10.5f)
			{
				Console.BackgroundColor = ConsoleColor.DarkMagenta;
			}
			else
			{
				Console.BackgroundColor = ConsoleColor.DarkBlue;
			}

			if(DateTime.Now.Year % 4 == 0)
			{
				if(DateTime.Now.Month == 2)
				{
					Console.BackgroundColor = ConsoleColor.DarkBlue;
				}
				else
				{
					Console.BackgroundColor = ConsoleColor.DarkYellow;
				}
			}
			BackSelect();
		}

		public static void BackSelect()
		{
			Console.WriteLine("press key for call function" + "\n" + "0 = go back");
			string checkPress = Console.ReadLine();
			if (checkPress == "0")
			{
				MainMenu();
			}
		}

		public static void loverUpperText()
		{
			Console.Clear();
			Console.WriteLine("Lowercase and uppercase function");
			Console.WriteLine("Write text and then push enter");
			string defaultText = Console.ReadLine();
			string lowerText = defaultText.ToLower();
			string upperText = defaultText.ToUpper();
			Console.WriteLine(defaultText + " this is a default text" + "\n" + lowerText + " this is a lower text" + "\n" + upperText + " this is a upper text");
			BackSelect();
		}

		public static void sortingText()
		{
			Console.Clear();
			Console.WriteLine("Soritng text function");
			Console.WriteLine("Write text and then push enter");
			string sort = Console.ReadLine();
			char[] sortChar = sort.ToCharArray();
			Array.Sort(sortChar);
			string sorted = string.Empty;
			foreach (var item in sortChar)
			{
				sorted += item;
			}
			Console.WriteLine("Before: " + sort);
			Console.WriteLine("After: " + sorted);
			BackSelect();
		}

		public static void TrimText()
		{
			Console.Clear();
			Console.WriteLine("Trim text function");
			Console.WriteLine("press key for call function" + "\n" + "0 = remove characters from begin of text" + "\n" + 
				"1 = remove characters from end of text" + "\n" + "2 = remove character from both side");
			string check = Console.ReadLine();
			if(check == "0")
			{
				Console.WriteLine("Write text and then push enter");
				string text = Console.ReadLine();
				Console.WriteLine("write all characters for remove [ WITHOUT SPACES AND DOTS ] and then push enter");
				string charText = Console.ReadLine();
				char[] Char = charText.ToCharArray();
				string NewString = text.TrimStart(Char);
				Console.WriteLine("Before: " + text);
				Console.WriteLine("After: " + NewString);
			}
			else if(check == "1")
			{
				Console.WriteLine("Write text and then push enter");
				string text = Console.ReadLine();
				Console.WriteLine("write all characters for remove [ WITHOUT SPACES AND DOTS ] and then push enter");
				string charText = Console.ReadLine();
				char[] Char = charText.ToCharArray();
				string NewString = text.TrimEnd(Char);
				Console.WriteLine("Before: " + text);
				Console.WriteLine("After: " + NewString);
			}
			else if(check == "2")
			{
				Console.WriteLine("Write text and then push enter");
				string text = Console.ReadLine();
				Console.WriteLine("write all characters for remove [ WITHOUT SPACES AND DOTS ] and then push enter");
				string charText = Console.ReadLine();
				char[] Char = charText.ToCharArray();
				string NewString = text.Trim(Char);
				Console.WriteLine("Before: " + text);
				Console.WriteLine("After: " + NewString);
			}
			BackSelect();
		}

		public static void RemovePartOfText()
		{
			Console.Clear();
			Console.WriteLine("Remove part of text function");
			Console.WriteLine("Write text and then push enter");
			string text = Console.ReadLine();
			Console.WriteLine("Write two int for position and for length");
			string pos1 = Console.ReadLine();
			int posx = int.Parse(pos1);
			string pos2 = Console.ReadLine();
			int posy = int.Parse(pos2);
			string newText = text.Remove(posx, posy);
			Console.WriteLine("Before: " + text);
			Console.WriteLine("After: " + newText);
			BackSelect();
		}

		public static void FindPartOfText()
		{
			Console.Clear();
			Console.WriteLine("Find part of text function");
			Console.WriteLine("Write text and then push enter");
			string text = Console.ReadLine();
			Console.WriteLine("Write text and then push enter");
			string startText = Console.ReadLine();
			Console.WriteLine("Write text and then push enter");
			string endText = Console.ReadLine();
			if (text.Contains(startText) && text.Contains(endText))
			{
				int Start = text.IndexOf(startText, 0) + startText.Length;
				int End = text.IndexOf(endText, Start);
				string strToReplace = text.Substring(Start, End - Start);
				Console.WriteLine("Find");
				Console.WriteLine(strToReplace);
			}
			else
			{
				Console.WriteLine("Text not contain finding part of text");
			}
			BackSelect();
		}

		public static void CopyText()
		{
			Console.Clear();
			Console.WriteLine("Copy text function");
			Console.WriteLine("Write text and then push enter");
			string text = Console.ReadLine();
			Console.WriteLine("Write number for multiplication");
			string numberText = Console.ReadLine();
			int number = int.Parse(numberText);
			string[] writeText = new string[number];
			for (int i = 0; i < number; i++)
			{
				writeText[i] = text;
				Console.WriteLine(writeText[i]);
			}
			BackSelect();
		}

		public static void ReverseString()
		{
			Console.Clear();
			Console.WriteLine("Reverse text function");
			Console.WriteLine("Write text and then push enter");
			string text = Console.ReadLine();
			char[] charX = text.ToCharArray();
			Array.Reverse(charX);
			string reversed = string.Empty;
			foreach (var item in charX)
			{
				reversed += item;
			}
			Console.WriteLine("Before: " + text);
			Console.WriteLine("After: " + reversed);
			BackSelect();
		}

		public static void uppercase()
		{
			Console.Clear();
			Console.WriteLine("Uppercase function");
			Console.WriteLine("Write text and then push enter");
			string text = Console.ReadLine();
			char[] charX = text.ToCharArray();
			charX[0] = Char.ToUpper(charX[0]);
			for (int i = 0; i < charX.Length; i++)
			{
				if(Char.IsWhiteSpace(charX[i]))
				{
					charX[i + 1] = Char.ToUpper(charX[i + 1]);
				}
			}
			string newText = string.Empty;
			foreach (var item in charX)
			{
				newText += item;
			}
			Console.WriteLine("Before: " + text);
			Console.WriteLine("After: " + newText);
			BackSelect();
		}

		public static void uppercaseLastWord()
		{
			Console.Clear();
			Console.WriteLine("Uppercase last word function");
			Console.WriteLine("Write text and then push enter");
			string text = Console.ReadLine();
			char[] charX = text.ToCharArray();
			for (int i = (charX.Length - 1); i > 1; i--)
			{
				if (Char.IsWhiteSpace(charX[i]))
				{
					for (int y = 0; y < (charX.Length - i); y++)
					{
						charX[i + y] = Char.ToUpper(charX[i + y]);
					}
					break;
				}
			}
			string newText = string.Empty;
			foreach (var item in charX)
			{
				newText += item;
			}
			Console.WriteLine("Before: " + text);
			Console.WriteLine("After: " + newText);
			BackSelect();
		}

		public static void everySecondWordWillUppercase()
		{
			Console.Clear();
			Console.WriteLine("Every second word will uppercase function");
			Console.WriteLine("Write text and then push enter");
			string text = Console.ReadLine();
			bool second = true;
			int start = 0;
			int end = 0;
			int value = 0;
			char[] charX = text.ToCharArray();
			for (int i = 0; i < charX.Length; i++)
			{
				if (Char.IsWhiteSpace(charX[i]))
				{
					if (second == false)
					{
						second = true;
						Console.WriteLine("second");
					}
					else
					{
						for (int y = i + 1; y < charX.Length; y++)
						{
							if (Char.IsWhiteSpace(charX[y]))
							{
								start = i;
								end = y;
								value = end - start;
								Console.WriteLine("find second word");
								Console.WriteLine("start " + start);
								Console.WriteLine("end " + end);
								Console.WriteLine("value is " + value);
								for (int x = 0; x < value; x++)
								{
									Console.WriteLine("lets change");
									charX[x + start] = Char.ToUpper(charX[x + start]);
								}
								second = false;
								break;
							}
						}
					}
				}
			}
			string newText = string.Empty;
			foreach (var item in charX)
			{
				newText += item;
			}
			Console.WriteLine("Before: " + text);
			Console.WriteLine("After: " + newText);
			BackSelect();
		}

		public static void deleteWithoutTrim()
		{
			Console.Clear();
			Console.WriteLine("Deleting without trim function");
			Console.WriteLine("Write text and then push enter");
			string text = Console.ReadLine();
			Console.WriteLine("Write text and then push enter");
			string deleteText = Console.ReadLine();
			char[] charX = deleteText.ToCharArray();
			char[] charText = text.ToCharArray();
			string newText = text;
			for (int i = 0; i < charText.Length; i++)
			{
				Deleting(ref newText, charX);
			}
			Console.WriteLine("Before: " + text);
			Console.WriteLine("After: " + newText);
			BackSelect();
		}

		public static void Deleting(ref string newText_,char[] CharX_)
		{
			char[] newTextChar = newText_.ToCharArray();
			for (int i = 0; i < newTextChar.Length; i++)
			{
				if (newTextChar[i] == CharX_[0])
				{
					newText_ = newText_.Remove(i, 1);
					break;
				}
			}
		}

		public static void Calculator()
		{
			Console.Clear();
			Console.WriteLine("Calculate function");
			Console.WriteLine("Select function");
			Console.WriteLine("0 = +");
			Console.WriteLine("1 = -");
			Console.WriteLine("2 = /");
			Console.WriteLine("3 = *");
			Console.WriteLine("4 = power");
			Console.WriteLine("5 = while power");
			Console.WriteLine("6 = do/while power");
			Console.WriteLine("7 = [f (x) = x ^ (x-1)]");
			Console.WriteLine("8 = time");
			string check = Console.ReadLine();
			if(check == "0")
			{
				Console.Clear();
				Console.WriteLine("write two number");
				string calcul = Console.ReadLine();
				float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
				string calcul2 = Console.ReadLine();
				float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
				float value = numberCalcul + numberCalcul2;
				Console.WriteLine(value);
			}
			else if (check == "1")
			{
				Console.Clear();
				Console.WriteLine("write two number");
				string calcul = Console.ReadLine();
				float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
				string calcul2 = Console.ReadLine();
				float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
				float value = numberCalcul - numberCalcul2;
				Console.WriteLine(value);
			}
			else if (check == "2")
			{
				Console.Clear();
				Console.WriteLine("write two number");
				string calcul = Console.ReadLine();
				float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
				string calcul2 = Console.ReadLine();
				float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
				float value = numberCalcul / numberCalcul2;
				Console.WriteLine(value);
			}
			else if (check == "3")
			{
				Console.Clear();
				Console.WriteLine("write two number");
				string calcul = Console.ReadLine();
				float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
				string calcul2 = Console.ReadLine();
				float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
				float value = numberCalcul * numberCalcul2;
				Console.WriteLine(value);
			}
			else if (check == "4")
			{
				Console.Clear();
				Console.WriteLine("write two number");
				string calcul = Console.ReadLine();
				float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
				string calcul2 = Console.ReadLine();
				float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
				float value = (float)Math.Pow(numberCalcul,numberCalcul2);
				Console.WriteLine(value);
			}
			else if(check == "5")
			{
				Console.Clear();
				Console.WriteLine("write two number");
				string calcul = Console.ReadLine();
				float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
				string calcul2 = Console.ReadLine();
				float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
				float value = numberCalcul;
				while (value < numberCalcul2)
				{
					value = (float)Math.Pow(value, 2);
					Console.WriteLine(value);
				}
			}
			else if(check == "6")
			{
				Console.Clear();
				Console.WriteLine("write two number");
				string calcul = Console.ReadLine();
				float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
				string calcul2 = Console.ReadLine();
				float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
				float value = numberCalcul;
				do
				{
					value = (float)Math.Pow(value, 2);
					Console.WriteLine(value);
				} while (value < numberCalcul2);
			}
			else if(check == "7")
			{
				Console.Clear();
				Console.WriteLine("f(x) = x ^ (x - 1)");
				for (int i = -10; i < 10; i++)
				{
					float value = (float)Math.Pow(i, (i - 1));
					Console.WriteLine(value);
				}
			}
			else if(check == "8")
			{
				do
				{
					Console.WriteLine(DateTime.Now.Date + "." + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second
						+ "." + DateTime.Now.Millisecond);
				} while (true);
			}
			BackSelect();
		}
	}
}
