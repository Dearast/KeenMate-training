using System;

namespace TipSport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Training by KeenMate";
            Write("Training by KeenMate \t\t\t\t\t Done by Damien Clément", ConsoleColor.Green, true);
            TipGame();
        }

        public static void Write(string text, ConsoleColor color = ConsoleColor.White, bool backToDefault = false, ConsoleColor backColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = backColor;
            Console.WriteLine(text);
            if (backToDefault)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void ParseString(string text, out int outInt)
        {
            outInt = int.Parse(text);
        }

        public static void WriteTip(out string check)
        {
            check = Console.ReadLine();
        }

        public static void TipGame(int count = 0)
        {
            int i = 0;
            i += count;
            Random r = new Random();
            int rNumber = r.Next(int.Parse(System.Configuration.ConfigurationSettings.AppSettings["minNumber"]), int.Parse(System.Configuration.ConfigurationSettings.AppSettings["maxNumber"]));
#if DEBUG
            Write("rNumber min - " + int.Parse(System.Configuration.ConfigurationSettings.AppSettings["minNumber"]), ConsoleColor.Blue);
            Write("rNumber max - " + int.Parse(System.Configuration.ConfigurationSettings.AppSettings["maxNumber"]), ConsoleColor.Blue);
#endif
            Write("Guess number between 0-10");
            string check;
            WriteTip(out check);
            int checkNumber;
            ParseString(check, out checkNumber);
            if (checkNumber == rNumber)
            {
                EndTip(i);
            }
            else
            {
                i++;
                TipGame(i);
            }
        }

        public static void EndTip(int count)
        {
            Write("yout tip count to hit success number is - " + count);
            if (count > 20)
            {
                Write("little bit more");
            }
            else if (count > 40)
            {
                Write("far more");
            }
            Console.ReadKey();
        }
    }
}
