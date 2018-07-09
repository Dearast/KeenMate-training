using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace List
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

		static void Main(string[] args)
		{
			Start();
			Console.ReadKey();
		}

		public static void Start()
		{
			Random r = new Random();    //vytvoří random
			WriteLine("Write min date");
			string checkMinDate = Console.ReadLine();   //napiš číslo ve stringu
			int checkMinDateInt = int.Parse(checkMinDate);    //přepiš string na int
			WriteLine("Write max date");
			string checkMaxDate = Console.ReadLine();   //napiš číslo ve stringu
			int checkMaxDateInt = int.Parse(checkMaxDate);    //přepiš string na int
			List<DateTime> date = DateList(r, checkMinDateInt, checkMaxDateInt);  //Vytvoř list s daty
			DrawDate(date);   //Vypiš všechny data v listu
		}

		public static List<DateTime> DateList(Random r, int minYear, int maxYear)
		{
			//Vygenerování dat
			int selectYear = r.Next(minYear, maxYear);		//náhodně vyber datum mezi maximume a minimem
			List<DateTime> date = new List<DateTime>();		//vytvoř nový list pro následný return
			List<int> months = new List<int>();		//vytvoř list pro měsíce
			List<int> days = new List<int>();		//vytvoř list pro dny v měsíci
			for (int i = 0; i < 12; i++)		//opakuj 12(maximální počet měsícu)
			{
				int random = r.Next(0, 100);		//Náhodně vygeneruj číslo
				if(random > 50)		//jestli je větší jak 50 tak proveď akci
				{
					months.Add(i);		//přidej číslo měsíce na seznam
					for (int a = 0; a < countDays(i, selectYear); a++)		//udělej tolikrát kolik má měsíc dnů
					{
						int secondRandom = r.Next(0, 100);    //Náhodně vygeneruj číslo
						if (secondRandom > 50)    //jestli je větší jak 50 tak proveď akci
						{
							days.Add(a);		//přidej číslo dne na seznam
						}
					}
				}
			}

			//Přenes čísla na stringy a poté na datetime
			for (int i = 0; i < months.Count; i++)
			{
				int countDaysInt = countDays(i,selectYear);
				for (int a = 0; a < countDaysInt; a++)
				{
					string dateValuesString = string.Empty;
					dateValuesString += dateValuesDay(a,days) + dateValuesMonth(i,months);
					dateValuesString += selectYear;
					string pattern = "dd-MM-yyyy";
					DateTime newDate;
					if (DateTime.TryParseExact(dateValuesString, pattern, null,DateTimeStyles.None, out newDate))
					{
						date.Add(newDate);
					}
				}
			}
			return date;		//vrať data
		}

		public static string dateValuesDay(int day,List<int>days)
		{
			string dateValues = string.Empty;
			if (days[day] < 10)
			{
				dateValues += "0" + (days[day] + 1) + "-";
			}
			else
			{
				dateValues += (days[day] + 1) + "-";
			}
			return dateValues;
		}

		public static string dateValuesMonth(int month,List<int>months)
		{
			string dateValues = string.Empty;
			if (months[month] < 10)
			{
				dateValues += "0" + (months[month] + 1) + "-";
			}
			else
			{
				dateValues += (months[month] + 1) + "-";
			}
			return dateValues;
		}

		public static int countDays(int currentMonth,int selectYear)
		{
			int countDays = 0;
			if (currentMonth == 2)
			{
				countDays = 28;
			}
			else if (currentMonth == 2 && selectYear % 4 == 0)
			{
				countDays = 29;
			}
			else if (currentMonth % 2 == 0)
			{
				countDays = 30;
			}
			else
			{
				countDays = 31;
			}
			return countDays;
		}

		public static void DrawDate(List<DateTime> dateList)
		{
			Console.Clear();
			for (int i = 0; i < dateList.Count; i++)
			{
				WriteLine(dateList[i].ToString("dd/MM/yyyy"));
			}
		}
	}
}
